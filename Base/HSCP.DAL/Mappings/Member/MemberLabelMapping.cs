using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class MemberLabelMapping : EntityTypeConfiguration<MemberLabel>
    {
        public MemberLabelMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
         
            ToTable("MemberLabel");
        }
    }
}
