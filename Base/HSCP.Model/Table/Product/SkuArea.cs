/****************************************************** 

    文件名称：SkuArea.cs
    功能描述：sku 对应 服务区域 
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
    /// sku 对应 服务区域 
    /// </summary>
    public class SkuArea : Entity<int>
    {
        /// <summary>
        /// 服务产品Id
        /// </summary>
        public virtual int ProductId { get; set; }
        /// <summary>
        /// 城市Id
        /// </summary>
        public virtual int CityId { get; set; }
        /// <summary>
        /// 地区Id
        /// </summary>
        public virtual int AreaId { get; set; }
    }
}
