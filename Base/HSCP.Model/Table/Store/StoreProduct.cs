/****************************************************** 

    文件名称：StoreProduct.cs
    功能描述：门店产品信息
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using Conan.Core;
using System;
using System.ComponentModel;


namespace Conan.Model
{
    public partial class StoreProduct : Entity<int>
    {
        /// <summary>
        /// 门店Id
        /// </summary>
        [Description("门店ID")]
        public virtual int StoreId { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        [Description("产品ID")]
        public virtual int ProductId { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [Description("产品编号")]
        public virtual string ProductCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}

