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
        Serial serial;
        private Stopwatch stopwatch = new Stopwatch();

        public SerialFrm()
        {

            InitializeComponent();

            foreach (string com in SerialPort.GetPortNames())
                this.cboPort.Items.Add(com);

            cboPort.Text = SerialPort.GetPortNames()[0];

            ConfigFile.InitConfigFile();
            cboBaudRate.Text = ConfigFile.LoadData("波特率");
            cboDataBits.Text = ConfigFile.LoadData("数据位");
            cboStopBits.Text = ConfigFile.LoadData("停止位");
            cboCheck.Text = ConfigFile.LoadData("奇偶校验");
            tbxTI.Text = ConfigFile.LoadData("自动发送TI");


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            ConfigFile.SaveData("波特率", cboBaudRate.Text);
            ConfigFile.SaveData("数据位", cboDataBits.Text);
            ConfigFile.SaveData("停止位", cboStopBits.Text);
            ConfigFile.SaveData("奇偶校验", cboCheck.Text);
            ConfigFile.SaveData("自动发送TI", tbxTI.Text);

        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {

           serial= new Serial(cboPort.Text, cboBaudRate.Text, cboDataBits.Text, cboStopBits.Text, cboCheck.Text);
            
            string rcv = Serial.Open();
            txtAccept.AppendText(TimeGetTool.TextTime() + rcv + "\r\n");

            if (Serial.serialPort.IsOpen)
            {
                Serial.SetDataReceivedHandler(DataReceivedHandler);
                this.btnClosePort.Enabled = true;
                this.btnOpenPort.Enabled = false;
                this.cboPort.Enabled = false;
                this.cboBaudRate.Enabled = false;
                this.cboDataBits.Enabled = false;
                this.cboStopBits.Enabled = false;
                this.cboCheck.Enabled = false;
            }
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            string rcv = Serial.Close();
            txtAccept.AppendText($"{TimeGetTool.TextTime()}{rcv}\r\n");
            if (!Serial.serialPort.IsOpen)
            {

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

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (Serial.serialPort.IsOpen)
            {
                string rcv = Serial.Close();
                txtAccept.AppendText(TimeGetTool.TextTime() + rcv + "\r\n");
            }
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

        }

        private void btnAcClear_Click(object sender, EventArgs e)
        {
            this.txtAccept.Clear();
        }

        private void btnSeClear_Click(object sender, EventArgs e)
        {
            this.txtSend.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter(SaveTool.NameTimeSave()))
            {
                streamWriter.WriteLine(this.txtAccept.Text);
            }

        }

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

        private async void btnSend_Click(object sender, EventArgs e)
        {

            //if (!SerialOperateTool.serialPort.IsOpen)
            //{
            //    MessageBox.Show("串口未打开！");
            //    return;
            //}
            //btnSave.Enabled = false;
            //stopwatch.Restart();

            //SerialOperateTool.serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
            //SerialOperateTool.serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
            //string rcv = await sendTool.SendAndRcv(SerialOperateTool.serialPort, this.txtSend.Text);
            //txtAccept.AppendText($"{TimeGetTool.TextTime()}--发送-->{txtSend.Text}\r\n{TimeGetTool.TextTime()}--接收-->{rcv}\r\n");
            //stopwatch.Stop();
            //txtAccept.AppendText($"耗时：{stopwatch.ElapsedMilliseconds}ms\r\n");
            //SerialOperateTool.serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            //btnSave.Enabled = true;

        }

        private async void chkAutoSend_CheckedChanged(object sender, EventArgs e)
        {

            //if (this.chkAutoSend.Checked)
            //{
            //    if (!SerialOperateTool.serialPort.IsOpen)
            //    {
            //        MessageBox.Show("串口未打开！");
            //        this.chkAutoSend.Checked = false;
            //        return;
            //    }
            //    SerialOperateTool.serialPort.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);

            //    this.btnSend.Enabled = false;
            //    tbxTI.Enabled = false;
            //    btnSave.Enabled = false;
            //    while (this.chkAutoSend.Checked)
            //    {


            //        try
            //        {
            //            stopwatch.Restart();
            //            await Task.Delay(Int32.Parse(tbxTI.Text) - 100);
            //            string rcv = await sendTool.SendAndRcv(SerialOperateTool.serialPort, this.txtSend.Text);
            //            txtAccept.AppendText($"{TimeGetTool.TextTime()}--发送-->{txtSend.Text}\r\n{TimeGetTool.TextTime()}--接收-->{ rcv}\r\n");
            //            stopwatch.Stop();
            //            txtAccept.AppendText($"耗时：{stopwatch.ElapsedMilliseconds}ms\r\n");

            //        }
            //        catch
            //        {

            //            this.chkAutoSend.Checked = false;
            //            this.btnSend.Enabled = true;
            //            btnSave.Enabled = true;
            //            MessageBox.Show("串口未打开！");
            //            break;
            //        }


            //    }
            //    btnSave.Enabled = true;
            //    SerialOperateTool.serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            //}
            //else
            //{
            //    this.btnSend.Enabled = true;
            //    tbxTI.Enabled = true;
            //}

        }




        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {


            this.Invoke(new Action(() =>
           {

               txtAccept.AppendText($"{TimeGetTool.TextTime()}[主动上报]--接收--> {serial.Rcv698()}\r\n");

           }));



        }
        //public void DataRcvShow(string rcv)
        //{
        //    this.Invoke(new Action(() =>
        //    {

        //        txtAccept.AppendText($"{TimeGetTool.TextTime()}[主动上报]--接收--> {rcv}\r\n");

        //    }));
        //}


    }

}
