using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    [NotMapped]
    public class InvoicePaymentOption
    {
        public string Account { get; set; }
        public string Phone { get; set; }

        public int? MemberId { get; set; }

    }
}
