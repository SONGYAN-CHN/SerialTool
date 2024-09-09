using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyTools;
using System.Net.Sockets;
using System.Net;

namespace SerialTool
{
    public partial class netFrm : Form
    {
        private ConfigFile _configFile = new ConfigFile();
        TcpClientHelper tcpClient = new TcpClientHelper();
        TcpServerHelper tcpServer;

        public netFrm()
        {

            InitializeComponent();
            _configFile.InitConfigFile();
            cboProtocol.Text = _configFile.LoadData("协议类型");
            txtIp.Text = _configFile.LoadData("IP地址");
            txtPort.Text = _configFile.LoadData("端口号");
        }

        private void netFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _configFile.SaveData("协议类型", cboProtocol.Text);
            _configFile.SaveData("IP地址", txtIp.Text);
            _configFile.SaveData("端口号", txtPort.Text);
        }

        private void btnAcClear_Click(object sender, EventArgs e)
        {
            txtAccept.Clear();
        }

        private void btnSeClear_Click(object sender, EventArgs e)
        {
            txtSend.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            if (cboProtocol.Text == "TCP Client")
            {
                //服务器关闭产生发送异常
                string sendResult = tcpClient.Send(txtSend.Text);
                if (sendResult == "连接断开")
                {
                    btnStar.Text = "建立连接";
                }
                txtAccept.AppendText(TimeGetTool.TextTime() + sendResult + "\r\n");
            }
            else if (cboProtocol.Text == "TCP Server")
            {
                //string sendResult = tcpServer.SendToClient(tcpServer.c);
            }

        }

        private async void btnOpenOrClose_Click(object sender, EventArgs e)
        {

            if (cboProtocol.Text == "TCP Client")
            {

                if (btnStar.Text == "关闭连接")
                {

                    btnStar.Text = "建立连接";
                    tcpClient.messageReceived -= TcpClientHelper_MessageReceived;
                    cboProtocol.Enabled = true;
                    txtIp.Enabled = true;
                    txtPort.Enabled = true;

                    string vs =tcpClient.Disconnect();
                    txtAccept.AppendText($"{TimeGetTool.TextTime()}{vs}\r\n");

                }
                else
                {


                    int port = Int32.Parse(txtPort.Text);
                    string vs = tcpClient.Connect(txtIp.Text, port);
                    txtAccept.AppendText($"{TimeGetTool.TextTime()}{vs}\r\n");
                    if (tcpClient._isConnected == false)
                    {
                        return;
                    }

                    tcpClient.messageReceived += TcpClientHelper_MessageReceived;
                    tcpClient.StartListening();

                    cboProtocol.Enabled = false;
                    txtIp.Enabled = false;
                    txtPort.Enabled = false;

                    btnStar.Text = "关闭连接";

                }
            }
            else if (cboProtocol.Text == "TCP Server")
            {



                if (btnStar.Text == "启动监听")
                {
                    btnStar.Text = "停止监听";
                    cboProtocol.Enabled = false;
                    txtIp.Enabled = false;
                    txtPort.Enabled = false;
                    txtAccept.AppendText($"{TimeGetTool.TextTime()}启动监听\r\n");


                    int port = Int32.Parse(txtPort.Text);
                    tcpServer = new TcpServerHelper(txtIp.Text, port);
                    tcpServer.OnClientConnected += TcpServer_OnClientConnected;
                    tcpServer.messageReceived += TcpServertHelper_MessageReceived;
                    
                    await tcpServer.StartListen();


                }
                else
                {

                    btnStar.Text = "启动监听";
                    cboProtocol.Enabled = true;
                    txtIp.Enabled = true;
                    txtPort.Enabled = true;
                    txtAccept.AppendText($"{TimeGetTool.TextTime()}停止监听\r\n");
                    tcpServer.Stop();
                    tcpServer.OnClientConnected -= TcpServer_OnClientConnected;
                    tcpServer.messageReceived -= TcpServertHelper_MessageReceived;
                }

            }

        }



        private void cboProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProtocol.Text == "TCP Server")
            {

                lblIp.Text = "本地IP地址";
                lblPort.Text = "本地端口";
                btnStar.Text = "启动监听";
                gbxClient.Enabled = true;
                gbxClient.Visible = true;


            }
            else if (cboProtocol.Text == "TCP Client")
            {
                lblIp.Text = "服务器IP地址";
                lblPort.Text = "服务器端口";
                btnStar.Text = "建立连接";
                gbxClient.Enabled = false;
                gbxClient.Visible = false;

            }
            else
            {
                lblIp.Text = "本地IP地址";
                lblPort.Text = "本地端口";
                btnStar.Text = "打开";
                gbxClient.Enabled = false;
                gbxClient.Visible = false;
            }
        }

        /// <summary>
        /// TCP client消息接收处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpClientHelper_MessageReceived(object sender, string e)
        {

            // 更新UI必须在主线程中进行
            Invoke(new MethodInvoker(() =>
            {
                txtAccept.AppendText($"{TimeGetTool.TextTime()}[TCP Client]接收--->{e}\r\n");
            }));

        }
        private void TcpServertHelper_MessageReceived(object sender, string e)
        {

            // 更新UI必须在主线程中进行
            Invoke(new MethodInvoker(() =>
            {
                txtAccept.AppendText($"{TimeGetTool.TextTime()}[TCP Server]接收--->{e}\r\n");
            }));

        }


        private void TcpServer_OnClientConnected(object sender, string message, TcpClient client)
        {
            Invoke(new Action(() =>
            {

                var remoteEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                string ipAddress = remoteEndPoint.Address.ToString();
                int port = remoteEndPoint.Port;
                txtAccept.AppendText($"{TimeGetTool.TextTime()}新客户端[{ipAddress} {port}]{message}\r\n");
            }));
        }

    }
}
