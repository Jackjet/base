using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class ShareRedBindMapping : EntityTypeConfiguration<ShareRedBind>
    {
        public ShareRedBindMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            ToTable("ShareRedBind");
        }

    }
}
