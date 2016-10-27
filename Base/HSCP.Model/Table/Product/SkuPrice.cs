/****************************************************** 

    文件名称：SkuPrice.cs
    功能描述：sku 单价
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/

using Conan.Core;
using System;
using System.ComponentModel;

namespace Conan.Model
{
    public class SkuPrice : Entity<int>
    {
        /// <summary>
        /// 服务产品Id
        /// </summary>
        public virtual int ProductId { get; set; }
        /// <summary>
        /// 起步价
        /// </summary>
        public virtual decimal StartingPrice { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// 附加单价
        /// </summary>
        public virtual decimal AdditionalPrice { get; set; }
        /// <summary>
        /// 时间段
        /// </summary>
        public virtual int SkuTimeId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual int SkuAreaId { get; set; }


      
        /// <summary>
        /// 对应 服务产品 sku 表 第一条 +对应 服务产品 sku 表 第二条  +对应 服务产品 sku 表 第三条 
        /// </summary>
        public virtual string SkuValue { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsEnable { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}
