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
        TcpClientHelper tcpClient = new TcpClientHelper();

        public netFrm()
        {

            InitializeComponent();
            tcpClient.messageReceived += TcpClientHelper_MessageReceived;
            txtServerIp.Text = "192.168.60.65";
            txtServerPort.Text = "6666";
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
    }
}
