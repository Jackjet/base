using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    [NotMapped]
    public class InvoiceOption
    {
        /// <summary>
        /// 发票编号
        /// </summary>
        public virtual string InvoiceCode { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public virtual string Account { get; set; }
        /// <summary>
        /// 发票状态
        /// </summary>
        public virtual InvoiceStateEnum? InvoiceState { get; set; }
    }
}
