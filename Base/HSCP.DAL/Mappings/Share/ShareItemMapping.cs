using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class ShareItemMapping : EntityTypeConfiguration<ShareItem>
    {
        public ShareItemMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            ToTable("ShareItem");
        }

    }
}
