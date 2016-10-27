using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class RoleProductMapping : EntityTypeConfiguration<RoleProduct>
    {
        public RoleProductMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("RoleProduct");
        }
    }
}
