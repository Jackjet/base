/****************************************************** 

    文件名称：Coupon.cs
    功能描述：券
    作    者：Jxw
    日    期：2016.05.18
    修改记录：

*******************************************************/
using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 券
    /// </summary>
    public class Coupon : Entity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual int CouponGroupId { get; set; }
        
        /// <summary>
        /// Key
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// 所属会员
        /// </summary>
        public virtual int? MemberId { get; set; }

        public virtual CouponState State { get; set; }

        public virtual string Remark { get; set; }
        /// <summary>
        /// 使用时间
        /// </summary>
        public virtual DateTime? UseTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public virtual DateTime? BindTime { get; set; }
    }
}