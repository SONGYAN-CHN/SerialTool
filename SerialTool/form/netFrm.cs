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

namespace SerialTool
{
    public partial class netFrm : Form
    {
        private ConfigFile _configFile = new ConfigFile();
        TcpClientHelper tcpClient = new TcpClientHelper();

        public netFrm()
        {

            InitializeComponent();
            tcpClient.messageReceived += TcpClientHelper_MessageReceived;
            _configFile.InitConfigFile();
            cboProtocol.Text = _configFile.LoadData("协议类型");
            txtServerIp.Text = _configFile.LoadData("服务器IP地址");
            txtServerPort.Text = _configFile.LoadData("服务器端口号");
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            //服务器关闭产生发送异常
            string sendResult = tcpClient.Send(txtSend.Text);
            if (sendResult == "连接断开")
            {
                btnConnect.Text = "建立连接";
            }
            txtAccept.AppendText(TimeGetTool.TextTime() + sendResult + "\r\n");

        }

        private void btnOpenOrClose_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "关闭连接")
            {
                btnConnect.Text = "建立连接";
                tcpClient.Disconnect();

            }
            else
            {

                int port = Int32.Parse(txtServerPort.Text);

                string vs = tcpClient.Connect(txtServerIp.Text, port);
                txtAccept.AppendText($"{TimeGetTool.TextTime()}{vs}\r\n");
                tcpClient.StartListening();


                if (tcpClient._isConnected == false)
                {
                    return;
                }
                btnConnect.Text = "关闭连接";

            }

        }

        private void TcpClientHelper_MessageReceived(object sender, string e)
        {
            // 更新UI必须在主线程中进行
            Invoke(new MethodInvoker(() =>
            {
                txtAccept.AppendText($"{TimeGetTool.TextTime()}[TCP Server]接收--->{e}\r\n");
            }));
        }

        private void netFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _configFile.SaveData("协议类型", cboProtocol.Text);
            _configFile.SaveData("服务器IP地址", txtServerIp.Text);
            _configFile.SaveData("服务器端口号", txtServerPort.Text);
        }
    }
}
