/*
 * 作者：Ldw    
 * 日期：2016.07.27 
 * 描述：充值送礼
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 充值送礼
    /// </summary>
    public class GiftRecharge : Entity<int>
    {
        /// <summary>
        /// 活动名称
        /// </summary>
        [Description("活动名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 开始有效期
        /// </summary>
        [Description("开始有效期")]
        public virtual DateTime StartValidity { get; set; }
        /// <summary>
        /// 结算有效期
        /// </summary>
        [Description("结算有效期")]
        public virtual DateTime EndValidity { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public virtual GiftRechargeEnum State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }

    }
}