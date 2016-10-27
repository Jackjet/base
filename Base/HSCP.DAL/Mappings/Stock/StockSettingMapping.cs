using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class StockSettingMapping : EntityTypeConfiguration<StockSetting>
    {
        public StockSettingMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
          
            ToTable("StockSetting");
        }

    }
}
