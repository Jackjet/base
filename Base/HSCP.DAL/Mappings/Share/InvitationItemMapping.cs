using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class InvitationItemMapping : EntityTypeConfiguration<InvitationItem>
    {
        public InvitationItemMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            ToTable("InvitationItem");
        }

    }
}
