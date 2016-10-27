using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class MemberMapping : EntityTypeConfiguration<Member>
    {
        public MemberMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            Property(c => c.Account).IsRequired().HasMaxLength(50);
            Property(c => c.Password).IsRequired().HasMaxLength(256);
            Property(c => c.Name).HasMaxLength(50);
            Property(c => c.HeadImg).HasMaxLength(200);
            Property(c => c.Tags).HasMaxLength(100);
            Property(c => c.BirthDate).HasMaxLength(20);
            Property(c => c.BindTel).HasMaxLength(20);
            Property(c => c.Occupation).HasMaxLength(100);
            ToTable("Member");
        }
    }
}
