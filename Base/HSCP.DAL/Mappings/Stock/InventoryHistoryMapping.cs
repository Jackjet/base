using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class InventoryHistoryMapping : EntityTypeConfiguration<InventoryHistory>
    {
        public InventoryHistoryMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
          
            ToTable("InventoryHistory");
        }

    }
}
