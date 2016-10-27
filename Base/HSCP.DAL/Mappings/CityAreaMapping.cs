using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings
{
    public class CityAreaMapping : EntityTypeConfiguration<CityArea>
    {
        public CityAreaMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.Pinyin).HasMaxLength(30);
            Property(c => c.Name).HasMaxLength(20);
            ToTable("CityArea");
        }
    }
}
