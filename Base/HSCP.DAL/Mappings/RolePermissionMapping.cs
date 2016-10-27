using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class RolePermissionMapping : EntityTypeConfiguration<RolePermission>
    {
        public RolePermissionMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();

            ToTable("RolePermission");
        }
    }
}
