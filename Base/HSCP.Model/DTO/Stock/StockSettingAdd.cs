//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016‎.‎06.02‎
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
    /// 库存设置添加
    /// </summary>
    public class StockSettingAdd
    {
        /// <summary>
        /// 产品id 
        /// </summary>
        public virtual int[] ProductId { get; set; }


        /// <summary>
        /// 产品名称
        /// </summary>
        public virtual string[] ProductName { get; set; }

        



        /// <summary>
        /// 分类id 
        /// </summary>
        public virtual int? ProductCategoryId { get; set; }

        /// <summary>
        /// 预警值
        /// </summary>

        public virtual string WarningValue { get; set; }

        /// <summary>
        /// 溢出值
        /// </summary>

        public virtual string OverflowValue { get; set; }






    }
}
