using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 历史订单列表实体
    /// </summary>
    [NotMapped]

    public class MemberCouponViewModel : Coupon
    {

        #region CouponGroup Info

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 有效期（天）
        /// </summary>
        public virtual int? Validity { get; set; }
        /// <summary>
        /// 面值
        /// </summary>
        public virtual decimal? FaceValue { get; set; }
        /// <summary>
        /// 实际值  如果是赠送 的 RealValue=0  在财务统计中有用
        /// </summary>
        public virtual decimal? RealValue { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual string Products { get; set; }

        #endregion

    }
}
