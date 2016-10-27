using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class CouponMapping : EntityTypeConfiguration<Coupon>
    {
        public CouponMapping() {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            Property(c => c.Key).IsUnicode(false).HasMaxLength(50);
            Property(c => c.Remark).HasMaxLength(200);

            ToTable("Coupon");
        }
    }
}
