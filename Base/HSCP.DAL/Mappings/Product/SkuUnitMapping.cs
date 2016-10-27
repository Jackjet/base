using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class SkuUnitMapping : EntityTypeConfiguration<SkuUnit>
    {
        public SkuUnitMapping()
        {
            HasKey<int>(o => o.Id);
            Property(c => c.Id)
              .IsRequired();

            ToTable("SkuUnit");
        }
    }
}
