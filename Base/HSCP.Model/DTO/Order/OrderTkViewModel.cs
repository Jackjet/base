using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 退款
    /// </summary>
    [NotMapped]

    public class OrderTkViewModel : OrderTk
    {
        public string BanksAndOpenAccount { get; set; }
        public string BankCard{ get; set; }

    }
}
