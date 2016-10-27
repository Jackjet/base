/*
 * 作者：Ldw    
 * 日期：2016.07.26  
 * 描述：礼品管理
 * 修改记录：    
 * */
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class GiftManageMapping : EntityTypeConfiguration<GiftManage>
    {
        public GiftManageMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("GiftManage");
        }

    }
}
