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

    public class PaymentViewModel : Payment
    {
        public PaymentViewModel()
        {
            member = new Members();
        }
        public Members member { get; set; }
    }
    public class Members
    {
        public  string account { get; set; }
        public string phone { get; set; }
    }
}
