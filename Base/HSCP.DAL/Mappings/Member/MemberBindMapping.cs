using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class MemberBindMapping : EntityTypeConfiguration<MemberBind>
    {
        public MemberBindMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
         
            ToTable("MemberBind");
        }
    }
}
