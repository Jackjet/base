using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HSCP.Model;

namespace HSCP.DAL
{
    public class OrderChangeMapping : EntityTypeConfiguration<OrderChange>
    {
        public OrderChangeMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("OrderChange");
        }
    }
}
