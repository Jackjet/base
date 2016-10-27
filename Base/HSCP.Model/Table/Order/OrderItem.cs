//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单相关表
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
    /// 子订单明细表
    /// </summary>
    public partial class OrderItem : Entity<int>
    {
        /// <summary>
        /// 子订单编号
        /// </summary>
        [Description("子订单编号")]
        public virtual string BillItemNo { get; set; }

        /// <summary>
        /// 下单时的skuid 
        /// </summary>
        [Description("下单时的skuid")]
        public virtual int SkuId { get; set; }
        /// <summary>
        /// sku 内容实体 json 格式    
        /// </summary>
        [Description("sku 内容实体")]
        public virtual string SkuDes { get; set; }



        /// <summary>
        /// 金额  计算总的金额    
        /// </summary>
        [Description("金额")]
        public virtual decimal TotalAmount { get; set; }



        /// <summary>
        /// 排序 
        /// </summary>
        [Description("排序")]
        public virtual int Sort { get; set; }



    }
}