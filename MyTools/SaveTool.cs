using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools
{
    /// <summary>
    /// 保存成文件工具
    /// </summary>
    public class SaveTool
    {
        /// <summary>
        /// 以时间命名.text文件
        /// </summary>
        /// <param name="timeGet"></param>
        /// <returns></returns>
        public FileStream NameTimeSave(TimeGetTool timeGet) 
        {

            Directory.CreateDirectory(@"F:\TEXT");
            string fileName = "F:\\TEXT\\" + timeGet.FileTime() + ".txt";
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            return fs;
        }
    }
}
