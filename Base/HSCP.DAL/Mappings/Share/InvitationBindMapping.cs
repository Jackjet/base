using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class InvitationBindMapping : EntityTypeConfiguration<InvitationBind>
    {
        public InvitationBindMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            ToTable("InvitationBind");
        }

    }
}
