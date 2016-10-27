using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class CouponLimitMapping : EntityTypeConfiguration<CouponLimit>
    {
        public CouponLimitMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("CouponLimit");
        }
    }
}
