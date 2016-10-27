using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class OperateLogMapping : EntityTypeConfiguration<OperateLog>
    {
        public OperateLogMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.Operator).HasMaxLength(20);
            Property(c => c.Tag).HasMaxLength(50);
            Property(c => c.IP).HasMaxLength(128);
 
            ToTable("OperateLog");
        }
    }
}
