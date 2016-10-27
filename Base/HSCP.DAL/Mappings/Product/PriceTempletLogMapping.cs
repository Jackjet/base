using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class PriceTempletLogMapping : EntityTypeConfiguration<PriceTempletLog>
    {
        public PriceTempletLogMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            ToTable("PriceTempletLog");
        }
    }
}