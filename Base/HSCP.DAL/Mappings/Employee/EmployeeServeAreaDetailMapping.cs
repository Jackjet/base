
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings
{
    /// <summary>
    /// 员工可服务区域模板
    /// </summary>
    public class EmployeeServeAreaDetailMapping : EntityTypeConfiguration<EmployeeServeAreaDetail>
    {
        public EmployeeServeAreaDetailMapping() {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
            Property(c => c.AreaName).HasMaxLength(30);
            ToTable("EmployeeServeAreaDetail");
        }
    }
}
