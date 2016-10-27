using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class StoreProductAreaMapping : EntityTypeConfiguration<StoreProductArea>
    {
        public StoreProductAreaMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
         
            ToTable("StoreProductArea");
        }
    }
}
