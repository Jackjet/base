using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    [NotMapped]
    public class InvoiceMemberViewModel : Member
    {
        /// <summary>
        /// 已开票充值总额
        /// </summary>
        public virtual decimal PaymentSummary { get; set; }

        /// <summary>
        /// 未开票金额
        /// </summary>
        public virtual decimal NoPayMentSummary { get; set; }
    }
}
