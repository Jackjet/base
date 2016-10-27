/****************************************************** 

    文件名称：CouponGroup.cs
    功能描述：券批次
    作    者：Jxw
    日    期：2016.05.18
    修改记录：

*******************************************************/

using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 券批次
    /// </summary>
    public class CouponGroup : Entity<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public virtual string Icon { get; set; }
        /// <summary>
        /// 限制使用最小金额
        /// </summary>
        public virtual int? MinAmount { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }
        /// <summary>
        /// 有效期（天）
        /// </summary>
        /// 
        public virtual int Validity { get; set; }
        /// <summary>
        /// 面值
        /// </summary>
        public virtual decimal FaceValue { get; set; }
        /// <summary>
        /// 实际值  如果是赠送 的 RealValue=0  在财务统计中有用
        /// </summary>
        public virtual decimal RealValue { get; set; }

        public virtual string Remark { get; set; }
        /// <summary>
        /// 发布数量
        /// </summary>
        public int PublishNum { get; set; } = 0;

        public virtual DateTime CreateTime { get; set; }
    }
}