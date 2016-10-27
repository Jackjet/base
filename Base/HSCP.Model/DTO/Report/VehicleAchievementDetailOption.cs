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
    public class VehicleAchievementDetailOption
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
        /// 服务时间开始
        /// </summary>
        public DateTime? ServiceTimeBegin { get; set; }
        /// <summary>
        /// 服务时间结束
        /// </summary>
        public DateTime? ServiceTimeEnd { get; set; }

        public int ProductId { get; set; }


        public int FirstTime { get; set; } = 0;
    }
}
