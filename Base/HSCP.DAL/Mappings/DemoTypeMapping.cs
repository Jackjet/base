using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HSCP.Model;

namespace HSCP.DAL
{
    public class DemoTypeMapping : EntityTypeConfiguration<DemoType>
    {
        public DemoTypeMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();     
            ToTable("DemoType");
        }
    }
}
