using Conan.Core;
using System;
using System.ComponentModel;


namespace Conan.Model
{
    /// <summary>
    /// 产品前端显示
    /// </summary>
    public class ProductDisplay : Entity<int>
    {
        /// <summary>
        /// 显示渠道（App、微信）
        /// </summary>
        [Description("显示渠道")]
        public virtual ProductChannelEnum DisplayChannel { get; set; }
        /// <summary>
        /// 显示类型（产品、产品类别）
        /// </summary>
        [Description("显示类型")]
        public virtual ProductDisplayEnum DisplayType { get; set; }
        /// <summary>
        /// 显示类型Id （产品、产品类别）
        /// </summary>
        [Description("显示类型Id ")]
        public virtual int DisplayTypeId { get; set; }
        /// <summary>
        /// 是否推荐到首页
        /// </summary>
        [Description("是否推荐到首页")]
        public virtual bool IsRecommend { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [Description("是否显示")]
        public virtual bool IsDisplay { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public virtual int Sort { get; set; } = 0;
    }
}