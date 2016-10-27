/*
 * 作者：ldw    
 * 日期：2016.07.06
 * 描述：车辆业绩明细
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 车辆业绩明细
    /// </summary>
    public class VehicleAchievementDetailViewModel
    {


        /// <summary>
        /// 订单编号
        /// </summary>
        public string BillNo { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNo { get; set; }

        /// <summary>
        /// 收入
        /// </summary>
        public decimal Amount { get; set; }

        public DateTime RealStartTime { get; set; }
        /// <summary>
        /// 服务地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 结束地址
        /// </summary>
        public string EndAddress { get; set; }
    }
}
