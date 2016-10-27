/****************************************************** 

    文件名称：StoreProductArea.cs
    功能描述：门店产品区域信息
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using Conan.Core;
using System;
using System.ComponentModel;


namespace Conan.Model
{
    public partial class StoreProductArea : Entity<int>
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
        public virtual int? ProductId { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [Description("产品编号")]
        public virtual string ProductCode { get; set; }
        /// <summary>
        /// 可服务区域
        /// </summary>
        [Description("可服务区域")]
        public virtual string AreaName { get; set; }
        /// <summary>
        /// 可服务区域ID
        /// </summary>
        [Description("可服务区域ID")]
        public virtual int AreaId { get; set; }

        public virtual DateTime CreateTime { get; set; }
    }
}

