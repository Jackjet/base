using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 门店区域
    /// </summary>
    public class StoreAreaCmd
    {/// <summary>
     /// 门店Id
     /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 门店Id
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public int? ProductId { get; set; }
        /// <summary>
        /// 可服务区域
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 可服务区域ID
        /// </summary>
        public int AreaId { get; set; }
        public bool Selected { get; set; }
    }
}
