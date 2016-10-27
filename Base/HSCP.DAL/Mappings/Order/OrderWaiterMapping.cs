using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class OrderWaiterMapping : EntityTypeConfiguration<OrderWaiter>
    {
        public OrderWaiterMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("OrderWaiter");
        }
    }
}
