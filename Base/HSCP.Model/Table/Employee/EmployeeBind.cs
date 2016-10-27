//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工第三方登录绑定
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.07.24
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
    /// 员工第三方登录绑定
    /// </summary>
    public class EmployeeBind : Entity<int>
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        [Description("员工ID")]
        public virtual int EmployeeId { get; set; }
        /// <summary>
        /// 第三方来源 统一存小写
        /// </summary>
        [Description("第三方来源")]
        public virtual string Source { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        [Description("UserId")]
        public virtual string UserId { get; set; }
        /// <summary>
        /// OpenId
        /// </summary>
        [Description("OpenId")]
        public virtual string OpenId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}
