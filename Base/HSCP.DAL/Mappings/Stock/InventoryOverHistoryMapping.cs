using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class InventoryOverHistoryMapping : EntityTypeConfiguration<InventoryOverHistory>
    {
        public InventoryOverHistoryMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
          
            ToTable("InventoryOverHistory");
        }

    }
}
