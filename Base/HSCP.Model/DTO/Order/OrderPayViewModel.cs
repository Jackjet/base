using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 列表实体 消费明细
    /// </summary>
    [NotMapped]

    public class OrderPayViewModel : OrderPay
    {

        /// <summary>
        /// 金额
        /// </summary>
        public virtual decimal? RealTotalAmount { get; set; }

     
    }

    [NotMapped]

    public class OrderWagesViewModel : OrderWages
    {

        /// <summary>
        /// 服务项目
        /// </summary>
        public virtual string servername { get; set; }


    }


}
