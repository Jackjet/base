using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{  
    /// <summary>
    /// 薪酬保存
    /// </summary>
          public class OrderWagesViewAdd
    {

        /// <summary>
        /// 订单编号
        /// </summary>
        public virtual string BillNo { get; set; }

        ///// <summary>
        ///// 实际得到的金额
        ///// </summary>

        public virtual string[] RealWage { get; set; }

        /// <summary>
        /// 主键id
        /// </summary>
        public virtual int[] Id { get; set; }

    }
}
