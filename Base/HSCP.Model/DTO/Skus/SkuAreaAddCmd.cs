using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class SkuAreaAddCmd
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 地区Id
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 地区Id
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked { get; set; } = false;
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }
    }
}
