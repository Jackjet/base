//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：广告图片添加实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.04.28
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************

using System;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 广告图片添加实体
    /// </summary>
    public class AdvertisingImageAddCmd
    {    
        /// <summary>
        ///Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 广告Id
        /// </summary>
        public int AdvertisingId { get; set; }
        /// <summary>
        /// 广告位置
        /// </summary>
        public AdvertisingPositionEnum? Position { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public AdvertisingTypeEnum Type { get; set; }
        /// <summary>
        /// 关联号
        /// </summary>
        public int RelationNo { get; set; }
    }
}