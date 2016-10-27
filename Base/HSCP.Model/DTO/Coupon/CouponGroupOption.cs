using System;
/*
 * 作者：Ldw    
 * 日期：2016.05.23  
 * 描述：优惠券   
 * 修改记录：    
 * */
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Conan.Model
{
    [NotMapped]
    public class CouponGroupOption
    {

        public CouponGroupOption() {

        }

        public string Key { get; set; }
        public string Name { get; set; }

        public int? CouponGroupId { get; set; }

        public CouponGroupTypEnum? CouponGroupTyp { get; set; }

        public int? FaceValue { get; set; }

        public DateTime? CreateTimeStart { get; set; }

        public DateTime? CreateTimeEnd { get; set; }


    }
}
