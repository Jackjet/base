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
    /// 服务人员/车辆薪酬
    /// </summary>
    public class OrderWages : Entity<int>
    {

        /// <summary>
        /// 薪酬类型
        /// </summary>
        [Description("薪酬类型")]
        public virtual WaiterTypeList WaiterType { get; set; }


        /// <summary>
        /// 子订单号
        /// </summary>
        [Description("子订单号")]
        public virtual string  BillItemNo { get; set; }



        /// <summary>
        /// 服务员工/车辆 编号
        /// </summary>
        [Description("服务员工/车辆 编号")]
        public virtual string ServiceNo { get; set; }

        /// <summary>
        /// 服务名称（人员名称/司机）
        /// </summary>
        [Description("服务名称")]
        public virtual string ServiceName { get; set; }




        ///// <summary>
        ///// 实际得到的金额
        ///// </summary>
        [Description("实际得到的金额")]
        public virtual decimal? RealWage { get; set; }

        /// <summary>
        /// 薪酬  按照比例计算  应得的金额
        /// </summary>
        [Description("薪酬")]
        public virtual decimal? Wage { get; set; }


        /// <summary>
        /// 订单金额
        /// </summary>
        [Description("订单金额")]
        public virtual decimal? OrderWage { get; set; }


        /// <summary>
        /// 计提金额
        /// </summary>
        [Description("计提金额")]
        public virtual decimal? GetWage { get; set; }


        /// <summary>
        ///  创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime? CreTime { get; set; }


        /// <summary>
        ///  材料编号
        /// </summary>
        [Description("材料编号")]
        public virtual string OrderMaterialCode { get; set; }




        /// <summary>
        ///  订单号 
        /// </summary>
        [Description("订单号")]
        public virtual string BillNo { get; set; }



        /// <summary>
        ///  人员编号 
        /// </summary>
        [Description("人员编号")]
        public virtual string No { get; set; }

    }
}