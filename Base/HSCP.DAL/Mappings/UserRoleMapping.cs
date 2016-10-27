using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings
{
    public class UserRoleMapping : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMapping() {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            ToTable("UserRole");
        }
    }
}
