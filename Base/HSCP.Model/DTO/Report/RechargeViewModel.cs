/*
 * 作者：Ldw    
 * 日期：2016.09.20  
 * 描述：充值报表实体
 * 修改记录：    
 * */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 充值报表实体
    /// </summary>

    public class RechargeViewModel 
    {
        public string Account { get; set; }
        public MethodPaymentEnum MethodPayment { get; set; }
        public decimal Amount { get; set; }
        public decimal GivingAmount { get; set; }
        public DateTime RechargeTime { get; set; }
        public string RechargePeople { get; set; }
        public int PaymentId { get; set; }
    }
}
