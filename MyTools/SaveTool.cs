using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools
{


    public class SaveTool
    {
        /// <summary>
        /// 以时间命名.text文件
        /// </summary>
        /// <param name="timeGet"></param>
        /// <returns></returns>
        public static FileStream NameTimeSave() 
        {
            string s = Directory.GetCurrentDirectory();
            Directory.CreateDirectory($@"{s}\TEXT");
            string fileName = s+"\\TEXT\\" + TimeGetTool.FileTime() + ".txt";
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            return fs;
        }
    }
}
