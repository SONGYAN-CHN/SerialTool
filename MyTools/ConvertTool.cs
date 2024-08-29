using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools
{
    public class ConvertTool
    {

        /// <summary>
        /// String转byte数组
        /// </summary>
        /// <param name="txtSend"></param>
        /// <returns></returns>
        public static byte[] StringToByte(string txtSend)
        {
            List<byte> sendByteList = new List<byte>();
            txtSend = txtSend.Replace(" ", "");
            int len = txtSend.Length / 2;
            for (int i = 0; i < len; i++)
            {
                try
                {
                    sendByteList.Add(Convert.ToByte(Convert.ToInt32(txtSend.Substring(i * 2, 2), 16)));
                }catch
                {
                    
                    return new byte[0];
                }
            }
            return sendByteList.ToArray();
            
        }

        /// <summary>
        /// byte数组转string
        /// </summary>
        /// <param name="readByte"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] readByte)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i=0;i<readByte.Length;i++)
            {
                stringBuilder.Append(readByte[i].ToString("X").PadLeft(2, '0') + " ");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// byte数组转string中间无空格
        /// </summary>
        /// <param name="readByte"></param>
        /// <returns></returns>
        public static string ByteToStringNoSpace(byte[] readByte)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < readByte.Length; i++)
            {
                stringBuilder.Append(readByte[i].ToString("X").PadLeft(2, '0') );
            }
            return stringBuilder.ToString();
        }
    }
}
