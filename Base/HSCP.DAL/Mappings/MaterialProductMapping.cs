using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings
{
    public class MaterialProductMapping : EntityTypeConfiguration<MaterialProduct>
    {
        public MaterialProductMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.MaterialId).IsRequired();
            Property(c => c.ProductId).IsRequired();
            Property(c => c.CreateTime).IsRequired();
            ToTable("MaterialProduct");
        }
    }
}
