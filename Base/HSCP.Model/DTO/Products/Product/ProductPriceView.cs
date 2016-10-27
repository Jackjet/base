//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：产品价格实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.06.30
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
    public class ProductPriceView
    {
        /// <summary>
        /// 原价
        /// </summary>
        public decimal Price { get; set; } = 0;
        /// <summary>
        /// 现价
        /// </summary>
        public decimal NowPrice { get; set; } = 0;
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; } = 0;
    }
}