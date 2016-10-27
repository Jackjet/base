using HSCP.Core;
using System;
using System.ComponentModel;


namespace HSCP.Model
{
    public class CityArea : Entity<int>
    {
        /// <summary>
        /// 城市名称或地区
        /// </summary>
        [Description("城市名称或地区")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 名称拼音
        /// </summary>
        [Description("名称拼音")]
        public virtual string Pinyin { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        [Description("城市ID")]
        public virtual int CityId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public virtual int State { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public virtual int Sort { get; set; }
        /// <summary>
        /// 是否可编辑
        /// </summary>
        [Description("是否可编辑")]
        public virtual bool IsEdit { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}
