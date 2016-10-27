//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：广告图片表
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
    /// 广告图片表
    /// </summary>
    public class AdvertisingImage : Entity<int>
    {
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        public virtual string Img { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        [Description("跳转链接")]
        public virtual string Link { get; set; }
        /// <summary>
        /// 广告Id
        /// </summary>
        [Description("广告Id")]
        public virtual int AdvertisementId { get; set; }
        /// <summary>
        /// 广告位置
        /// </summary>
        [Description("广告位置")]
        public virtual AdvertisingPositionEnum? Position { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Description("类型")]
        public virtual AdvertisingTypeEnum Type { get; set; }
    }
}
