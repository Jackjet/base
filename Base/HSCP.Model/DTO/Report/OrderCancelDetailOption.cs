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
    /// 取消订单明细--查询条件  
    /// </summary>
    public class OrderCancelDetailOption
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public string BillNo { get; set; }
        
        /// <summary>
        /// 门店Id
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// 门店
        /// </summary>
        public string Store { get; set; }

        /// <summary>
        /// 开始服务时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束服务时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 服务项目Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 服务项目
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 取消原因
        /// </summary>
        public OrdechangeEnum Why { get; set; }

        public int FirstTime { get; set; } = 0;
    }
}
