//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：产品类别搜索实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.04.28
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************
namespace Conan.Model
{
    public class ProductCategoryOption
    {
        // 产品分类编号
        public int? CpId { get; set; }
        // 产品分类名称
        public string CpName { get; set; }

        public string ProductName { get; set; }
        // 产品分类编号、名称
        public string CpIdOrName { get; set; }
    }
}
