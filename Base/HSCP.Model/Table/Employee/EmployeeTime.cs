/****************************************************** 

    文件名称：EmployeeInfo.cs
    功能描述：员工可服务时间
    作    者：Jxw
    日    期：2016.10.19
    修改记录：

*******************************************************/
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 员工可服务时间
    /// </summary>
    public class EmployeeTime : Entity<int>
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [Description("员工ID")]
        public virtual int EmployeeId { get; set; }

        public virtual DayOfWeek Week { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Description("开始时间")]
        public virtual TimeSpan StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Description("结束时间")]
        public virtual TimeSpan EndTime { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("是否启用")]
        public virtual bool IsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}
