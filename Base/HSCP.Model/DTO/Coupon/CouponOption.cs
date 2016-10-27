/*
 * 作者：Ldw    
 * 日期：2016.05.23  
 * 描述：优惠券   
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Model
{
    public class CouponOption 
    {

        public CouponOption() {

        }
        public string Key { get; set; }
        public int? CouponGroupId { get; set; }

        public string MemberNumber { get; set; }

        public string MemberPhone { get; set; }

        public decimal? FaceValue { get; set; }

        public CouponState? State { get; set; }
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }


    }
}
