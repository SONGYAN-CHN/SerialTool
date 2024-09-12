using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace MyTools
{
    public class TcpClientHelper
    {

        Encoding gb18030Encoding = Encoding.GetEncoding("GB18030");
        private NetworkStream _stream;
        private TcpClient _client;
        public bool _isConnected = false;
        public event EventHandler<string> messageReceived;

        /// <summary>
        /// 打开
        /// 存在问题，当服务器为开启监听疯狂点击建立连接开启多个线程，立即开启服务器连接会将后续未进行的线程全部连接上并结束不了
        /// </summary>
        /// <param name="ipaddr"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public string Connect(string ipaddr, int port)
        {

            if (_isConnected)
            {
                return "已连接";
            }
            try
            {
                //client用的hostname连接，后续sever例子会用ipaddress可能会连接不上！！！
                _client = new TcpClient();
                _client.Connect(ipaddr, port);
                _isConnected = true;


                return "连接成功";
            }
            catch
            {
                _isConnected = false;
                return "连接失败";
            }


        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <returns></returns>
        public string Disconnect()
        {
            try
            {

                _isConnected = false;
                if (_client != null)
                {
                    if (_client.GetStream() != null)
                    {
                        _client.GetStream().Close();
                    }
                    _client.Close();
                }
                return "断开连接";
            }
            catch
            {
                return "断开失败";
            }
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Send(string message)
        {
            if (!_isConnected)
            {
                return "未连接";
            }
            try
            {
                _stream = _client.GetStream();
                byte[] data = gb18030Encoding.GetBytes(message);
                _stream.Write(data, 0, data.Length);
                return "发送成功";
            }
            catch (System.IO.IOException)
            {
                _isConnected = false;
                return "连接断开";
            }

        }

        public void StartListening()
        {
            if (_isConnected)
            {
                // 在新线程中监听消息
                Task.Run(() => ListenDataReceived());
            }
        }


        public void ListenDataReceived()
        {
            _stream = _client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;
            while (_isConnected && (bytesRead = _stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = gb18030Encoding.GetString(buffer, 0, bytesRead).TrimEnd('\0');
                messageReceived?.Invoke(this, message);

            }
        }

    }
}
