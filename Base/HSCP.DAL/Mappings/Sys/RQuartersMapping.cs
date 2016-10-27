using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class RQuartersMapping : EntityTypeConfiguration<RQuarters>
    {
        public RQuartersMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("RQuarters");
        }
    }
}
