using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class SkuTimeMapping : EntityTypeConfiguration<SkuTime>
    {
        public SkuTimeMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
         
            ToTable("SkuTime");
        }
    }
}
