/*
 * 作者：cyx    
 * 日期：2016.06.08  
 * 描述：运营统计报表-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 运营统计报表-过滤条件
    /// </summary>
    public class BusinessStatisticalOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath2 { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaId { get; set; }

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
        /// <summary>
        /// 开单人
        /// </summary>
        public string OpenOrderEmployee { get; set; }
        /// <summary>
        /// 业务渠道  (订单来源)
        /// </summary>
        public  BusinessChannel? BuChannel { get; set; }
        /// <summary>
        /// 开发人
        /// </summary>
        public string Developer { get; set; }
        /// <summary>
        /// 预约服务开始时间
        /// </summary>
        public  DateTime? StartTime { get; set; }
        /// <summary>
        /// 预约服务结束时间 
        /// </summary>
        public  DateTime? EndTime { get; set; }
        /// <summary>
        /// 开始开单时间
        /// </summary>
        public DateTime? StartCreateTime { get; set; }
        /// <summary>
        /// 结束开单时间
        /// </summary>
        public DateTime? EndCreateTime { get; set; }

        /// <summary>
        /// 第一次进入取默认时间
        /// </summary>
        public int firstTime { get; set; } = 0;
    }
}
