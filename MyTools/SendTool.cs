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
        public  Mutex mutex = new Mutex();

        public int Num698 { get; set; } = -1;


        /// <summary>
        /// 带有帧校验的发送之后接收
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="txtSend"></param>
        /// <returns></returns>
        public Task<string> SendAndRcv698(SerialPort serialPort, string txtSend)
        {



            return Task.Run(async () =>
            {
                try
                {
                    mutex.WaitOne();

                    byte[] vs = ConvertTool.StringToByte(txtSend);

                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    serialPort.Write(vs, 0, vs.Length);
                    Thread.Sleep(100);
                    
                    //68是数组下标

                    List<byte> readByteList = new List<byte>();

                    #region 内嵌
                    while (true)
                    {




                        int count = 0;
                        Thread.Sleep(200);
                        count = serialPort.BytesToRead;
                        Console.WriteLine(count);
                        byte[] readByte = new byte[count];

                        serialPort.Read(readByte, 0, count);


                        readByteList.AddRange(readByte);



                        int ctrlInt;
                        string ctrlStr;
                        byte[] ctrlByte = new byte[2];



                        Num698 = readByteList.IndexOf(0x68);

                        Console.WriteLine(Num698);
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

                    return ConvertTool.ByteToString(vs1);

                }
                finally
                {

                    mutex.ReleaseMutex();
                }

            });




        }

        /// <summary>
        /// 645帧发送和接收带有帧完整性校验
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="txtSend"></param>
        /// <returns></returns>
        public  Task<string> SendAndRcv645(SerialPort serialPort, string txtSend)
        {

            return Task.Run(async () =>
            {
                try
                {
                    mutex.WaitOne();

                    byte[] vs = ConvertTool.StringToByte(txtSend);

                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    serialPort.Write(vs, 0, vs.Length);
                    Thread.Sleep(100);

                    //68是数组下标

                    List<byte> readByteList = new List<byte>();

                    #region 内嵌
                    while (true)
                    {

                        int count = 0;
                        Thread.Sleep(100);
                        count = serialPort.BytesToRead;
                        Console.WriteLine(count);
                        byte[] readByte = new byte[count];

                        serialPort.Read(readByte, 0, count);
                        readByteList.AddRange(readByte);



                        int ctrlInt;
                        string ctrlStr;
                        byte[] ctrlByte = new byte[1];



                        Num698 = readByteList.IndexOf(0x68);
                        if (Num698 != -1)
                            Num698 = readByteList.IndexOf(0x68, Num698 + 1);
                        Console.WriteLine(Num698);
                        #region 判断

                        if (readByteList[Num698] != 0x68)
                        {

                            continue;

                        }
                        else
                        {

                            ctrlByte[0] = readByteList[Num698 + 2];
                            ctrlStr = ConvertTool.ByteToStringNoSpace(ctrlByte);
                            ctrlInt = Convert.ToInt32(ctrlStr, 16);
                            int i = Num698 + 2 + ctrlInt + 2;
                            if (readByteList[i] == 0x16)
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

                    return ConvertTool.ByteToString(vs1);

                }
                finally
                {

                    mutex.ReleaseMutex();
                }

            });




        }

        /// <summary>
        /// 不区分645和698的发送和接收无帧完整性校验
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="txtSend"></param>
        /// <returns></returns>
        public static Task<string> EasySendAndRcv(SerialPort serialPort, string txtSend)
        {

            byte[] vs = ConvertTool.StringToByte(txtSend);
            return Task.Run(async () =>
            {

                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();

                serialPort.Write(vs, 0, vs.Length);
                await Task.Delay(100);
                int count = 0;
                await Task.Delay(100);
                count = serialPort.BytesToRead;
                if (count == 0)
                {
                    return "报文错误";
                }
                else
                {
                    byte[] readByte = new byte[count];
                    serialPort.Read(readByte, 0, count);
                    await Task.Delay(100);
                    return ConvertTool.ByteToString(readByte);
                }

            });

        }


    }

}

