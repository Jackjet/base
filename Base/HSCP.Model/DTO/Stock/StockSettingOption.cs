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
    /// 库存设置条件查询
    /// </summary>
    public class StockSettingOption
    {
     
        /// <summary>
        /// 分类id 
        /// </summary>
        public virtual int? ProductCategoryId { get; set; }
     
    }



    /// <summary>
    /// 库存条件查询
    /// </summary>
    public class StockOption
    {


        /// <summary>
        /// 区域id
        /// </summary>
        public int AreaId { get; set; }



        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductId { get; set; }



        /// <summary>
        /// 隐藏的input判断次数
        /// </summary>
        public virtual int firstselect { get; set; } = 0;
        /// <summary>
        /// 分类id 
        /// </summary>
        public virtual int ProductCategoryId { get; set; }


        /// <summary>
        /// 门店id 
        /// </summary>
        public virtual int? StoreId { get; set; }


        /// <summary>
        /// 时间 
        /// </summary>
        public virtual DateTime? CreTime { get; set; } 



    }



}
