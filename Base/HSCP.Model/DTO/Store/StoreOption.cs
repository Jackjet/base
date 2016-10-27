using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{    /// <summary>
     ///  门店 搜索
     /// </summary>
    public class StoreOption
    {
        public int CpId { get; set; }
        public int ProductId { get; set; }
        public int? CityId { get; set; }

        public int? AreaId { get; set; }
        public int? StoreId { get; set; }
        public string StoreName { get; set; }

        /// <summary>
        /// 店主名称（负责人）
        /// </summary>
        public string StoreKeeper { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int? State { get; set; }
    }
}
