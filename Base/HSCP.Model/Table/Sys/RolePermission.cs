using System;
using Conan.Core;

namespace Conan.Model
{
    public class RolePermission : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int RoleId { get; set; }
        public virtual string PermissionCode { get; set; }
    }
}
