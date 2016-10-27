using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 预报时
    /// </summary>
  

    public class UpdateTimeViewModel
    {

        /// <summary>
        /// 指定员工车辆的  id
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// 子订单号
        /// </summary>
        public virtual string  BillItemNo { get; set; }


        /// <summary>
        /// 时间
        /// </summary>
        public virtual string StartTime { get; set; }

    }
}