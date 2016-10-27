using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class OrderCacelItemMapping : EntityTypeConfiguration<OrderCacelItem>
    {
        public OrderCacelItemMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("OrderCacelItem");
        }
    }
}
