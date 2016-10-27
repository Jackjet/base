using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class RechargeOption
    {
        public string Account { get; set; }
        public MethodPaymentEnum MethodPayment { get; set; }
        public DateTime? StartPayTime { get; set; }
        public DateTime? EndPayTime { get; set; }
        public string RechargePeople { get; set; }
    }
}
