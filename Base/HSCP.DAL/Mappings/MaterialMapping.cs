using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings
{
    public class MaterialMapping:EntityTypeConfiguration<Material>
    {
        public MaterialMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("Material");
        }
    }
}
