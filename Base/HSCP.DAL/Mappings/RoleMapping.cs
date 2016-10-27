using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class RoleMapping : EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.Name).HasMaxLength(20);
            Property(c => c.Description).HasMaxLength(200);
            ToTable("Role");
        }
    }
}
