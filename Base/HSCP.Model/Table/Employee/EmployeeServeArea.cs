/****************************************************** 

    文件名称：EmployeeInfo.cs
    功能描述：员工可服务区域模板
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
    /// 员工可服务区域模板
    /// </summary>
    public partial class EmployeeServeArea : Entity<int>
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [Description("员工ID")]
        public virtual int EmployeeId { get; set; }
        public virtual DayOfWeek Week { get; set; }
        /// <summary>
        /// 可服务区域
        /// </summary>
        [Description("可服务区域名称")]
        public virtual string AreaName { get; set; }
        /// <summary>
        /// 可服务区域ID
        /// </summary>
        [Description("可服务区域ID")]
        public virtual int AreaId { get; set; }
    }
}