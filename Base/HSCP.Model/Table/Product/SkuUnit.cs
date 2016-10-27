/****************************************************** 

    文件名称：SkuUnit.cs
    功能描述：sku 销售属性
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/

using Conan.Core;
using System;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// sku 销售属性
    /// </summary>
    public class SkuUnit : Entity<int>
    {
        /// <summary>
        /// 服务产品Id
        /// </summary>
        public virtual int ProductId { get; set; }

        /// <summary>
        ///  名称
        /// </summary>
        [Description("名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [Description("单位名称")]
        public virtual string UnitName { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        [Description("最小值")]
        public virtual int MinValue { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        [Description("最大值")]
        public virtual int MaxValue { get; set; }
        /// <summary>
        /// 递增值 默认1
        /// </summary>
        [Description("递增值")]
        public virtual int Step { get; set; } = 1;
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public virtual int Sort { get; set; }

        /// <summary>
        /// 是否是理论工时
        /// </summary>
        [Description("是否是理论工时")]
        public virtual bool IsTheoreticalWork { get; set; } = false;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}