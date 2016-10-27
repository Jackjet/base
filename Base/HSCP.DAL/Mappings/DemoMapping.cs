using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HSCP.Model;

namespace HSCP.DAL
{
    public class DemoMapping : EntityTypeConfiguration<Demo>
    {
        public DemoMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("Demo");
        }
    }
}
