//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：广告添加实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.04.28
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************

using System;

namespace Conan.Model
{
    /// <summary>
    /// 广告添加实体
    /// </summary>
    public class AdvertisingAddCmd
    {    
        /// <summary>
        ///Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 显示渠道
        /// </summary>
        public AdvertisingChannelEnum DisplayChannel { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public AdvertisingTypeEnum Type { get; set; }
        /// <summary>
        /// 广告位置
        /// </summary>
        public AdvertisingPositionEnum? Position { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// 关联号
        /// </summary>
        public int RelationNo { get; set; }

    }
}