using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 确认订单
    /// </summary>
  

    public class confirmViewModel
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string  BillNo { get; set; }


        /// <summary>
        /// 客户姓名
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 客户电话
        /// </summary>
        public virtual string Tel { get; set; }



        /// <summary>
        /// 服务员工
        /// </summary>
        public virtual string ServiceEmploy { get; set; }


        /// <summary>
        /// 服务车辆
        /// </summary>
        public virtual string ServiceCar { get; set; }


    }
}
