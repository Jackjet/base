/*
 * 作者：ldw
 * 日期：2016.07.06
 * 描述：车辆业绩报表
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 车辆业绩报表
    /// </summary>
    public class VehicleAchievementViewModel
    {
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 车辆编号
        /// </summary>
        public string VehicleNumber { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehicleNo { get; set; }

        /// <summary>
        /// 业绩收入
        /// </summary>
        public decimal Amount { get; set; }
    }
}
