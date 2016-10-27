/*
 * 作者：Ldw    
 * 日期：2016.06.20
 * 描述：渠道管理
 * 修改记录：    
 * */
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{

    public class ChanneRelevancyMapping : EntityTypeConfiguration<ChanneRelevancy>
    {
        public ChanneRelevancyMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
            ToTable("ChanneRelevancy");
        }
    }
}
