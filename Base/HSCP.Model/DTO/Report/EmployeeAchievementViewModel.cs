/*
 * 作者：cyx    
 * 日期：2016.06.14 
 * 描述：员工业绩报表
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 员工业绩报表
    /// </summary>
    public class EmployeeAchievementViewModel
    {
      

        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCards { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 业绩收入
        /// </summary>
        public decimal Amount { get; set; }


    }
}
