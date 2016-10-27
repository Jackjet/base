using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    [NotMapped]
    public class PaymentOption
    {
        public string TraNumber { get; set; }
        public string Account { get; set; }
        public string Phone { get; set; }
        public SystemTypeEnum SystemType { get; set; }
        public MethodPaymentEnum MethodPayment { get; set; }
        public PaymentStatusEnum PayState { get; set; }
        public DateTime? TopupTime { get; set; }
        public DateTime? PayTime { get; set; }
    }
}
