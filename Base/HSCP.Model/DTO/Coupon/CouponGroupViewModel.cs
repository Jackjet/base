using System;
/*
 * 作者：Ldw    
 * 日期：2016.05.23  
 * 描述：优惠券   
 * 修改记录：    
 * */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    [NotMapped]
    public class CouponGroupViewModel : CouponGroup
    {
        public int? NotBindNumber { get; set; }
    }
}
