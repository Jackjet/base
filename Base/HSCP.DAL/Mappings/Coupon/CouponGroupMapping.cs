using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class CouponGroupMapping : EntityTypeConfiguration<CouponGroup>
    {
        public CouponGroupMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.Name).HasMaxLength(50);
            Property(c => c.Icon).IsUnicode(false).HasMaxLength(100);
            Property(c => c.Remark).HasMaxLength(200);

            ToTable("CouponGroup");
        }
    }
}
