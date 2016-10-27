/*
 * 作者：ldw    
 * 日期：2016.09.01
 * 描述：取消订单明细
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 取消订单明细
    /// </summary>
    public class OrderCancelDetailViewModel
    {


        /// <summary>
        /// 订单编号
        /// </summary>
        public string BillNo { get; set; }
        /// <summary>
        /// 取消人
        /// </summary>
        public string CancelPeople { get; set; }
        /// <summary>
        /// 取消类型
        /// </summary>
        public string OpType { get; set; }

        /// <summary>
        /// 取消时间
        /// </summary>
        public DateTime CancelTime { get; set; }

        /// <summary>
        /// 服务时间
        /// </summary>
        public DateTime ServiceTime { get; set; }

        /// <summary>
        /// 服务员工
        /// </summary>
        public string ServiceEmployees { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 扣款金额
        /// </summary>
        public decimal DeductionsAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

       public bool IsGroup { get; set; }
    }
}
