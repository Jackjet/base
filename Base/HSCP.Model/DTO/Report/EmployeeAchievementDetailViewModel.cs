/*
 * 作者：ldw    
 * 日期：2016.07.06
 * 描述：员工业绩明细
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 员工业绩明细
    /// </summary>
    public class EmployeeAchievementDetailViewModel
    {


        /// <summary>
        /// 订单编号
        /// </summary>
        public string BillNo { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNo { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 收入
        /// </summary>
        public decimal Amount { get; set; }

        public DateTime RealStartTime { get; set; }
        /// <summary>
        /// 服务地址
        /// </summary>
        public string Address{ get; set; }
        /// <summary>
        /// 结束地址
        /// </summary>
        public string EndAddress { get; set; }
        
    }
}
