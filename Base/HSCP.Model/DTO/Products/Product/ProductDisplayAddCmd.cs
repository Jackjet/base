//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：产品前端显示
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.06.2
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************
namespace Conan.Model
{
    /// <summary>
    /// 产品前端显示
    /// </summary>
    public class ProductDisplayAddCmd
    {
        /// <summary>
        /// 显示渠道（App、微信）
        /// </summary>
        public ProductChannelEnum DisplayChannel { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsDisplay { get; set; } = false;
    }
}