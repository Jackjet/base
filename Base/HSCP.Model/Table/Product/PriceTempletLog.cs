//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：价格模板操作日志
//数据表(Tables)：    
//作者(Author)： xrp
//日期(Create Date)： 2016.06.13
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 价格模板操作日志
    /// </summary>
    public partial class PriceTempletLog : Entity<int>
    {


        /// <summary>
        /// 操作时间
        /// </summary>
        [Description("操作时间")]
        public DateTime? CreateTime {set;get;}


        /// <summary>
        /// 操作者
        /// </summary>
        [Description("操作者")]
        public virtual string Operator { get; set; }

        /// <summary>
        /// 操作者id
        /// </summary>
        [Description("操作者id")]
        public virtual int OperatorId { get; set; }

        /// <summary>
        /// ip 地址
        /// </summary>
        [Description("ip 地址")]
        public virtual string IP { get; set; }


        /// <summary>
        /// 操作标题
        /// </summary>
        [Description("操作标题")]
        public string Title {set;get;}
        /// <summary>
        /// 操作内容
        /// </summary>
        [Description("操作内容")]
        public string Message {set; get;}
        /// <summary>
        /// 价格模板编号
        /// </summary>
        [Description("价格模板编号")]
        public int PriceTempletId {set;get;}
     

    }
}