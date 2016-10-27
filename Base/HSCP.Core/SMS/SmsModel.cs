//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：短信发送模型
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016‎.‎06‎.27
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    /// <summary>
    /// 短信发送模型
    /// </summary>
    public class SmsModel
    {
        public string TemplateName { get; set; }
        public string Receiver { get; set; }
        public Dictionary<string, string> Parameter { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Random { get; set; }
    }

    public class SmsMsg
    {
        public string Receiver { get; set; }

        public string TplName { get; set; }

        public Dictionary<string, string> Keyvals { get; set; }
    }

    public class WxMsg
    {
        public string Receiver { get; set; }

        public string TplName { get; set; }

        public Dictionary<string, string> Keyvals { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }
    }
}
