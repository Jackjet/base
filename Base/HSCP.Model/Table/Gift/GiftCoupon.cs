/*
 * 作者：Ldw    
 * 日期：2016.07.26  
 * 描述：礼品管理优惠卷关联表
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 礼品优惠券
    /// </summary>
    public class GiftCoupon : Entity<int>
    {
        /// <summary>
        /// 礼品Id
        /// </summary>
        [Description("礼品Id")]
        public virtual int GiftId { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        [Description("有效期")]
        public virtual string Validity { get; set; }
        /// <summary>
        /// 发放数量
        /// </summary>
        [Description("发放数量")]
        public virtual int Number { get; set; }
        /// <summary>
        /// 优惠卷批次Id
        /// </summary>
        [Description("优惠卷批次Id")]
        public virtual int CouponId { get; set; }
        
    }
}