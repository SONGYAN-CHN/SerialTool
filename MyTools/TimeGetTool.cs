using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools
{
    public class TimeGetTool
    {
        private DateTime dateTime;
        public string TextTime()
        {
            dateTime = DateTime.Now;
            string strDataTime = dateTime.ToString("[yyyy-MM-dd HH:mm:ss]:");
            return strDataTime;
        }
        public string FileTime()
        {
            dateTime = DateTime.Now;
            string strDataTime = dateTime.ToString("yyyyMMddHHmmss");
            return strDataTime;
        }
    }
}
