/*
 * 作者：cyx    
 * 日期：2016.06.15  
 * 描述：财务总表
 * 修改记录：    
 * */

using System;
using System.Collections.Generic;

namespace Conan.Model
{
    /// <summary>
    /// 财务总表
    /// </summary>
    public class FinancialStatisticalViewModel
    {


        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 门店Id
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public string ProductName { get; set; }

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

        /// <summary>
        /// 部门id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 产品分类id
        /// </summary>
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// 产品id
        /// </summary>
        public int ProductId { get; set; }

        public List<FinancialStatisticalDetailViewModel> FinancialStatisticalDetailViewModel { get; set; }


    }
    public class FinancialStatisticalDetailViewModel
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 产品id
        /// </summary>
        public string ProcuctName { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 员工收入
        /// </summary>
        public decimal EmployeeAmount { get; set; }
        /// <summary>
        /// 订单编号集合
        /// </summary>
        public string BillNos { get; set; }
    }
}
