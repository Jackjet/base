//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工可服务区域明细
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.11
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{

    
    /// <summary>
    /// 员工可服务区域明细
    /// </summary>
    public partial class EmployeeServeAreaDetail : Entity<int>
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [Description("员工ID")]
        public virtual int EmployeeId { get; set; }
        /// <summary>
        /// 可服务区域
        /// </summary>
        [Description("可服务区域名称")]
        public virtual string  AreaName { get; set; }
        /// <summary>
        /// 可服务区域ID
        /// </summary>
        [Description("可服务区域ID")]
        public virtual int AreaId { get; set; }
        ///// <summary>
        ///// 星期
        ///// </summary>
        //[Description("星期")]
        //public virtual DayOfWeek Week { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime Day { get; set; }

    }
}