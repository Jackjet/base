/*
 * 作者：Ldw    
 * 日期：2016.07.27 
 * 描述：充值送礼比例
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 充值送礼比例
    /// </summary>
    public class GiftRechargeThan : Entity<int>
    {
        /// <summary>
        /// 活动Id
        /// </summary>
        [Description("活动Id")]
        public virtual int GiftRechargeId { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        [Description("最小值")]
        public virtual decimal Min { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        [Description("最大值")]
        public virtual decimal Max { get; set; }
        
        /// <summary>
        /// 比例
        /// </summary>
        [Description("比例")]
        public virtual decimal Proportion { get; set; }
    }
}