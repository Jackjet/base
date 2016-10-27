using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class ErrorLogMapping : EntityTypeConfiguration<ErrorLog>
    {
        public ErrorLogMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("ErrorLog");
        }
    }
}
