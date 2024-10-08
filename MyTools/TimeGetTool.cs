﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools
{
    public static class TimeGetTool
    {
        private static DateTime dateTime;

        /// <summary>
        /// 保存内容中的时间戳
        /// </summary>
        /// <returns></returns>
        public static string TextTime()
        {
            dateTime = DateTime.Now;
            string strDataTime = dateTime.ToString("[yyyy-MM-dd HH:mm:ss]:");
            return strDataTime;
        }

        /// <summary>
        /// 文件以时间命名
        /// </summary>
        /// <returns></returns>
        public static string FileTime()
        {
            dateTime = DateTime.Now;
            string strDataTime = dateTime.ToString("yyyyMMddHHmmss");
            return strDataTime;
        }
    }
}
