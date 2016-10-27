using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 取消订单
    /// </summary>
  

    public class cacelViewModel
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string  BillNo { get; set; }



        /// <summary>
        /// 原因
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public virtual string[] SNo { get; set; }



    }
}
