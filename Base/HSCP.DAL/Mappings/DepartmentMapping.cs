using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class DepartmentMapping : EntityTypeConfiguration<Department>
    {
        public DepartmentMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.Name).HasMaxLength(50);
            Property(c => c.Pid).IsRequired();
            Property(c => c.StoreId).IsRequired();
            Property(c => c.Remark).HasMaxLength(100);
            Property(c => c.Path).HasMaxLength(50);

            ToTable("Department");
        }

    }
}
