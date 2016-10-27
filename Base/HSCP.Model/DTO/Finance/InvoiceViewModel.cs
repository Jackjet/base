/*
 * 作者：chenyuxi    
 * 日期：2016.06.01  
 * 描述：发票
 * 修改记录：    
 * */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 发票视图
    /// </summary>
    [NotMapped]

    public class InvoiceViewModel : Invoice
    {
        /// <summary>
        /// 会员账号
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// 已开票总金额
        /// </summary>
        public virtual decimal InvoiceAmount { get; set; }
    }

}
