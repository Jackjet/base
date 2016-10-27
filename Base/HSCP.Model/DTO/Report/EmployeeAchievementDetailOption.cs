/*
 * 作者：cyx    
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
    public class EmployeeAchievementDetailOption
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
        /// 产品分类
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 服务时间开始
        /// </summary>
        public DateTime? ServiceTimeBegin { get; set; }
        /// <summary>
        /// 服务时间结束
        /// </summary>
        public DateTime? ServiceTimeEnd { get; set; }

        public int FirstTime { get; set; } = 0;
    }
}
