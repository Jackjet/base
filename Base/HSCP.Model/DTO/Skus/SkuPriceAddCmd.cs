using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
   public class SkuPriceAddCmd
   {
       public int? Id;
        /// <summary>
        /// 产品价格Id数组，格式（",1,"）
        /// </summary>
        public string SkuPriceIdArray { get; set; }
        /// <summary>
        /// 起步价
        /// </summary>
        public decimal StartingPrice { get; set; } = 0;
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; } = 0;
        /// <summary>
        /// 附加单价
        /// </summary>
        public decimal AdditionalPrice { get; set; } = 0;
        /// <summary>
        /// 对应 服务产品 sku 表 第一条 +对应 服务产品 sku 表 第二条  +对应 服务产品 sku 表 第三条 
        /// </summary>
        public string SkuValue { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        /// <summary>
        /// 时间段
        /// </summary>
        public virtual int? SkuTimeId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual int? SkuAreaId { get; set; }
        /// <summary>
        /// 时间段
        /// </summary>
        public int? TimeSlotNo { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; } = false;
    }
}
