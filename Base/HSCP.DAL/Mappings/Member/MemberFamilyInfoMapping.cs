using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings
{
    public class MemberFamilyInfoMapping : EntityTypeConfiguration<MemberFamilyInfo>
    {
        public MemberFamilyInfoMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.Remark).HasMaxLength(200);
            ToTable("MemberFamilyInfo");
        }
    }
}
