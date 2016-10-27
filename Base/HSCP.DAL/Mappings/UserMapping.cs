using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HSCP.Model;

namespace HSCP.DAL
{

    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
         
            ToTable("User");
        }
    }
}
