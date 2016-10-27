//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 订单退款
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
    /// 订单退款
    /// </summary>
    public partial class OrderTk : Entity<int>
    {
      

        /// <summary>
        /// 总订单号
        /// </summary>
        [Description("总订单号")]
        public virtual string BillNo { get; set; }


    


        /// <summary>
        /// 发生金额             
        /// </summary>
        [Description("发生金额")]
        public virtual decimal ChangeAmount { get; set; }



        /// <summary>
        /// 人员编号 
        /// </summary>
        [Description("人员编号")]
        public virtual string    SNo { get; set; }


        /// <summary>
        /// 操作人
        /// </summary>
        [Description("操作人")]
        public virtual string Developer { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Description("操作时间")]
        public virtual DateTime? CreDateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }



        /// <summary>
        /// 人员类型  1  会员  2  员工 
        /// </summary>
        [Description("人员类型")]
        public virtual int SType { get; set; }


        #region 退款反馈

        /// <summary>
        /// 退款状态
        /// </summary>
        [Description("退款状态")]
        public virtual Refundstatus Refundstatusstr { get; set; } = Refundstatus.未退款;


        /// <summary>
        /// 退款方式
        /// </summary>
        [Description("退款方式")]
        public virtual RefundType RefundTypestr { get; set; } = 0;



        /// <summary>
        /// 到账时间
        /// </summary>
        [Description("到账时间")]
        public virtual DateTime? Paymentdate { get; set; }



        /// <summary>
        /// 操作人 退款反馈
        /// </summary>
        [Description("操作人")]
        public virtual string Operator { get; set; }

        /// <summary>
        /// 操作时间 退款反馈
        /// </summary>
        [Description("操作时间")]
        public virtual DateTime? OperatorTime { get; set; }

        #endregion


    }
}