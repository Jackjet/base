using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 用户角色 
    /// </summary>
    public class UserRole:Entity<int>
    {
        public virtual int EmployeeId { get;set;}

        public virtual int RoleId { get; set; }

        //public virtual string Domain { get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
