using System;
using System.Collections.Generic;
using Conan.Core;

namespace Conan.Model
{
  /// <summary>
  /// 角色产品
  /// </summary>
    public partial class RoleProduct : Entity<int>
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public virtual int RoleId { get; set; }

        /// <summary>
        /// 产品id
        /// </summary>
        public virtual int ProductId { get; set; }

    }
}
