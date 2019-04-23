using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.IO;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data;

namespace MohuFramework.Common
{
    public class Utils
    {
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncryptByMd5(string str)
        {
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("x");
            }
            return pwd;
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncryptByMd5_2(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
        }

        /// <summary>
        /// 删除上传的图片
        /// </summary>
        /// <param name="str"></param>
        public static void DeleteImage(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                string path = MohuFramework.Common.ConfigSettings.GetUploadImagesDir() + str;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="title"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string SubTitle(string title, int count)
        {
            if (string.IsNullOrEmpty(title))
            {
                title = "";
            }
            else if (title.Length > count)
            {
                title = title.Substring(0, count);
            }
            return title;
        }

        /// <summary>
        /// 无图片时显示默认图片
        /// </summary>
        /// <param name="image"></param>
        /// <param name="defaultImage"></param>
        /// <returns></returns>
        public static string ShowDefaultImage(object image, string defaultImage)
        {
            string result = Convert.ToString(image);
            if (string.IsNullOrEmpty(result))
            {
                result = defaultImage;
            }
            return result;
        }

        /// <summary>
        /// 过滤单引号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterQuote(string str)
        {
            str = str.Replace("'", "\"");
            return str;
        }

        /// <summary>
        /// 过滤尖括号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterString(string str)
        {
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = FilterQuote(str);
            return str;
        }

        /// <summary>
        /// 验证字符串是否有非法字符。合法为true
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool CheckString(params string[] arr)
        {
            bool result = true;
            foreach (string s in arr)
            {
                if (s.IndexOf("<") != -1 || s.IndexOf(">") != -1)
                {
                    result = false;
                }
                if (Regex.IsMatch(s, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']"))
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// 检查文本框中是否有非法字符，如果有则返回该文本框
        /// </summary>
        /// <param name="page"></param>
        /// <param name="formId"></param>
        /// <returns></returns>
        public static TextBox CheckTheTextBox(System.Web.UI.Page page, string formId)
        {
            TextBox result = null;
            TextBox temp = new TextBox();
            foreach (System.Web.UI.Control c in page.FindControl(formId).Controls)
            {
                if (c.GetType() == temp.GetType())
                {
                    TextBox txt = ((TextBox)c);
                    string text = txt.Text;
                    if (!Utils.CheckString(text))
                    {
                        result = txt;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            string htext = "";

            for (int i = 0; i < str.Length; i++)
            {
                htext = htext + (char)(str[i] + 10 - 1 * 2);
            }
            return htext;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decode(string str)
        {
            string dtext = "";

            for (int i = 0; i < str.Length; i++)
            {
                dtext = dtext + (char)(str[i] - 10 + 1 * 2);
            }
            return dtext;
        }
    }
}
