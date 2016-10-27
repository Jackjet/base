/*
 * 作者：Ldw    
 * 日期：2016.07.27 
 * 描述：充值送礼
 * 修改记录：    
 * */
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class GiftRechargeMapping : EntityTypeConfiguration<GiftRecharge>
    {
        public GiftRechargeMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("GiftRecharge");
        }

    }
}
