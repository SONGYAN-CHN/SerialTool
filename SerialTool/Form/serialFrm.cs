using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using MyTools;
using System.Diagnostics;

namespace SerialTool
{
    public partial class SerialFrm : Form
    {
        public Mutex mutex = new Mutex();
        private SerialPort serialPort = new SerialPort();
        private SendTool sendTool = new SendTool();
        private Stopwatch stopwatch = new Stopwatch();
        private ConfigFile _configFile = new ConfigFile();
        public SerialFrm()
        {

            InitializeComponent();

            foreach (string com in SerialPort.GetPortNames())
                this.cboPort.Items.Add(com);

            cboPort.Text = SerialPort.GetPortNames()[0];

            _configFile.InitConfigFile();
            cboBaudRate.Text = _configFile.LoadData("波特率");
            cboDataBits.Text = _configFile.LoadData("数据位");
            cboStopBits.Text = _configFile.LoadData("停止位");
            cboCheck.Text = _configFile.LoadData("奇偶校验");
            tbxTI.Text = _configFile.LoadData("自动发送TI");


        }

        /// <summary>
        /// 关闭时将内容保存至config.xml中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            

            _configFile.SaveData("波特率", cboBaudRate.Text);
            _configFile.SaveData("数据位", cboDataBits.Text);
            _configFile.SaveData("停止位", cboStopBits.Text);
            _configFile.SaveData("奇偶校验", cboCheck.Text);
            _configFile.SaveData("自动发送TI", tbxTI.Text);

        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {


            switch (cboStopBits.Text)
            {
                case "1":
                    serialPort.StopBits = StopBits.One;
                    break;
                /*
                    //PC不支持1.5
                    case "1.5":
                        serialPort.StopBits = StopBits.OnePointFive;
                        break;
                */
                case "2":
                    serialPort.StopBits = StopBits.Two;
                    break;

            }
            //0 - 无校验
            //1 - 偶校验
            //2 - 奇校验
            switch (cboCheck.Text)
            {
                case "0-无校验":
                    serialPort.Parity = Parity.None;
                    break;
                case "1-偶校验":
                    serialPort.Parity = Parity.Even;
                    break;
                case "2-奇校验":
                    serialPort.Parity = Parity.Odd;
                    break;

            }
            serialPort.PortName = cboPort.Text;
            serialPort.BaudRate = int.Parse(cboBaudRate.Text);
            serialPort.DataBits = int.Parse(cboDataBits.Text);




            try
            {
                serialPort.Open();
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            catch
            {
                MessageBox.Show("串口打开失败！");
                return;
            }
            if (serialPort.IsOpen)
                txtAccept.AppendText(TimeGetTool.TextTime() + "串口打开成功！\r\n");


            this.btnClosePort.Enabled = true;
            this.btnOpenPort.Enabled = false;
            this.cboPort.Enabled = false;
            this.cboBaudRate.Enabled = false;
            this.cboDataBits.Enabled = false;
            this.cboStopBits.Enabled = false;
            this.cboCheck.Enabled = false;
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {

            serialPort.Close();
            if (!serialPort.IsOpen) txtAccept.AppendText(TimeGetTool.TextTime() + "串口关闭成功！\r\n");
            this.btnClosePort.Enabled = false;
            this.btnOpenPort.Enabled = true;
            this.chkAutoSend.Checked = false;
            this.cboPort.Enabled = true;
            this.cboBaudRate.Enabled = true;
            this.cboDataBits.Enabled = true;
            this.cboStopBits.Enabled = true;
            this.cboCheck.Enabled = true;
            this.chkAutoSend.Checked = false;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cboPort.Items.Clear();
            foreach (string com in SerialPort.GetPortNames())
                this.cboPort.Items.Add(com);
            cboPort.Text = SerialPort.GetPortNames()[0];
            this.chkAutoSend.Checked = false;
            this.btnClosePort.Enabled = false;
            this.btnOpenPort.Enabled = true;
            this.cboPort.Enabled = true;
            this.cboBaudRate.Enabled = true;
            this.cboDataBits.Enabled = true;
            this.cboStopBits.Enabled = true;
            this.cboCheck.Enabled = true;
            this.chkAutoSend.Checked = false;
            serialPort.Close();
        }

        private void btnAcClear_Click(object sender, EventArgs e)
        {
            this.txtAccept.Clear();
        }

        private void btnSeClear_Click(object sender, EventArgs e)
        {
            this.txtSend.Clear();
        }

        /// <summary>
        /// 创建以系统时间命名的txt文档保存接收区和发送区内容
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter(SaveTool.NameTimeSave()))
            {
                streamWriter.WriteLine(this.txtAccept.Text);
            }

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {

            if (!serialPort.IsOpen)
            {
                MessageBox.Show("串口未打开！");
                return;
            }
            btnSave.Enabled = false;
            stopwatch.Restart();

            serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
            string rcv = await sendTool.SendAndRcv(serialPort, this.txtSend.Text);
            txtAccept.AppendText($"{TimeGetTool.TextTime()}--发送-->{txtSend.Text}\r\n{TimeGetTool.TextTime()}--接收-->{rcv}\r\n");
            stopwatch.Stop();
            txtAccept.AppendText($"耗时：{stopwatch.ElapsedMilliseconds}ms\r\n");
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            btnSave.Enabled = true;

        }

        private async void chkAutoSend_CheckedChanged(object sender, EventArgs e)
        {

            if (this.chkAutoSend.Checked)
            {
                if (!serialPort.IsOpen)
                {
                    MessageBox.Show("串口未打开！");
                    this.chkAutoSend.Checked = false;
                    return;
                }
                serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);

                this.btnSend.Enabled = false;
                tbxTI.Enabled = false;
                btnSave.Enabled = false;
                while (this.chkAutoSend.Checked)
                {


                    try
                    {
                        stopwatch.Restart();
                        await Task.Delay(Int32.Parse(tbxTI.Text) - 100);
                        string rcv = await sendTool.SendAndRcv(serialPort, this.txtSend.Text);
                        txtAccept.AppendText($"{TimeGetTool.TextTime()}--发送-->{txtSend.Text}\r\n{TimeGetTool.TextTime()}--接收-->{ rcv}\r\n");
                        stopwatch.Stop();
                        txtAccept.AppendText($"耗时：{stopwatch.ElapsedMilliseconds}ms\r\n");

                    }
                    catch
                    {

                        this.chkAutoSend.Checked = false;
                        this.btnSend.Enabled = true;
                        btnSave.Enabled = true;
                        MessageBox.Show("串口未打开！");
                        break;
                    }


                }
                btnSave.Enabled = true;
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            else
            {
                this.btnSend.Enabled = true;
                tbxTI.Enabled = true;
            }

        }

        /// <summary>
        /// 用以规定tbx时间间隔输入为100ms起，与输入不为数字的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxTI_Leave(object sender, EventArgs e)
        {
            try
            {

                int c = Int32.Parse(tbxTI.Text);
                if (c < 100)
                {
                    tbxTI.Text = "100";
                    MessageBox.Show("最低为100ms！");


                }
            }
            catch
            {

                MessageBox.Show("ms输入错误！");
                tbxTI.Text = "100";
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {


            this.Invoke(new Action(() =>
           {

               txtAccept.AppendText($"{TimeGetTool.TextTime()}[主动上报]--接收--> {sendTool.OnlyRcv(serialPort)}\r\n");

           }));



        }


    }

}
