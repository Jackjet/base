/****************************************************** 

    文件名称：Department.cs
    功能描述：部门信息
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using System;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 部门信息
    /// </summary>
    public class Department : Entity<int>
    {
        [Description("名称")]
        public virtual string Name { get; set; }

        [Description("父类")]
        public virtual int  Pid { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Path { get; set; }
        /// <summary>
        /// 当前层级
        /// </summary>
        public virtual int Level { get; set; }

        [Description("门店")]
        public virtual int StoreId { get; set; }

        [Description("员工人数")]
        public virtual int EmployeeNum { get; set; }

        [Description("备注")]
        public virtual string Remark { get; set; }
    }
}
