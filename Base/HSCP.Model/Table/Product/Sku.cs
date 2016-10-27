/****************************************************** 

    文件名称：Sku.cs
    功能描述：Sku 
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Conan.Core;


namespace Conan.Model
{
    /// <summary>
    /// sku
    /// </summary>
    public  class Sku : Entity<int>
    {
        /// <summary>
        /// 服务产品Id
        /// </summary>
        public virtual int ProductId { get; set; }
        /// <summary>
        /// SKU名称
        /// </summary>
        [Description("SKU名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 属性1
        /// </summary>
        [Description("属性1")]
        public virtual string Property1 { get; set; }
        /// <summary>
        /// 属性2
        /// </summary>
        [Description("属性2")]
        public virtual string Property2 { get; set; }
        /// <summary>
        /// 属性3
        /// </summary>
        [Description("属性3")]
        public virtual string Property3 { get; set; }
        /// <summary>
        /// 属性4
        /// </summary>
        [Description("属性4")]
        public virtual string Property4 { get; set; }
        /// <summary>
        /// 属性5
        /// </summary>
        [Description("属性5")]
        public virtual string Property5 { get; set; }
        /// <summary>
        /// 属性6
        /// </summary>
        [Description("属性6")]
        public virtual string Property6 { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}