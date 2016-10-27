/*
 * 作者：ldw    
 * 日期：2016.09.06
 * 描述：财务明细表-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 财务明细表-过滤条件
    /// </summary>
    public class FinancialStatisticalDetailOption
    {

        /// <summary>
        /// 查询内容集合（订单编号集合）
        /// </summary>
        public string OrderBillNos { get; set; }
        /// <summary>
        /// 门店
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMent { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductName { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderBillNo  { get; set; }
        /// <summary>
        /// 服务员工
        /// </summary>
        public string ServiceEmployees { get; set; }

        /// <summary>
        /// 服务车牌号
        /// </summary>
        public string ServiceVehicle { get; set; }

        /// <summary>
        /// 产品类别
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public string DepartMentPath { get; set; }
        /// <summary>
        /// 保存的部门id
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
