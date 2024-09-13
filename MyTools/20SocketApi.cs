using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MyTools
{
    public static class _20SocketApi
    {
        //static TcpClientHelper client = new TcpClientHelper();
        #region 会话协商
        public static string ObjMeterFormalInitSession(int iKeyState, string cDiv, string cASCTR,TcpClientHelper client)
        {
            Dictionary<string, int> dicttemp = new Dictionary<string, int>()
            {
                {"iKeyState", iKeyState}
            };

            Dictionary<string, string> dicttemp2 = new Dictionary<string, string>()
            {
                { "cTESAMID", cDiv},
                { "cASCTR", cASCTR },

            };
            string json = $"{JsonConvert.SerializeObject(dicttemp)}{JsonConvert.SerializeObject(dicttemp2)}".Replace("}{", ",");
            return client.Send($"ObjMeterFormalInitSession  {json}\r\n");

        }
        #endregion
    }
}
