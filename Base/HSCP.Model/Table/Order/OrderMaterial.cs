//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单材料
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 订单材料
    /// </summary>
    public partial class OrderMaterial : Entity<int>
    {
        /// <summary>
        /// 材料编号
        /// </summary>
        [Description("材料编号")]
        public virtual string Code { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
        [Description("材料名称")]
        public virtual string Name { get; set; }


        /// <summary>
        /// 材料金额 单价
        /// </summary>
        [Description("材料")]
        public virtual decimal Wage { get; set; }




        /// <summary>
        /// 材料金额 总价
        /// </summary>
        [Description("材料总金额")]
        public virtual decimal TotalWage { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        public virtual decimal Num { get; set; }




        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        public virtual string Unit { get; set; }

        

        /// <summary>
        /// 子订单号
        /// </summary>
        [Description("子订单号")]
        public virtual string BillItemNo { get; set; }

        

    }
}