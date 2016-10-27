/*
 * 作者：ldw
 * 日期：2016.09.06 
 * 描述：财务明细表
 * 修改记录：    
 * */

using System;
using System.Collections.Generic;

namespace Conan.Model
{
    /// <summary>
    /// 财务明细表
    /// </summary>
    public class FinancialStatisticalDetailViewModels
    {


        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderBillNo { get; set; }

        /// <summary>
        /// 车牌/服务员工
        /// </summary>
        public string ServiceNo { get; set; }

        /// <summary>
        /// 订单总收入
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 员工收入
        /// </summary>
        public decimal EmployeeAmount { get; set; }

        /// <summary>
        /// 公司收入（门店收入）
        /// </summary>
        public decimal StoreAmount { get; set; }
    }
}
