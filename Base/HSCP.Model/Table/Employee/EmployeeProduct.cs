//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工产品
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
    /// 员工产品
    /// </summary>
    public partial class EmployeeProduct : Entity<int>
    {

        /// <summary>
        /// 员工ID
        /// </summary>
        [Description("员工ID")]
        public virtual int EmployeeId { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        [Description("产品ID")]
        public virtual int PrdouctId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}

