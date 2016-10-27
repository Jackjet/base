/*
 * 作者：Ldw    
 * 日期：2016.07.27 
 * 描述：充值奖励
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 充值奖励
    /// </summary>
    public class GiftRechargeGive : Entity<int>
    {
        /// <summary>
        /// 充值金额
        /// </summary>
        [Description("充值金额")]
        public virtual decimal Amount { get; set; }
        /// <summary>
        /// 充值礼品Id
        /// </summary>
        [Description("充值礼品Id")]
        public virtual int GiftRechargeId { get; set; }
        /// <summary>
        /// 奖品
        /// </summary>
        [Description("奖品")]
        public virtual string Prize { get; set; }
        /// <summary>
        /// 奖品类型
        /// </summary>
        [Description("奖品类型")]
        public virtual GiftRechargeTypeEnum PrizeType { get; set; }

    }
}