/*
 * 作者：cyx    
 * 日期：2016.06.15
 * 描述：财务订单明细
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 财务订单明细
    /// </summary>
    public class FinancialOrderDetailsViewModel
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
        /// 订单收入
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public decimal OrderToal { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 产品类别id
        /// </summary>
        public int ProductCategoryId { get; set; }




    }
}
