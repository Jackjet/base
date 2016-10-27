using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class PaymentMapping : EntityTypeConfiguration<Payment>
    {
        public PaymentMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.OrderNo).HasMaxLength(50);
            Property(c => c.CustomerBank).HasMaxLength(50);
            Property(c => c.CustomerAccount).HasMaxLength(50);
            Property(c => c.MyAccount).HasMaxLength(50);
            Property(c => c.MyBank).HasMaxLength(50);
            Property(c => c.TradingCode).HasMaxLength(50);
            Property(c => c.MyTradingCode).HasMaxLength(50);
            Property(c => c.Img).HasMaxLength(50);
            Property(c => c.Remark).HasMaxLength(200);
            Property(c => c.PaymentChannelName).HasMaxLength(50);
            ToTable("Payment");
        }
    }
}
