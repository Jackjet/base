using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 车辆
    /// </summary>
    public class Car : Entity<int>
    {
        /// <summary>
        /// 车牌编号
        /// </summary>
        [Description("车牌编号")]
        public virtual string CarCode { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        [Description("车牌号")]
        public virtual string CarNumber { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        [Description("城市ID")]
        public virtual int? CityId { get; set; }
        /// <summary>
        /// 门店编号
        /// </summary>
        [Description("门店ID")]
        public virtual int? StoreId { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        [Description("车辆类型")]
        public virtual int VehicleType { get; set; }
        /// <summary>
        /// 车辆大小
        /// </summary>
        [Description("车辆大小")]
        public virtual int VehicleSize { get; set; }
        /// <summary>
        /// 车辆类别
        /// </summary>
        [Description("车辆类别")]
        public virtual CarCategoryEnum VehicleCategory { get; set; }
        /// <summary>
        /// 关联员工
        /// </summary>
        [Description("关联员工")]
        public virtual int? UserId { get; set; } 

        /// <summary>
        /// 关联员工
        /// </summary>
        [Description("关联员工")]
        public virtual string  UserName { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public virtual int State { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}