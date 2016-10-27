using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class PriceTempletItemMapping : EntityTypeConfiguration<PriceTempletItem>
    {
        public PriceTempletItemMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();

            ToTable("PriceTempletItem");
        }
    }
}