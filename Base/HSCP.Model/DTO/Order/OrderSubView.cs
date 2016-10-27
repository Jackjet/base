//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：子订单 非主
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.23
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using Conan.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    ///  子订单 非主
    /// </summary>
      [NotMapped]
    public partial class OrderSubView : OrderSub
    {

        /// <summary>
        ///  服务员工/车辆
        /// </summary>
        public virtual string  ServiceName { get; set; }

        /// <summary>
        /// SKU
        /// </summary>
        public virtual string  SKU { get; set; }


       








    }
}