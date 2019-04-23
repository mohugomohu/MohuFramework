using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace MohuFramework.Common
{
    /// <summary>
    /// 生成静态页
    /// </summary>
    public class HtmlMaker
    {
        public static void Make(string source, string direction)
        {
            string fullPath = System.Web.HttpContext.Current.Request.Url.Authority;
            string url = "http://" + fullPath + source;
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream resStream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding("gb2312")))
                {
                    string result = sr.ReadToEnd();
                    using (StreamWriter sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(direction), false, Encoding.GetEncoding("gb2312")))
                    {
                        sw.Write(result);
                    }
                }
            }
        }
    }
}
