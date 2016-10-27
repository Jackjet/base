using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Conan.Utils
{
    public partial class CreateFile
    {
        /// <summary>
        /// 生成html文件
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="savePath">保存的文件路径</param>
        /// <param name="filePath">文件名</param>
        /// <returns></returns>
        public static string Html(string str, string savePath,string filePath)
        {
            try
            {
                var saveBase =Path.Combine(savePath,filePath+".html");
                string filepath = savePath;   //要上传的文件夹的路径
                if (!Directory.Exists(filepath))  //不存在文件夹，创建
                {
                    Directory.CreateDirectory(filepath);  //创建新的文件夹
                }
                //文件名称是用户名_时间随机数，放在filepath文件夹中
                string filename = saveBase;
                FileStream fs = File.Create(filename);  //创建文件
                fs.Close();
                StreamWriter sw = new StreamWriter(filename, true, System.Text.Encoding.GetEncoding("UTF-8"));  //创建写入流
                sw.Write(str);
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {

                return e.Message;
            }
            return "";
        }
    }
}
