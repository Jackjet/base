using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class CarAddCmd
    {
        /// <summary>
        /// 车牌编号
        /// </summary>
        public string CarCode { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNumber { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public int VehicleType { get; set; }
        /// <summary>
        /// 车辆大小
        /// </summary>
        public int VehicleSize { get; set; }
        /// <summary>
        /// 关联员工
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string  UserName { get; set; }
        /// <summary>
        /// 车辆类别
        /// </summary>
        public CarCategoryEnum VehicleCategory { get; set; }
        /// <summary>
        /// 所属门店
        /// </summary>
        public int? StoreId { get; set; }
        public int State { get; set; }
        public string Remark { get; set; }
    }
}
