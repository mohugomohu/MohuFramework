using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace MohuFramework.Common
{
    public class ConfigSettings
    {
        /// <summary>
        /// 图片上传目录的物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetUploadImagesDir()
        {
            string dir = GetVirsualUploadImagesDir();
            return System.Web.HttpContext.Current.Server.MapPath(dir);
        }

        /// <summary>
        /// 图片上传虚拟目录
        /// <add key="UploadImagePath" value="/upload/images/"/>
        /// </summary>
        /// <returns></returns>
        public static string GetVirsualUploadImagesDir()
        {
            XmlDocument xml = GetXmlConfig();
            XmlNode value = xml.SelectSingleNode("Configuration/AppSettings/UploadImagePath");
            string dir = "~" + value.InnerText;
            return dir;
        }

        /// <summary>
        /// 图片上传虚拟目录，不带"~"
        /// <add key="UploadImagePath" value="/upload/images/"/>
        /// </summary>
        /// <returns></returns>
        public static string GetVirsualUploadImagesDir2()
        {
            XmlDocument xml = GetXmlConfig();
            XmlNode value = xml.SelectSingleNode("Configuration/AppSettings/UploadImagePath");
            return value.InnerText;
        }

        /// <summary>
        /// 允许上传的图片格式
        /// <add key="AllowUploadImageExtension" value=".jpg,.png,.jpeg,.gif,.bmp"/>
        /// </summary>
        /// <returns></returns>
        public static string[] GetAllowUploadImageExtension()
        {
            XmlDocument xml = GetXmlConfig();
            XmlNode value = xml.SelectSingleNode("Configuration/AppSettings/AllowUploadImageExtension");
            string str = value.InnerText;
            return str.Split(new char[] { ',' });
        }

        /// <summary>
        /// 获取后台登录页面地址
        /// </summary>
        /// <returns></returns>
        public static string GetAdminLoginUrl()
        {
            XmlDocument xml = GetXmlConfig();
            XmlNode value = xml.SelectSingleNode("Configuration/AppSettings/AdminLoginUrl");
            string str = value.InnerText;
            return str;
        }

        //当前运行路径
        private static string GetCurrentPath()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            return path;
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            XmlDocument xml = GetXmlConfig();
            XmlNode conn = xml.SelectSingleNode("Configuration/ConnectionString");
            return conn.InnerText;
        }

        private static XmlDocument GetXmlConfig()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(GetCurrentPath() + "MohuFrameworkConfig.xml");
            return xml;
        }
    }
}
