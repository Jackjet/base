/*
 * 作者：Ldw    
 * 日期：2016.08.04 
 * 描述：充值送礼活动记录
 * 修改记录：    
 * */
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class GiftRechargeBindMapping : EntityTypeConfiguration<GiftRechargeBind>
    {
        public GiftRechargeBindMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("GiftRechargeBind");
        }

    }
}
