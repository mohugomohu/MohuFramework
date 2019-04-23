using System;
using System.Collections.Generic;
using System.Text;

namespace MohuFramework.Common
{
    public class JavaScript
    {
        /// <summary>
        /// 弹出对话框
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void Alert(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "",
            "<script>alert(\"" + msg + "\")</script>");
        }
        /// <summary>
        /// 弹出对话框并跳转
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        /// <param name="redirect"></param>
        public static void Alert(System.Web.UI.Page page, string msg, string redirect)
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "",
            "<script>alert(\"" + msg + "\");location='" + redirect + "';</script>");
        }
    }
}
