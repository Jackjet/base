using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 历史订单列表实体
    /// </summary>
    [NotMapped]

    public class MemberCashJournalViewModel : CashJournal
    {
        /// <summary>
        /// 支付类型
        /// </summary>
        public string CashJournalPayType { get; set; }

    }
}
