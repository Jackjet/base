using System;
using System.Text;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
    public partial class Payment : Entity<int>
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        [Description("客户编号")]
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号id")]
        public virtual string OrderNo { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Description("金额")]
        public virtual decimal Amount { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        [Description("赠送金额")]
        public virtual decimal? GivingAmount { get; set; } = 0;


        /// <summary>
        /// 操作人id  员工id  会员操作 为空 
        /// </summary>
        [Description("操作人id")]
        public virtual int? CreEid { get; set; } 



        /// <summary>
        /// 汇款类型-  1：个人   2：企业
        /// </summary>
        [Description("汇款类型")]
        public virtual int SendType { get; set; }
        /// <summary>
        /// 来源-支付方式 - Conan.Model.MethodPaymentEnum
        /// </summary>
        [Description("来源-支付方式")]
        public virtual int PaymentChannel { get; set; }
        /// <summary>
        /// 来源-支付方式
        /// </summary>
        [Description("来源-支付方式")]
        public virtual string PaymentChannelName { get; set; }
        /// <summary>
        /// 客户银行
        /// </summary>
        [Description("客户银行")]
        public virtual string CustomerBank { get; set; }
        /// <summary>
        /// 客户账号
        /// </summary>
        [Description("客户账号")]
        public virtual string CustomerAccount { get; set; }
        /// <summary>
        /// 收款账号
        /// </summary>
        [Description("收款账号")]
        public virtual string MyAccount { get; set; }
        /// <summary>
        /// 到帐银行
        /// </summary>
        [Description("到帐银行")]
        public virtual string MyBank { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        [Description("交易号")]
        public virtual string TradingCode { get; set; }
        /// <summary>
        /// 我方发起的交易号
        /// </summary>
        [Description("我方发起的交易号")]
        public virtual string MyTradingCode { get; set; }
        /// <summary>
        /// 交易状态
        /// </summary>
        [Description("交易状态")]
        public virtual PaymentStatusEnum PaymentStatus { get; set; }
        /// <summary>
        /// 是否由客户发起
        /// </summary>
        [Description("是否由客户发起")]
        public virtual bool IsByCustomer { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        [Description("支付时间")]
        public virtual DateTime? PayTime { get; set; }
        /// <summary>
        /// 凭证图片
        /// </summary>
        [Description("凭证图片")]
        public virtual string Img { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 持卡人名字
        /// </summary>
        [Description("持卡人名字")]
        public virtual string CustomerName { get; set; }

        /// <summary>
        /// 凭证
        /// </summary>
        [Description("凭证")]
        public virtual string Credentials { get; set; }

        /// <summary>
        /// 是否开票  0：未开票 1：已开票
        /// </summary>
        [Description("是否开票")]
        public virtual int IsInvoice { get; set; }

        ///// <summary>
        ///// 获取随机码
        ///// </summary>
        ///// <returns></returns>
        //public string GenTopUpCode()
        //{
        //    var s = Id.ToString();
        //    var sb = new StringBuilder();
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (Char.IsNumber(s, i))
        //        {
        //            sb.Append(s.Substring(i, 1));
        //        }
        //    }
        //    string code = DateTime.Now.ToString("yyyyMMddHHmmss") + sb.ToString();
        //    if (code.Length > 18)
        //    {
        //        code = code.Substring(0, 18);
        //    }
        //    return code;
        //}
    }
}