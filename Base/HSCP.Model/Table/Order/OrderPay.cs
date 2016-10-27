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
using Conan.Core;
using System;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 订单支付
    /// </summary>
    public class OrderPay : Entity<int>
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        [Description("订单编号")]
        public virtual string BillNo { get; set; }


        /// <summary>
        /// 交易编号
        /// </summary>
        [Description("交易编号")]
        public virtual string TraNumber { get; set; }

        /// <summary>
        /// 消费方式
        /// </summary>
        [Description("消费方式")]
        public virtual PayTypes PayType { get; set; }


        /// <summary>
        /// 交易类型
        /// </summary>
        [Description("交易类型")]
        public virtual Transaction? TransactionType { get; set; }

        


        /// <summary>
        /// 支付金额 实付
        /// </summary>
        [Description("支付金额")]
        public virtual decimal PayValue { get; set; }



        /// <summary>
        /// 支付时间
        /// </summary>
        [Description("支付时间")]
        public virtual DateTime? PayTime { get; set; }


        /// <summary>
        /// 入账时间
        /// </summary>
        [Description("入账时间")]
        public virtual DateTime? AccountedTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Description("操作人")]
        public virtual string PayUser { get; set; }

        #region 优惠券 PayType=优惠券

        /// <summary>
        /// 优惠券id
        /// </summary>
        [Description("优惠券id")]
        public virtual int? CouponId { get; set; }
        /// <summary>
        /// 优惠券名称 /第三方交易号
        /// </summary>
        [Description("优惠券名称")]
        public virtual string CouponName { get; set; }

        /// <summary>
        /// 优惠券面值
        /// </summary>
        [Description("优惠券面值")]
        public virtual decimal? FaceValue { get; set; }
        #endregion


        /// <summary>
        /// 交易对象
        /// </summary>
        [Description("交易对象")]
        public virtual string Transactionobject { get; set; }


    }
}
