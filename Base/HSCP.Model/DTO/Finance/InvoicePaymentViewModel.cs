/*
 * 作者：Ldw    
 * 日期：2016.05.23  
 * 描述：资金流水
 * 修改记录：    
 * */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 资金表实体
    /// </summary>
    [NotMapped]

    public class InvoicePaymentViewModel 
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public virtual int MemberId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public virtual decimal Amount { get; set; }
        /// <summary>
        /// 汇款类型-  1：个人   2：企业
        /// </summary>
        public virtual int SendType { get; set; }
        /// <summary>
        /// 来源-支付方式 -0：现金 1：银行转账 2:pos机 3：支付宝 4：微信 5:银联
        /// </summary>
        public virtual int PaymentChannel { get; set; }
        /// <summary>
        /// 来源-支付方式
        /// </summary>
        public virtual string PaymentChannelName { get; set; }
        /// <summary>
        /// 客户银行
        /// </summary>
        public virtual string CustomerBank { get; set; }
        /// <summary>
        /// 客户账号
        /// </summary>
        public virtual string CustomerAccount { get; set; }
        /// <summary>
        /// 收款账号
        /// </summary>
        public virtual string MyAccount { get; set; }
        /// <summary>
        /// 到帐银行
        /// </summary>
        public virtual string MyBank { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public virtual string TradingCode { get; set; }
        /// <summary>
        /// 我方发起的交易号
        /// </summary>
        public virtual string MyTradingCode { get; set; }
        /// <summary>
        /// 交易状态
        /// </summary>
        public virtual PaymentStatusEnum PaymentStatus { get; set; }
        /// <summary>
        /// 是否由客户发起
        /// </summary>
        public virtual bool IsByCustomer { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public virtual DateTime? PayTime { get; set; }
        /// <summary>
        /// 凭证图片
        /// </summary>
        public virtual string Img { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        public virtual string CreateTime { get; set; }

        /// <summary>
        /// 持卡人名字
        /// </summary>
        public virtual string CustomerName { get; set; }

        /// <summary>
        /// 凭证
        /// </summary>
        public virtual string Credentials { get; set; }

        /// <summary>
        /// 是否开票  0：未开票 1：已开票
        /// </summary>
        public virtual int IsInvoice { get; set; }
    }

}
