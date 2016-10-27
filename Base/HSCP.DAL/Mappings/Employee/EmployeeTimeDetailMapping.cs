
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings
{
    /// <summary>
    /// 员工可服务时间
    /// </summary>
    public class EmployeeTimeDetailMapping : EntityTypeConfiguration<EmployeeTimeDetail>
    {
        public EmployeeTimeDetailMapping() {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();

            ToTable("EmployeeTimeDetail");
        }
    }
}
