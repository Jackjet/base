//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单相关表
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
    /// 拆单关联表
    /// </summary>
    public partial class OrderSplit : Entity<int>
    {
        /// <summary>
        /// 源订单号  （集团订单号）
        /// </summary>
        [Description("源订单号")]
        public virtual string SourceBillNo { get; set; }


        /// <summary>
        /// 目标订单号   （拆单之后的订单号）
        /// </summary>
        [Description("目标订单号")]
        public virtual string TargetBillNo { get; set; }

    }
}