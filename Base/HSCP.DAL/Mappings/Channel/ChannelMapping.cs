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
    /// <summary>
    /// 渠道
    /// </summary>
    public class ChannelMapping : EntityTypeConfiguration<Channel>
    {
        public ChannelMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
            Property(c => c.ChannelName).HasMaxLength(50);
            Property(c => c.Code).HasMaxLength(50);
            ToTable("Channel");
        }
    }
}
