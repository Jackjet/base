/*
 * 作者：Ldw    
 * 日期：2016.05.23  
 * 描述：资金流水
 * 修改记录：    
 * */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 资金表实体
    /// </summary>
    [NotMapped]

    public class CashJournalViewModel : CashJournal
    {
        public string account { get; set; }
        /// <summary>
        /// 关联单据
        /// </summary>
        public string relevance { get; set; }


        /// <summary>
        /// 订单服务时间
        /// </summary>
        public DateTime? servicetime { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public string Productname { get; set; }
    }
}
