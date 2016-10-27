//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工标签
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
    /// 员工标签
    /// </summary>
    public partial class EmployeeLabel : Entity<int>
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        [Description("标签名称")]
        public virtual string Name { get; set; }
      
    } 
}