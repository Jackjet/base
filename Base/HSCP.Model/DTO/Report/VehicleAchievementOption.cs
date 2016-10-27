/*
 * 作者：ldw  
 * 日期：2016.07.06
 * 描述：车辆业绩报表-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 车辆业绩报表-过滤条件
    /// </summary>
    public class VehicleAchievementOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 车牌编号
        /// </summary>
        public string VehicleNo { get; set; }
        /// <summary>
        /// 所属类型  服务项目
        /// </summary>
        public int? ServiceId { get; set; }
        /// <summary>
        /// 所属产品id  服务项目
        /// </summary>
        public int? ProductId { get; set; }
        /// <summary>
        /// 时间开始
        /// </summary>
        public DateTime? TimeBegin { get; set; }
        /// <summary>
        /// 时间结束
        /// </summary>
        public DateTime? TimeEnd { get; set; }
        /// <summary>
        /// 隐藏的input判断次数
        /// </summary>
        public int firstselect { get; set; } = 0;
    }
}
