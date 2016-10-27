using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class WithdrawalMapping : EntityTypeConfiguration<Withdrawal>
    {
        public WithdrawalMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
            ToTable("Withdrawal");
        }
    }
}
