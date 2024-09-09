using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace MyTools
{
    public delegate void ClientConnectedHandler(object sender, string message, TcpClient client);
    public class TcpServerHelper
    {
        Encoding gb18030Encoding = Encoding.GetEncoding("GB18030");

        public event ClientConnectedHandler OnClientConnected;
        public event EventHandler<string> messageReceived;

        private TcpListener _listener;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly Dictionary<(string, int), TcpClient> _connectedClientsDictionary = new Dictionary<(string, int), TcpClient>();

        public TcpServerHelper(string ipaddr, int port)
        {
            IPAddress ip = IPAddress.Parse(ipaddr);

            _listener = new TcpListener(ip, port);
            //_listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        /// <summary>
        /// 开启监听
        /// 异步方法在await之前都为同步执行
        /// 先进入循环，当遇到await进入异步监听等待连接并且当连接之后设置为不返回主程序在新线程中执行，主程序继续循环监听
        /// </summary>
        /// <param name="ipaddr"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task StartListen()
        {
            try
            {
                
                
                _cancellationTokenSource = new CancellationTokenSource();
                _listener.Start();


                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    try
                    {
                        TcpClient client = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);
                        Console.WriteLine("连接成功");
                        string message = "已连接";
                        OnClientConnected?.Invoke(this, message, client);

                        var remoteEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                        string clientIpaddr = remoteEndPoint.Address.ToString();
                        int clienttPort = remoteEndPoint.Port;


                        lock (_connectedClientsDictionary)
                        {
                            _connectedClientsDictionary.Add((clientIpaddr,clienttPort),client);
                        }

                        Task.Run(async () =>
                       {
                           await HandleClient(client, _cancellationTokenSource);
                       });



                        if (!client.Connected)
                        {
                            client.Close();
                            break;
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        // 监听器已经被释放，退出循环
                        break;
                    }
                }
            }

            finally
            {
               
                    _listener = null;
               
                

            }


        }

       /// <summary>
       /// 停止监听函数
       /// 改变监听中while循环判断标志
       /// 通过字典关闭所有连接的服务器并清空字典
       /// </summary>
        public void Stop()
        {

            lock (_connectedClientsDictionary)
            {
                foreach (var client in _connectedClientsDictionary.Values)
                {
                    client.Close();
                }
                _connectedClientsDictionary.Clear();
            }
            _listener.Stop();
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;

            

        }

        /// <summary>
        /// 成功监听后的消息监听函数同为异步方法但不会进入新线程
        /// 整体是一个独立的线程
        /// 每一个监听成功后都会创建对应的消息监听线程在后台监听对应的消息
        /// </summary>
        /// <param name="client"></param>
        /// <param name="_cancellationTokenSource"></param>
        /// <returns></returns>
        private async Task HandleClient(TcpClient client, CancellationTokenSource _cancellationTokenSource)
        {
            using (NetworkStream stream = client.GetStream())
            {
                while (client.Connected && !_cancellationTokenSource.IsCancellationRequested)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string message = gb18030Encoding.GetString(buffer, 0, bytesRead).TrimEnd('\0');
                        messageReceived?.Invoke(this, message);
                    }
                }
            }

            //根据KEY值移除对应的客户端，在一个客户端结束消息监听时代表客户端断开了链接
            lock (_connectedClientsDictionary)
            {
                var remoteEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                _connectedClientsDictionary.Remove((remoteEndPoint.Address.ToString(), remoteEndPoint.Port));
            }
            client.Close();
        }

        //等会加入字典选择对应字典中的client发送消息也可以全部发
        public string SendToClient(TcpClient client, string message)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] data = gb18030Encoding.GetBytes(message);
                stream.Write(data, 0, data.Length);
                return "发送成功";
            }
        }

        



    }
}
