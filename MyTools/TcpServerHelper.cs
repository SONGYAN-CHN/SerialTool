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
    public delegate void ReceiveClientMessageOnly(object sender, string message, TcpClient client);
    public class TcpServerHelper
    {//啊实打实大撒大声地
        Encoding gb18030Encoding = Encoding.GetEncoding("GB18030");
        public event ClientConnectedHandler OnClientConnected;
        public event ReceiveClientMessageOnly messageReceived;
        private TcpListener _listener;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly Dictionary<(string, int), TcpClient> _connectedClientsDictionary = new Dictionary<(string, int), TcpClient>();

        #region 主要功能函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ipaddr"></param>
        /// <param name="port"></param>
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
                            _connectedClientsDictionary.Add((clientIpaddr, clienttPort), client);
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
            //已在逻辑上避免，此异常一般不会触发
            catch (System.Reflection.TargetInvocationException)
            {
                Console.WriteLine("异常");
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
        /// 全部发送功能
        /// 字典里已经连接的全部发送
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string AllSend(string message)
        {
            int i = 0;
            lock (_connectedClientsDictionary)
            {
                foreach (var ipandport in _connectedClientsDictionary)
                {

                    NetworkStream stream = ipandport.Value.GetStream();

                    byte[] data = gb18030Encoding.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    i++;

                }

                if (i != 0)
                {
                    return "发送成功";
                }
                else
                {
                    return "未有客服端建立链接";
                }
            }
        }

        /// <summary>
        /// 单个客户机发送
        /// 选择一个客户机进行对应的发送
        /// </summary>
        /// <param name="ip_port"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SingleSend(string ip_port, string message)
        {
            lock (_connectedClientsDictionary)
            {
                (string, int) key = FindDictionaryKey(ip_port);

                TcpClient sendClient = _connectedClientsDictionary[key];
                NetworkStream stream = sendClient.GetStream();

                byte[] data = gb18030Encoding.GetBytes(message);
                stream.Write(data, 0, data.Length);

                return "发送成功";
            }

        }

        /// <summary>
        /// 主动断开客户端连接
        /// </summary>
        /// <param name="ip_port"></param>
        /// <returns></returns>
        public List<Tuple<string, int>> CloseClienConnect(string ip_port)
        {
            List<Tuple<string, int>> keyList = new List<Tuple<string, int>>();
            Tuple<string, int> tuple;
            lock (_connectedClientsDictionary)
            {
                if (ip_port == "All Clients")
                {

                    foreach (var client_Ip_Port in _connectedClientsDictionary)
                    {
                        client_Ip_Port.Value.Close();
                        tuple = client_Ip_Port.Key.ToTuple();
                        keyList.Add(tuple);

                    }
                    _connectedClientsDictionary.Clear();
                    return keyList;
                }
                else
                {
                    (string, int) key = FindDictionaryKey(ip_port);
                    TcpClient clien = _connectedClientsDictionary[key];
                    clien.Close();
                    tuple = key.ToTuple();
                    keyList.Add(tuple);
                    _connectedClientsDictionary.Remove(key);
                    return keyList;
                }
            }
        }
        #endregion

        #region 辅助功能性函数
        /// <summary>
        /// 字典存储连接至服务器的客服机key值转换成string
        /// key包含ip和port
        /// </summary>
        /// <returns></returns>
        public List<string> DictionarykeyToString()
        {
            lock (_connectedClientsDictionary)
            {
                List<string> keysAsStrings = _connectedClientsDictionary.Keys.Select(key => key.ToString()).ToList();

                return keysAsStrings;
            }
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

                        messageReceived?.Invoke(this, message, client);

                        continue;
                    }
                    lock (_connectedClientsDictionary)
                    {
                        var remoteEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                        _connectedClientsDictionary.Remove((remoteEndPoint.Address.ToString(), remoteEndPoint.Port));
                    }

                    client.Close();
                }
            }

        }

        /// <summary>
        /// 用string类型ip和port去寻找字典中对应的key值返回
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        private (string, int) FindDictionaryKey(string strKey)
        {
            lock (_connectedClientsDictionary)
            {
                (string, int) key = ("0", 0);
                foreach (var key1 in _connectedClientsDictionary.Keys)
                {
                    string keystr = key1.ToString();
                    if (keystr == strKey)
                    {
                        key = key1;
                        break;
                    }
                }

                return key;
            }
        }

        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIpaddr()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);
            foreach (var address in addresses)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }
            return "";
        }
        #endregion
    }
}
