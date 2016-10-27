//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：产品类别视图实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.05.22
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************

using System;

namespace Conan.Model
{
    public class ProductCategoryViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public DelStateEnum State { get; set; }
        public DateTime CreateTime { get; set; }
    }
}