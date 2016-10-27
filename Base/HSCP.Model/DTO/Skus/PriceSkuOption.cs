//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：价格模板Sku搜索
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.04.28
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 价格模板Sku搜索
    /// </summary>
    public class PriceSkuOption
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Sku名称
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 选择 
        /// </summary>
        public bool Checked { get; set; }
    }
}
