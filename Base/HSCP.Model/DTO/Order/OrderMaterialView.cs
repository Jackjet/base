
using System;
using System.Collections.Generic;
namespace Conan.Model
{
    /// <summary>
    /// 可选项
    /// </summary>
    public class OrderMaterialView
    {
        /// <summary>
        /// 材料编号
        /// </summary>
     
        public virtual string OrderMaterialCode { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
      
        public virtual string OrderMaterialName { get; set; }


        /// <summary>
        /// 材料金额（单价）
        /// </summary>
       
        public virtual string OrderMaterialWage { get; set; }

        /// <summary>
        /// 材料金额 总价
        /// </summary>

        public virtual string  OrderMaterialTotalWage { get; set; }


        /// <summary>
        /// 数量
        /// </summary>

        public virtual string  OrderMaterialNum { get; set; }




        /// <summary>
        /// 单位
        /// </summary>

        public virtual string  OrderMaterialUnit { get; set; }

    }
}
 