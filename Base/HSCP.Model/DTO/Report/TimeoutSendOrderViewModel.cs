/*
 * 作者：cyx    
 * 日期：2016.06.16  
 * 描述：超时派单
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 超时派单
    /// </summary>
    public class TimeoutSendOrderViewModel
    {
        /// <summary>
        /// 产品
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductCateogryId { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public string ProductName { get; set; }
     
        /// <summary>
        /// 派单员
        /// </summary>
        public string SendOrderMember { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentTime { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime? SendOrderTime { get; set; }
        /// <summary>
        /// 超时分钟
        /// </summary>
        public double Timeout { get; set; }
    }
}
