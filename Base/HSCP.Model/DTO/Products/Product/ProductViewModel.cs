//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：产品视图实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.04.28
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Conan.Model;

namespace Conan.Model
{
    [NotMapped]
    public class ProductViewModel : Product
    {

        public int StoreId { get; set; }
        public string CategoryName { get; set; }
        /// <summary>
        /// 关联产品编号
        /// </summary>
        public string RelatedProductCode { get; set; }
    }
}