/*
 * 作者：cyx    
 * 日期：2016.06.15  
 * 描述：财务入款汇总-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 财务入款汇总-过滤条件
    /// </summary>
    public class PayMenthOption
    {
        /// <summary>
        /// 来源-支付方式 -0：现金 1：银行转账 2:pos机 3：支付宝 4：微信 5:银联
        /// </summary>
        public virtual MethodPaymentEnum? PaymentChannel { get; set; }
        /// <summary>
        /// 入款开始时间
        /// </summary>

        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 入款结束时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// 隐藏的input判断是否是第一次
        /// </summary>
        public virtual int firstselect { get; set; } = 0;


    }
}
