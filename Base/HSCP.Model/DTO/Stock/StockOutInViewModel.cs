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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conan.Model
{
    /// <summary>
    /// 库存列表
    /// </summary>
  
    public class StockOutInViewModel 
    {

        public virtual int ProductId { get; set; }


        /// <summary>
        ///产品名称
        /// </summary>
        public virtual string ProductName{ get; set; }

        public virtual List<StockOutInViewModelitem> StockOutInViewModelitemList { get; set; }

    }

    public class StockOutInViewModelitem 
    {
        /// <summary>
        /// 时间
        /// </summary>
    public virtual TimeSpan StartTime { get; set; }
    /// <summary>
    /// 库存
    /// </summary>
    public virtual int TotalInventory { get; set; }
    /// <summary>
    /// 占用库存
    /// </summary>
    public virtual int OccupyInventory { get; set; }
}
}
