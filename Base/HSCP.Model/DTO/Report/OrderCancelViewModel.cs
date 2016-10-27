/*
 * 作者：ldw    
 * 日期：2016.08.31
 * 描述：取消订单
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 取消订单
    /// </summary>
    public class OrderCancelViewModel
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
        /// 服务项目
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 撤销原因
        /// </summary>
        public OrdechangeEnum why { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }

    }
}
