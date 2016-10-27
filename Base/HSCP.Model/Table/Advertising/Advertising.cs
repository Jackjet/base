//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：广告表
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.06.20
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 广告表
    /// </summary>
    public class Advertising : Entity<int>
    {
        /// <summary>
        /// 显示渠道
        /// </summary>
        [Description("显示渠道")]
        public virtual AdvertisingChannelEnum DisplayChannel { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Description("类型")]
        public virtual AdvertisingTypeEnum Type { get; set; }
        /// <summary>
        /// 广告位置
        /// </summary>
        [Description("广告位置")]
        public virtual AdvertisingPositionEnum? Position { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        [Description("起始时间")]
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Description("结束时间")]
        public virtual DateTime? EndTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public virtual int? Sort { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("是否启用")]
        public virtual bool IsEnable { get; set; }
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        [Description("最后编辑时间")]
        public virtual DateTime EditTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}
