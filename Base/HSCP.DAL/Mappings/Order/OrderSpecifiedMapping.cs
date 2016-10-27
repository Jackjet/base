using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class OrderSpecifiedMapping : EntityTypeConfiguration<OrderSpecified>
    {
        public OrderSpecifiedMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("OrderSpecified");
        }
    }
}
