using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// </summary>
    public class ProductPriceAddCmd
    {
        /// <summary>
        /// 服务产品Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        ///服务区域
        /// </summary>
        public List<SkuAreaAddCmd> SkuAreaList { get; set; }
        /// <summary>
        ///服务时段
        /// </summary>
        public List<TimeSlotAddCmd> TimeSlotList { get; set; }
        /// <summary>
        ///SKU
        /// </summary>
        public List<SkuPriceAddCmd> SkuPriceList { get; set; }
    }
}
