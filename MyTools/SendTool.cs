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
        public Mutex mutex = new Mutex();

        public int Num698 { get; set; } = -1;

        private CancellationTokenSource _cancellationTokenSource;


        /// <summary>
        /// 带有帧校验的发送之后接收
        /// 优化了读取等待
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="txtSend"></param>
        /// <returns></returns>
        public Task<string> SendAndRcv698(SerialPort serialPort, string txtSend)
        {

            

            return Task.Run(() =>
           {
               try
               {
                   mutex.WaitOne();
                   _cancellationTokenSource = new CancellationTokenSource(5000);

                   byte[] vs = ConvertTool.StringToByte(txtSend);

                   serialPort.DiscardInBuffer();
                   serialPort.DiscardOutBuffer();
                   serialPort.Write(vs, 0, vs.Length);
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
                           //Thread.Sleep(200);
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
                           //接收较慢还没有接收到68------调转回去继续从串口缓存读

                           if (Num698 == -1 || readByteList[Num698] != 0x68)
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
                                       //接收到完整报文但是根据长度域对不上最后是16结束符------代表报文收到就是错误的

                                       byte[] rcvByteError = readByteList.ToArray();
                                       return "接收报文错误" + ConvertTool.ByteToString(rcvByteError);

                                   }
                               
                           }
                           #endregion
                       }
                       catch(ArgumentOutOfRangeException)
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
                       
                   }
                   #endregion
                   byte[] rcvByte = readByteList.ToArray();
                   
                   
                   return ConvertTool.ByteToString(rcvByte);
                   

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
        public Task<string> SendAndRcv645(SerialPort serialPort, string txtSend)
        {

            return Task.Run(() =>
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
                   byte[] rcvByte = readByteList.ToArray();

                   return ConvertTool.ByteToString(rcvByte);

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

