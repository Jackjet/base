/*
 * 作者：cyx    
 * 日期：2016.06.08  
 * 描述：运营统计报表视图实体
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 运营统计报表视图实体
    /// </summary>
    public class OrderBusinessViewModel
    {
        /// <summary>
        /// 产品
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductCateogryId { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 优惠券金额
        /// </summary>
        public decimal CouponAmount { get; set; }
        /// <summary>
        /// 购买金额
        /// </summary>
        public decimal RealValue { get; set; }
        /// <summary>
        /// 营销费用
        /// </summary>
        public decimal RealValueJian { get; set; }
        /// <summary>
        /// 服务时间
        /// </summary>

        public DateTime ServiceTime { get; set; }
    }
}
