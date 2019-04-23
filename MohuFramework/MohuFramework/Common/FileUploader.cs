using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;

namespace MohuFramework.Common
{
    /// <summary>
    /// 用于上传的类
    /// </summary>
    public class FileUploader
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fu"></param>
        /// <returns></returns>
        public UploadResult UploadImages(FileUpload fu)
        {
            UploadResult ur = new UploadResult();
            try
            {
                bool allow = false;
                string now = DateTime.Now.ToString("yyyy-MM-dd");
                string fileExtension = System.IO.Path.GetExtension(fu.FileName).ToLower();
                string[] allowUploadImg = ConfigSettings.GetAllowUploadImageExtension();
                foreach (string s in allowUploadImg)
                {
                    if (s == fileExtension)
                    {
                        allow = true;
                        break;
                    }
                }
                if (!allow)
                {
                    ur.Result = false;
                    ur.Message = "上传的图片格式不正确";
                    return ur;
                }

                Random rnd = new Random();
                string name = now + rnd.Next(0, 9999).ToString("d4") + fileExtension;//图片名是日期加4位随机数
                string path = ConfigSettings.GetUploadImagesDir();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                fu.PostedFile.SaveAs(path + name);
                ur.Result = true;
                ur.FileName = name;
                ur.Message = "上传成功";
                return ur;
            }
            catch (Exception ex)
            {
                ur.Message = "上传出现异常||" + ex.Message;
                ur.Result = false;
                return ur;
            }
        }
    }

    /// <summary>
    /// 上传结果
    /// </summary>
    public struct UploadResult
    {
        private bool result ;
        private string name;
        private string msg ;
        public string Message
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }
        public bool Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }
        public string FileName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
}
