/*
 * 作者：Ldw    
 * 日期：2016.06.20
 * 描述：渠道管理
 * 修改记录：    
 * */
using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 渠道优惠卷
    /// </summary>
    public class ChanneRelevancy : Entity<int>
    {
        /// <summary>
        /// 渠道id
        /// </summary>
        public virtual int ChannelId { get; set; }
        /// <summary>
        /// 券批次id
        /// </summary>
        public virtual int CouponGroupId { get; set; }

        /// <summary>
        /// 单人单次发放量
        /// </summary>
        public virtual int Number { get; set; }
        /// <summary>
        /// 单人发放总量上限
        /// </summary>
        public virtual int Total { get; set; }

    }
}