//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工可服务时间 明细
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
    /// 员工可服务时间 明细
    /// </summary>
    public class EmployeeTimeDetail : Entity<int>
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [Description("员工ID")]
        public virtual int EmployeeId { get; set; }
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
        ///// <summary>
        ///// 星期
        ///// </summary>
        //[Description("星期")]
        //public virtual DayOfWeek Week { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime Day { get; set; }

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
