using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class CarMapping:EntityTypeConfiguration<Car>
    {
        public CarMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.CarNumber).HasMaxLength(20);
            Property(c => c.CarCode).HasMaxLength(20);
            Property(c => c.Remark).HasMaxLength(100);
            ToTable("Car");
        }

    }
}
