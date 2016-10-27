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
    /// 订单（拒绝/ 取消）操作表  
    /// </summary>
    public partial class OrderRejectCancel : Entity<int>
    {

        /// <summary>
        /// 订单状态  （总订单状态）
        /// </summary>
        [Description("订单状态")]
        public virtual OrderStateEnum OrderState { get; set; }

        /// <summary>
        /// 总订单号
        /// </summary>
        [Description("总订单号")]
        public virtual string BillNo { get; set; }


        /// <summary>
        /// 操作时间
        /// </summary>
        [Description("操作时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 操作人编号
        /// </summary>
        [Description("操作人编号")]
        public virtual string OpId { get; set; }


        /// <summary>
        /// 操作人名称
        /// </summary>
        [Description("操作人名称")]
        public virtual string OpName { get; set; }


        /// <summary>
        /// 操作人类型  1  会员   2  员工  
        /// </summary>
        [Description("操作人类型")]
        public virtual int? OpType { get; set; }




        /// <summary>
        /// 发起人  字典
        /// </summary>
        [Description("发起人")]
        public virtual string Promoter { get; set; }


        /// <summary>
        /// 操作备注
        /// </summary>
        [Description("操作备注")]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 原因 字典
        /// </summary>
        [Description("原因")]
        public virtual string Reason { get; set; }
        /// <summary>
        /// 退款
        /// </summary>
        public virtual decimal? Amount { get; set; }


    }
}