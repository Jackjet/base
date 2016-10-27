/*
 * 作者：cyx    
 * 日期：2016.06.12
 * 描述：业务来源统计报表视图实体
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 业务来源统计报表视图实体
    /// </summary>
    public class SourcesOfBusinessStatisticsViewModel
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
        /// 来源
        /// </summary>
        public BusinessChannel BuChannel { get; set; }

        /// <summary>
        /// 订单量
        /// </summary>
        public int Orders { get; set; }

        /// <summary>
        /// 营业额
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// 产品类别id
        /// </summary>
        public int ProductCategoryId { get; set; }




    }
}
