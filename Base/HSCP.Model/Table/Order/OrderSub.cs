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
    /// 子订单表
    /// </summary>
    public partial class OrderSub : Entity<int>
    {
        /// <summary>
        /// 总订单号
        /// </summary>
        [Description("总订单号")]
        public virtual string BillNo { get; set; }
        /// <summary>
        /// 子订单编号
        /// </summary>
        [Description("子订单编号")]
        public virtual string BillItemNo { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        [Description("申请时间")]
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否主子订单   true  标示是总订单下的子订单  false 标示是补单的子订单 
        /// </summary>
        [Description("是否主子订单")]
        public virtual bool IsDefault { get; set; }

        /// <summary>
        /// 服务备注
        /// </summary>
        [Description("服务备注")]
        public virtual string ServiceRemark { get; set; }
        /// <summary>
        /// 补单类型
        /// </summary>
        [Description("补单类型")]
        public virtual OrderTypeEnum OrderType { get; set; }

        /// <summary>
        /// 订单金额  计算总的金额    
        /// </summary>
        [Description("订单金额")]
        public virtual decimal TotalAmount { get; set; }

        /// <summary>
        /// 修改之后的总金额  -  一般是和订单金额一样      
        /// </summary>
        [Description("修改之后的总金额")]
        public virtual decimal RealTotalAmount { get; set; }

        /// <summary>
        /// 服务开始时间
        /// </summary>
        [Description("服务开始时间")]
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 服务结束时间
        /// </summary>
        [Description("服务结束时间")]
        public virtual DateTime? EndTime { get; set; }
        /// <summary>
        /// 是否可选项(前台下单提交的) 
        /// </summary>
        [Description("可选项")]
        public virtual bool IsOptional { get; set; } = false;

    }
}