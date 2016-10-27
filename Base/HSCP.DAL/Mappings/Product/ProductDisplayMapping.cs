using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class ProductDisplayMapping : EntityTypeConfiguration<ProductDisplay>
    {
        public ProductDisplayMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            ToTable("ProductDisplay");
        }
    }
}