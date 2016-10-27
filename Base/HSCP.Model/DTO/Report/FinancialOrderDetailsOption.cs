/*
 * 作者：cyx    
 * 日期：2016.06.15 
 * 描述：财务订单明细-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 财务订单明细-过滤条件
    /// </summary>
    public class FinancialOrderDetailsOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath{ get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath2 { get; set; }


        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 订单时间开始
        /// </summary>
        public DateTime? ServiceTimeBegin { get; set; }
        /// <summary>
        /// 订单时间结束
        /// </summary>
        public DateTime? ServiceTimeEnd { get; set; }

        /// <summary>
        /// 隐藏的input判断次数
        /// </summary>
        public virtual int firstselect { get; set; } = 0;

    }
}
