/*
 * 作者：Ldw    
 * 日期：2016.07.26  
 * 描述：礼品管理优惠卷关联表
 * 修改记录：    
 * */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 礼品管理
    /// </summary>
    [NotMapped]

    public class GiftCouponViewModel : GiftCoupon
    {
        public string CouponName { get; set; }
        public decimal Amount { get; set; }

    }
}
