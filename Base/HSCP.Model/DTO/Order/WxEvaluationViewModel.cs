using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 订单评价
    /// </summary>
    [NotMapped]

    public class WxEvaluationViewModel
    {
        
        /// <summary>
        ///员工编号
        /// </summary>
        public string ServiceNo { get; set; }
        /// <summary>
        ///订单号
        /// </summary>
        public string BillNo { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 订单名称
        /// </summary>

        public string ProductName { get; set; }
        /// <summary>
        /// 整体评价
        /// </summary>
        public int OverallRate { get; set; }
        /// <summary>
        /// 服务态度
        /// </summary>
        public int ServiceRate { get; set; }
        /// <summary>
        /// 准时上门
        /// </summary>
        public int ResponseRate { get; set; }
        /// <summary>
        /// 备注（评价内容）
        /// </summary>
        public string Remark { get; set; }
    }
}
