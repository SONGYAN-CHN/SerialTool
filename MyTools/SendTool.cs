﻿using System;
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

        public int NumStart { get; set; } = -1;
        public int Numend { get; set; } = -1;

        public int LenInt { get; set; }
        public string LenStr { get; set; }


        private CancellationTokenSource _cancellationTokenSource;



        public Task<string> SendAndRcv(SerialPort serialPort, string txtSend)
        {
            return Task.Run(() =>
            {


                byte[] textSendByte = ConvertTool.StringToByte(txtSend);
                if (Is698Or645(textSendByte) == 1)
                {
                    return SendAndRcv698(serialPort, textSendByte);
                }
                else if (Is698Or645(textSendByte) == 2)
                {
                    return SendAndRcv645(serialPort, textSendByte);
                }
                else
                {
                    return "报文错误";
                }

            });
        }

        private int Is698Or645(byte[] textSendByte)
        {
            int StartCount = 0;
            foreach (int starBit in textSendByte)
            {
                if (starBit == 0x68)
                    StartCount++;
            }
            return StartCount;

        }




        /// <summary>
        /// 带有帧校验的发送之后接收
        /// 优化了读取等待
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="txtSend"></param>
        /// <returns></returns>
        public string SendAndRcv698(SerialPort serialPort, byte[] textSendByte)
        {


            byte[] LenByte = new byte[2];

            try
            {

                mutex.WaitOne();
                _cancellationTokenSource = new CancellationTokenSource(5000);



                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Write(textSendByte, 0, textSendByte.Length);
                Thread.Sleep(100);


                List<byte> readByteList = new List<byte>();

                #region 内嵌

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

                        #region 判断
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
                        #endregion
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
                #endregion
                byte[] rcvByte = readByteList.ToArray();


                return ConvertTool.ByteToString(rcvByte);


            }

            finally
            {
                mutex.ReleaseMutex();
            }






        }


        /// <summary>
        /// 645帧发送和接收带有帧完整性校验
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="txtSend"></param>
        /// <returns></returns>
        public string SendAndRcv645(SerialPort serialPort, byte[] textSendByte)
        {
            byte[] LenByte = new byte[1];


            try
            {
                mutex.WaitOne();
                _cancellationTokenSource = new CancellationTokenSource(5000);

                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Write(textSendByte, 0, textSendByte.Length);
                Thread.Sleep(100);

                //68是数组下标

                List<byte> readByteList = new List<byte>();

                #region 内嵌
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
                        if (NumStart != -1)
                            NumStart = readByteList.IndexOf(0x68, NumStart + 1);
                        #region 判断

                        if (NumStart == -1 || readByteList[NumStart] != 0x68)
                        {

                            continue;

                        }
                        else
                        {

                            LenByte[0] = readByteList[NumStart + 2];
                            LenStr = ConvertTool.ByteToStringNoSpace(LenByte);
                            LenInt = Convert.ToInt32(LenStr, 16);
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

                        Console.WriteLine("Read operation canceled due to timeout.");
                        return null;
                    }


                    #endregion

                }
                #endregion
                byte[] rcvByte = readByteList.ToArray();

                return ConvertTool.ByteToString(rcvByte);

            }
            finally
            {

                mutex.ReleaseMutex();
            }



        }






    }

}

