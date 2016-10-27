using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Model
{
    public class CarOption
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNumber { get; set; }
        /// <summary>
        /// 所属门店
        /// </summary>
        public virtual int? StoreId { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public virtual int? VehicleType { get; set; }
        /// <summary>
        /// 关联员工
        /// </summary>
        public virtual int? UserId { get; set; }
        /// <summary>
        /// 关联名称
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 车辆类别
        /// </summary>
        public CarCategoryEnum? VehicleCategory { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? State { get; set; }
    }
}
