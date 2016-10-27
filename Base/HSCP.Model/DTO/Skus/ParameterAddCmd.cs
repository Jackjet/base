using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
   public class ParameterAddCmd
    {      /// <summary>
           /// 服务产品Id
           /// </summary>
        public int ProductId { get; set; }
        ///// <summary>
        ///// 预定提前时间 小时
        ///// </summary>
        //public int PresaleMin { get; set; }
        ///// <summary>
        ///// 最大预售期 天
        ///// </summary>
        //public int PresaleMax { get; set; }
        /// <summary>
        ///服务区域
        /// </summary>
        public List<SkuAreaAddCmd> SkuAreaList { get; set; }
        /// <summary>
        ///服务时段
        /// </summary>
        public List<SkuTimeAddCmd> SkuTimeList { get; set; }
        /// <summary>
        ///SKU
        /// </summary>
        public List<SkuAddCmd> SkuList { get; set; }
        /// <summary>
        ///SKU单位
        /// </summary>
        public List<SkuUnitAddCmd> SkuUnitList { get; set; }
    }
}
