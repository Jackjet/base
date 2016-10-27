/*
 * 作者：cyx    
 * 日期：2016.06.08  
 * 描述：业务统计报表视图实体
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 业务统计报表视图实体
    /// </summary>
    public class BusinessStatisticalViewModel
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
        /// 区域
        /// </summary>
        public string AreaName { get; set; }
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
        /// <summary>
        /// 城市id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 区域id
        /// </summary>
        public int CityAreaId { get; set; }


    }
}
