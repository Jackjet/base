using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 支付提交
    /// </summary>
    public class PayAddModel
    {
        /// <summary>
        /// 总订单号
        /// </summary>
        public virtual string BillNo { get; set; }

        /// <summary>
        /// 字符串 123,456
        /// </summary>
        public virtual string BillItemNo { get; set; }


        /// <summary>
        /// 会员id
        /// </summary>
        public virtual int MemberId { get; set; }

        /// <summary>
        /// 交易编号
        /// </summary>
        public virtual string TraNumber { get; set; }

        /// <summary>
        /// 优惠券
        /// </summary>
        public virtual int Cid { get; set; }

        /// <summary>
        /// 第三方类型
        /// </summary>
        public virtual int Ttype { get; set; }

        /// <summary>
        /// 第三方金额
        /// </summary>
        public virtual string DKValue { get; set; }

        /// <summary>
        /// 第三方交易号
        /// </summary>
        public virtual string TTraMenber { get; set; }

        /// <summary>
        /// 余额支付
        /// </summary>
        public virtual string Fvalue { get; set; }

        /// <summary>
        /// 是否使用余额支付
        /// </summary>
        public virtual int IsUser { get; set; }

    }
}
