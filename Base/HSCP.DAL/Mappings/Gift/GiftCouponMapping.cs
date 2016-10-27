/*
 * 作者：Ldw    
 * 日期：2016.07.26  
 * 描述：礼品管理优惠卷关联表
 * 修改记录：    
 * */
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;


namespace Conan.DAL.Mappings
{
    public class GiftCouponMapping : EntityTypeConfiguration<GiftCoupon>
    {
        public GiftCouponMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            ToTable("GiftCoupon");
        }

    }
}
