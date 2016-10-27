/*
 * 作者：cyx    
 * 日期：2016.06.08  
 * 描述：财务入款汇总
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 财务入款汇总
    /// </summary>
    public class PayMenthViewModel
    {
        /// <summary>
        /// 来源-支付方式 -0：现金 1：银行转账 2:pos机 3：支付宝 4：微信 5:银联
        /// </summary>
        public virtual string PaymentChannelName { get; set; }
        /// <summary>
        /// 入款金额
        /// </summary>
        public virtual decimal Amount { get; set; }
    }
}
