using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.Icon).HasMaxLength(600);
            Property(c => c.Banner).HasMaxLength(600);
            
            //Property(c => c.ProductCode).HasMaxLength(10);
            Property(c => c.Discription).HasMaxLength(1000);

            ToTable("Product");
        }
    }
}