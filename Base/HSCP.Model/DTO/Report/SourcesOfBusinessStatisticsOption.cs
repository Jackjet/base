/*
 * 作者：cyx    
 * 日期：2016.06.12  
 * 描述：业务来源统计报表-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 业务来源统计报表-过滤条件
    /// </summary>
    public class SourcesOfBusinessStatisticsOption
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
        /// 业务来源
        /// </summary>
        public BusinessChannel? BusinessChannel { get; set; }

        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 服务时间开始
        /// </summary>
        public DateTime? ServiceTimeBegin { get; set; }
        /// <summary>
        /// 服务时间结束
        /// </summary>
        public DateTime? ServiceTimeEnd { get; set; }

        public int firstTime { get; set; } = 0;
    }
}
