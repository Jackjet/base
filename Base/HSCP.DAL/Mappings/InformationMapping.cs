/*
 * 作者：Ldw    
 * 日期：2016.06.27
 * 描述：咨讯
 * 修改记录：    
 * */
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class InformationMapping : EntityTypeConfiguration<Information>
    {
        public InformationMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("Information");
        }

    }
}
