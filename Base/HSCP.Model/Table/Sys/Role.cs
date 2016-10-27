using System;
using System.Collections.Generic;
using Conan.Core;

namespace Conan.Model
{
  /// <summary>
  /// 角色
  /// </summary>
    public partial class Role : Entity<int>
    {

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Domain { get; set; }
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 数据集权限
        /// </summary>
        public virtual DataSetPermissionsEnum DataSetPermissions { get; set; }
        
    }
}
