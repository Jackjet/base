//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：广告视图实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.06.21
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Conan.Model;

namespace Conan.Model
{
    /// <summary>
    /// 广告视图实体
    /// </summary>
    public class AdvertisingViewModel
    {
        /// <summary>
        /// Id
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
        /// 最后编辑时间
        /// </summary>
        public virtual DateTime EditTime { get; set; }
    }
}