/*
 * 作者：ldw    
 * 日期：2016.08.31
 * 描述：撤销订单
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 撤销订单-过滤条件
    /// </summary>
    public class OrderCancelOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 撤销原因
        /// </summary>
        public int why { get; set; }

        /// <summary>
        /// 服务开始
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 服务结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        public int firstTime { get; set; } = 0;
    }
}
