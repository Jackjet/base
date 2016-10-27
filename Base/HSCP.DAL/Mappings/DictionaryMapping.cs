using System;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    public class DictionaryMapping : EntityTypeConfiguration<Dictionary>
    {
        public DictionaryMapping() {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.TypeText).HasMaxLength(50);
            Property(c => c.Img).HasMaxLength(100);
            Property(c => c.Remark).HasMaxLength(200);
            Property(c => c.Option).HasMaxLength(100);
            Property(c => c.Text).HasMaxLength(50);
            ToTable("Dictionary");
        }
    }
}
