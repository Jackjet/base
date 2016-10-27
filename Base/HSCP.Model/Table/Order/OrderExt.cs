//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单扩展
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
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
    /// 订单扩展
    /// </summary>
    public partial class OrderExt : Entity<int>
    {

        /// <summary>
        /// 订单标签
        /// </summary>
               public virtual string LblId { get; set; }

        /// <summary>
        /// 总订单号
        /// </summary>
        [Description("总订单号")]
        public virtual string BillNo { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public virtual string  CrePerson { get; set; }


        /// <summary>
        /// 是否瞒报
        /// </summary
        [Description("是否瞒报")]
        public virtual bool? IsMb { get; set; }


    }
}