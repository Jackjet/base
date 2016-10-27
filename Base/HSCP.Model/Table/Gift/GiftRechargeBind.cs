/*
 * 作者：Ldw    
 * 日期：2016.08.04 
 * 描述：充值送礼活动记录
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 充值送礼活动记录
    /// </summary>
    public class GiftRechargeBind : Entity<int>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        [Description("会员账号")]
        public virtual string  Account { get; set; }
        /// <summary>
        /// 会员电话号码
        /// </summary>
        [Description("会员电话号码")]
        public virtual string Phone { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        [Description("充值金额")]
        public virtual decimal Amount { get; set; }
        /// <summary>
        /// 赠送类型
        /// </summary>
        [Description("赠送类型")]
        public virtual GiveGifTypeEnum GiveType { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        [Description("赠送金额")]
        public virtual decimal GiveAmount { get; set; }
        /// <summary>
        /// 赠送礼品
        /// </summary>
        [Description("赠送礼品")]
        public virtual string GiveGift { get; set; }
        /// <summary>
        /// 活动Id
        /// </summary>
        [Description("活动Id")]
        public virtual int GiftRechargeId { get; set; }
        /// <summary>
        /// 会员id
        /// </summary>
        [Description("会员id")]
        public virtual int MemberId { get; set; }
    }
}