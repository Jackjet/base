/*
 * 作者：Ldw    
 * 日期：2016.05.23  
 * 描述：资金流水
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    [NotMapped]
    public class CashJournalOption 
    {
        public string Account { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public GenreEnum TransactionType { get; set; }
    }
}
