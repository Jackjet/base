using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class StoreProductMapping : EntityTypeConfiguration<StoreProduct>
    {
        public StoreProductMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
         
            ToTable("StoreProduct");
        }
    }
}
