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

namespace SerialTool
{
    public partial class Form1 : Form
    {
        public Mutex mutex = new Mutex();
        public ConvertTool convertTool = new ConvertTool();



        private SerialPort serialPort = new SerialPort();
        private TimeGetTool timeGet = new TimeGetTool();
        private SendTool sendTool = new SendTool();
        public Form1()
        {
            InitializeComponent();
            foreach (string com in SerialPort.GetPortNames())
                this.cboPort.Items.Add(com);
            cboPort.Text = SerialPort.GetPortNames()[0];
            cboPort.Text = Properties.Settings.Default.cboPortText;

            this.cboStopBits.Text = Properties.Settings.Default.cboStopBitsText;
            this.cboCheck.Text = Properties.Settings.Default.cboCheckText;
            this.cboDataBits.Text = Properties.Settings.Default.cboDataBitsText;
            this.cboBaudRate.Text = Properties.Settings.Default.cboBaudRateText;
            this.tbxTI.Text = Properties.Settings.Default.tbxTIText;


        }
        /// <summary>
        /// 关闭时将cbo中内容保存至Properties.Settings中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Properties.Settings.Default.cboPortText = cboPort.Text;
            Properties.Settings.Default.cboStopBitsText = cboStopBits.Text;
            Properties.Settings.Default.cboCheckText = cboCheck.Text;
            Properties.Settings.Default.cboDataBitsText = cboDataBits.Text;
            Properties.Settings.Default.cboBaudRateText = cboBaudRate.Text;
            Properties.Settings.Default.tbxTIText = tbxTI.Text;
            Properties.Settings.Default.Save();
        }




        private void btnOpenPort_Click(object sender, EventArgs e)
        {


            //停止位和奇偶校验赋值有新方法
            switch (cboStopBits.Text)
            {
                case "1":
                    serialPort.StopBits = StopBits.One;
                    break;
                /*
                    PC不支持1.5
                    case "1.5":
                        serialPort.StopBits = StopBits.OnePointFive;
                        break;
                */
                case "2":
                    serialPort.StopBits = StopBits.Two;
                    break;

            }
            // 0 - 无校验
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
                serialPort.DataReceived += new SerialDataReceivedEventHandler(TestRead);
            }
            catch
            {
                MessageBox.Show("串口打开失败！");
                return;
            }
            if (serialPort.IsOpen) txtAccept.AppendText(timeGet.TextTime() + "串口打开成功！\r\n");

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
            if (!serialPort.IsOpen) txtAccept.AppendText(timeGet.TextTime() + "串口关闭成功！\r\n");
            this.btnClosePort.Enabled = false;
            this.btnOpenPort.Enabled = true;
            this.chkAutoSend.Checked = false;
            this.cboPort.Enabled = true;
            this.cboBaudRate.Enabled = true;
            this.cboDataBits.Enabled = true;
            this.cboStopBits.Enabled = true;
            this.cboCheck.Enabled = true;

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

            SaveTool saveTool = new SaveTool();
            using (StreamWriter streamWriter = new StreamWriter(saveTool.NameTimeSave(timeGet)))
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
            serialPort.DataReceived -= new SerialDataReceivedEventHandler(TestRead);
            //txtAccept.AppendText(timeGet.TextTime()+ "--发送-->" + txtSend.Text+"\r\n"+timeGet.TextTime() + "--接收-->" + await sendTool.EasySend(serialPort, this.txtSend.Text) + "\r\n");
            txtAccept.AppendText(timeGet.TextTime() + "--发送-->" + txtSend.Text + "\r\n" + timeGet.TextTime() + "--接收-->" + await sendTool._698SendAndRead(serialPort, this.txtSend.Text) + "\r\n");
            serialPort.DataReceived += new SerialDataReceivedEventHandler(TestRead);
            btnSave.Enabled = true;

        }
        private async void chkAutoSend_CheckedChanged(object sender, EventArgs e)
        {

            if (this.chkAutoSend.Checked)
            {
                this.btnSend.Enabled = false;
                tbxTI.Enabled = false;
                btnSave.Enabled = false;
                while (this.chkAutoSend.Checked)
                {
                    //sleep单位ms
                    //Thread.Sleep(Int32.Parse(tbx时间间隔.Text));

                    try
                    {
                        await Task.Delay(Int32.Parse(tbxTI.Text) - 100);//犹豫发送窗口本身需等待100ms，为了求得实际值需-100，如输入200ms后200-100+100=200ms
                        txtAccept.AppendText(timeGet.TextTime() + await sendTool._645SendAndRead(serialPort, this.txtSend.Text) + "\r\n");
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

        private void lblMs_Click(object sender, EventArgs e)
        {

        }

        private void tbxTI_TextChanged(object sender, EventArgs e)
        {

        }
        private void TestRead(object sender, SerialDataReceivedEventArgs e)
        {





            



            int Num698;




            try
            {
                mutex.WaitOne();



                


                //68是数组下标

                List<byte> readByteList = new List<byte>();

                #region 内嵌
                while (true)
                {




                    int count = 0;
                    Thread.Sleep(200);
                    count = serialPort.BytesToRead;
                    //Console.WriteLine(count);
                    byte[] readByte = new byte[count];

                    serialPort.Read(readByte, 0, count);


                    readByteList.AddRange(readByte);

                    

                    Console.WriteLine("Byte List Elements:");
                    foreach (byte b in readByte)
                    {
                        Console.Write(b.ToString("X2") + " ");
                    }
                    Console.WriteLine();

                    int ctrlInt;
                    string ctrlStr;
                    byte[] ctrlByte = new byte[2];



                    Num698 = readByteList.IndexOf(0x68);

                    //Console.WriteLine(Num698);
                    #region 判断

                    if (readByteList[Num698] != 0x68)
                    {

                        continue;

                    }
                    else
                    {

                        ctrlByte[0] = readByteList[Num698 + 2];
                        ctrlByte[1] = readByteList[Num698 + 1];
                        ctrlStr = ConvertTool.ByteToStringNoSpace(ctrlByte);
                        ctrlInt = Convert.ToInt32(ctrlStr, 16);
                        if (readByteList[Num698 + 1 + ctrlInt] == 0x16)
                        {


                            break;
                        }
                        else
                        {


                            continue;
                        }


                    }


                    #endregion

                }
                #endregion
                byte[] vs1 = readByteList.ToArray();

                this.Invoke(new Action(() =>
                {
                    
                    txtAccept.AppendText(timeGet.TextTime() + "--接收-->"+ convertTool.ByteToString(vs1) + "\r\n");
                }));
                mutex.ReleaseMutex();

            }
            finally
            {

                
            }


        }
    }

}
