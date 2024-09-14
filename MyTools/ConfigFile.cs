using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyTools
{
    public static class ConfigFile
    {
        private const string CONFIG_FILE_NAME = "config.xml";

        /// <summary>
        /// 初始化文件
        /// </summary>
        public static void InitConfigFile()
        {

            string configFilePath = GetConfigFilePath();
            if (!File.Exists(configFilePath))
            {
                CreateDefaultConfigFile(configFilePath);
                //创建
            }
        }

        /// <summary>
        /// 获取Config.xml文件地址存放在系统根目录
        /// </summary>
        /// <returns></returns>
        private static string GetConfigFilePath()
        {
            string applicationPath = Directory.GetCurrentDirectory();
            string configFilePath = Path.Combine(applicationPath, CONFIG_FILE_NAME);
            return configFilePath;
        }

        /// <summary>
        /// 创建默认头部和默认数据内容
        /// </summary>
        /// <param name="filePath"></param>
        private static void CreateDefaultConfigFile(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();

            //头
            XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDecl);

            //根
            XmlElement root = xmlDoc.CreateElement("Config");
            xmlDoc.AppendChild(root);



            xmlDoc.Save(filePath);
            SaveData("波特率", "1200");
            SaveData("数据位", "5");
            SaveData("停止位", "1");
            SaveData("奇偶校验", "0-无校验");
            SaveData("自动发送TI", "100");
            SaveData("协议类型", "TCP Server");
            
        }

        /// <summary>
        /// 保存内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SaveData(string key, string value)
        {
            string configFilePath = GetConfigFilePath();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFilePath);

            XmlElement root = xmlDoc.DocumentElement;
            if (root == null)
            {
                root = xmlDoc.CreateElement("Config");
                xmlDoc.AppendChild(root);
            }

            XmlElement existingElement = xmlDoc.SelectSingleNode("//Config/Text[@Key='" + key + "']") as XmlElement;
            if (existingElement != null)
            {
                existingElement.InnerText = value;
            }
            else
            {
                // 创建子元素
                XmlElement textElement = xmlDoc.CreateElement("Text");
                textElement.SetAttribute("Key", key);
                textElement.InnerText = value;
                root.AppendChild(textElement);

            }

            xmlDoc.Save(configFilePath);

        }

        /// <summary>
        /// 加载config.xml中内容
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string LoadData(string key)
        {
            string configFilePath = GetConfigFilePath();
            if (!File.Exists(configFilePath)) return "";

            // 加载XML文档
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFilePath);

            // 获取根元素
            XmlNode rootNode = xmlDoc.SelectSingleNode("/Config");
            if (rootNode != null)
            {
                // 获取子元素
                XmlNode textNode = rootNode.SelectSingleNode("Text[@Key='" + key + "']");
                if (textNode != null)
                {
                    return textNode.InnerText;
                }
            }

            return "";
        }




    }
}
