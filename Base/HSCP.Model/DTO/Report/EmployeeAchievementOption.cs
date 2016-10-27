/*
 * 作者：cyx    
 * 日期：2016.06.14  
 * 描述：员工业绩报表-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 员工业绩报表-过滤条件
    /// </summary>
    public class EmployeeAchievementOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 时间开始
        /// </summary>
        public DateTime? TimeBegin { get; set; }
        /// <summary>
        /// 时间结束
        /// </summary>
        public DateTime? TimeEnd { get; set; }

        /// <summary>
        /// 隐藏的input判断次数
        /// </summary>
        public virtual int firstselect { get; set; } = 0;
    }
}
