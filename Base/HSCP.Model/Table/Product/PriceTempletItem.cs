/****************************************************** 

    文件名称：PriceTempletItem.cs
    功能描述：价格模板详情
    作    者：Jxw
    日    期：2016.05.11
    修改记录：

*******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    public class PriceTempletItem : Entity<int>
    {
        /// <summary>
        /// 关联模板
        /// </summary>
        [Description("关联模板")]
        public virtual int PriceTempletId { get; set; }

        /// <summary>
        /// 关联SkuPrice  多个“,”分隔
        /// </summary>
        [Description("关联产品价格")]
        public virtual string SkuPriceId { get; set; }

        /// <summary>
        /// 产品Id
        /// </summary>
        [Description("关联产品")]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Description("临时价")]
        public virtual decimal Price { get; set; }

        /// <summary>
        /// 附加单价
        /// </summary>
        [Description("临时附加价")]
        public virtual decimal AdditionalPrice { get; set; }

        /// <summary>
        /// 时间段 多个“,”分隔
        /// </summary>
        [Description("Sku时间段")]
        public virtual string SkuTimeId { get; set; }
        /// <summary>
        /// 地区 
        /// </summary>
        [Description("Sku地区")]
        public virtual int SkuAreaId { get; set; }
        /// <summary>
        /// 会员等级 多个“,”分隔
        /// </summary>
        [Description("会员等级")]
        public virtual string MemberLevel { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        [Description("操作内容")]
        public string Message { set; get; }
    }
}
