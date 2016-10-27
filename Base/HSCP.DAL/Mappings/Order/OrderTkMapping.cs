using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class OrderTkMapping : EntityTypeConfiguration<OrderTk>
    {
        public OrderTkMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("OrderTk");
        }
    }
}
