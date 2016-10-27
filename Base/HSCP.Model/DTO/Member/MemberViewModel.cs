using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    [NotMapped]
    public class MemberViewModel : Member
    {

        /// <summary>
        /// 发票信息(抬头信息)
        /// </summary>
        public virtual string InvoiceHeader { get; set; }
        /// <summary>
        /// 有效优惠券总额
        /// </summary>
        public virtual decimal CouponSummary { get; set; }
    }
}
