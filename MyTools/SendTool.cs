using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;


namespace MyTools
{
    public class SendTool
    {
        private Mutex mutex = new Mutex();
        private CancellationTokenSource _cancellationTokenSource;
        public int NumStart { get; set; }
        public int Numend { get; set; }
        public int LenInt { get; set; }
        public string LenStr { get; set; }
        private int ti;

        /// <summary>
        /// 发送后接收功能
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="txtSend"></param>
        /// <returns></returns>
        public async Task<string> SendAndRcv(SerialPort serialPort, string txtSend)
        {
            return await Task.Run(() =>
            {
                try
                {
                    mutex.WaitOne();

                    string rcv;
                    byte[] textSendByte = ConvertTool.StringToByte(txtSend);
                    SendWriteToPort(serialPort, textSendByte);
                    if (Is698Or645(textSendByte) == 1)
                    {
                        return rcv = Rcv698(serialPort);

                    }
                    else if (Is698Or645(textSendByte) == 2)
                    {
                        return rcv = Rcv645(serialPort);

                    }
                    else
                    {
                        return "报文错误";
                    }
                }
                finally
                {

                    mutex.ReleaseMutex();
                }


            });


        }

        /// <summary>
        /// 用报文开头68数量判断是645还是698
        /// </summary>
        /// <param name="textByte"></param>
        /// <returns>StartCount=1代表698报文，StartCount=2代表645报文</returns>
        private int Is698Or645(byte[] textByte)
        {
            int StartCount = 0;
            foreach (int starBit in textByte)
            {
                if (starBit == 0x68)
                    StartCount++;
            }


            return StartCount;

        }

        /// <summary>
        /// 将发送窗口内容写入串口
        /// </summary>
        private void SendWriteToPort(SerialPort serialPort, byte[] textSendByte)
        {
            serialPort.DiscardOutBuffer();
            serialPort.DiscardInBuffer();
            serialPort.Write(textSendByte, 0, textSendByte.Length);
            Thread.Sleep(100);
        }

        /// <summary>
        /// 698报文接收内容
        /// </summary>
        /// <param name="serialPort"></param>
        /// <returns></returns>
        private string Rcv698(SerialPort serialPort)
        {
            List<byte> readByteList = new List<byte>();
            byte[] LenByte = new byte[2];
            _cancellationTokenSource = new CancellationTokenSource(ti);
            while (true)
            {
                try
                {

                    if (_cancellationTokenSource.Token.IsCancellationRequested)
                        throw new OperationCanceledException();
                    int count = 0;
                    count = serialPort.BytesToRead;
                    byte[] readByte = new byte[count];
                    serialPort.Read(readByte, 0, count);
                    readByteList.AddRange(readByte);


                    NumStart = readByteList.IndexOf(0x68);
                    //接收较慢还没有接收到68------调转回去继续从串口缓存读

                    if (NumStart == -1 || readByteList[NumStart] != 0x68)
                    {
                        continue;
                    }
                    else
                    {

                        LenByte[0] = readByteList[NumStart + 2];
                        LenByte[1] = readByteList[NumStart + 1];
                        LenStr = ConvertTool.ByteToStringNoSpace(LenByte);
                        LenInt = Convert.ToInt32(LenStr, 16);
                        Numend = -3;
                        Numend = NumStart + 1 + LenInt;
                        if (readByteList[Numend] == 0x16)
                        {
                            break;
                        }
                        else
                        {
                            //接收到完整报文但是根据长度域对不上最后是16结束符------代表报文收到就是错误的

                            byte[] rcvByteError = readByteList.ToArray();
                            return "接收报文错误" + ConvertTool.ByteToString(rcvByteError);

                        }

                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    //接收到68和长度域但是还没有接收到全部报文，直接长度域计算会数组超限，循环回去接着从串口缓存区读数据
                    //由if (readByteList[Num698 + 1 + ctrlInt] == 0x16)抛出

                    continue;
                }
                catch (OperationCanceledException)
                {
                    //当超过一定时间未接收到数据时

                    //Console.WriteLine("Read operation canceled due to timeout.");
                    return "接收超时";
                }
            }
            byte[] rcvByte = readByteList.ToArray();
            return ConvertTool.ByteToString(rcvByte);

        }

        /// <summary>
        /// 645报文接收内容
        /// </summary>
        /// <param name="serialPort"></param>
        /// <returns></returns>
        private string Rcv645(SerialPort serialPort)
        {

            byte[] LenByte = new byte[1];
            List<byte> readByteList = new List<byte>();
            _cancellationTokenSource = new CancellationTokenSource(ti);
            while (true)
            {

                try
                {
                    if (_cancellationTokenSource.Token.IsCancellationRequested)
                    {

                        throw new OperationCanceledException();

                    }
                    int count = 0;
                    count = serialPort.BytesToRead;
                    byte[] readByte = new byte[count];
                    serialPort.Read(readByte, 0, count);
                    readByteList.AddRange(readByte);
                    NumStart = readByteList.IndexOf(0x68);

                    if (NumStart != -1)
                    {

                        NumStart = readByteList.IndexOf(0x68, NumStart + 1);

                    }
                    if (NumStart == -1 || readByteList[NumStart] != 0x68)
                    {

                        continue;

                    }
                    else
                    {

                        LenByte[0] = readByteList[NumStart + 2];
                        LenStr = ConvertTool.ByteToStringNoSpace(LenByte);
                        LenInt = Convert.ToInt32(LenStr, 16);
                        Numend = -1;
                        Numend = NumStart + 2 + LenInt + 2;
                        if (readByteList[Numend] == 0x16)
                        {

                            break;

                        }
                        else
                        {

                            byte[] rcvByteError = readByteList.ToArray();
                            return "接收报文错误" + ConvertTool.ByteToString(rcvByteError);

                        }


                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    //接收到68和长度域但是还没有接收到全部报文，直接长度域计算会数组超限，循环回去接着从串口缓存区读数据
                    //由if (readByteList[Num698 + 1 + ctrlInt] == 0x16)抛出

                    continue;
                }
                catch (OperationCanceledException)
                {
                    //当超过一定时间未接收到数据时

                    return "接收超时";
                }


            }
            byte[] rcvByte = readByteList.ToArray();

            return ConvertTool.ByteToString(rcvByte);
        }

        /// <summary>
        /// 主动接收功能
        /// </summary>
        /// <param name="serialPort"></param>

        public string OnlyRcv(SerialPort serialPort)
        {

            List<byte> readByteList = new List<byte>();
            byte[] LenByte = new byte[2];

            try
            {
                int count = 0;
                Thread.Sleep(100);
                count = serialPort.BytesToRead;
                byte[] readByte = new byte[count];
                serialPort.Read(readByte, 0, count);
                readByteList.AddRange(readByte);


                NumStart = readByteList.IndexOf(0x68);
                //接收较慢还没有接收到68------调转回去继续从串口缓存读




                LenByte[0] = readByteList[NumStart + 2];
                LenByte[1] = readByteList[NumStart + 1];
                LenStr = ConvertTool.ByteToStringNoSpace(LenByte);
                LenInt = Convert.ToInt32(LenStr, 16);
                Numend = -3;
                Numend = NumStart + 1 + LenInt;
                if (readByteList[Numend] == 0x16)
                {
                    byte[] rcvByte = readByteList.ToArray();
                    return ConvertTool.ByteToString(rcvByte);
                }
                else
                {
                    //接收到完整报文但是根据长度域对不上最后是16结束符------代表报文收到就是错误的

                    byte[] rcvByteError = readByteList.ToArray();
                    return "接收报文错误" + ConvertTool.ByteToString(rcvByteError);

                }



            }
            catch (ArgumentOutOfRangeException)
            {
                //接收到68和长度域但是还没有接收到全部报文，直接长度域计算会数组超限，循环回去接着从串口缓存区读数据
                //由if (readByteList[Num698 + 1 + ctrlInt] == 0x16)抛出
                return "报文错误";
            }

        }


        public void TimeOutSet(string timeOut)
        {
            if (timeOut != "")
            {
                ti = Int32.Parse(timeOut);
            }
            else
            {
                ti = 0;
            }

        }

    }
}

