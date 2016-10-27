using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
   public class PriceListViewModel
    {
        /// <summary>
        /// 服务产品Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        ///SKU
        /// </summary>
        public List<SkuPriceAddCmd> SkuPriceList { get; set; }
        /// <summary>
        /// 价格列表
        /// </summary>
        public List<SkuPriceViewModel> SkuPriceView { get; set; }

       /// <summary>
       /// 价格列表统计
       /// </summary>
       public int SkuPriceCount { get; set; } = 0;
    }
    [NotMapped]
    public class SkuPriceViewModel:SkuPrice
    {
        /// <summary>
        /// 产品价格Id数组，格式（",1,"）
        /// </summary>
        public string SkuPriceIdArray { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        /// <summary>
        /// 时间段
        /// </summary>
        public int TimeSlotNo { get; set; } = 0;
    }
    [NotMapped]
    public class SkuErrorViewModel
    {

        public SkuErrorEnum SkuError { get; set; }
        public SkuPrice SkuPriceView { get; set; }
    }
}
