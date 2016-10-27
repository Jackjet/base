//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：
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
    /// 预库存
    /// </summary>
    public class PreStock : Entity<int>
    {

        /// <summary>
        /// 服务员工/车辆  类型
        /// </summary>
        [Description("服务员工/车辆  类型")]
        public virtual WaiterTypes WaiterType { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public virtual string BillNo { get; set; }
        /// <summary>
        /// 服务编号 （人员编号 /车辆编号）
        /// </summary>
        [Description("服务编号 （人员编号 /车辆编号）")]
        public virtual string  ServiceNo{ get; set; }

        /// <summary>
        /// 开始时间 
        /// </summary>
        [Description("开始时间")]
        public virtual DateTime? StartTime { get; set; }

        /// <summary>
        ///  结束时间 
        /// </summary>
        [Description("结束时间")]
        public virtual DateTime? EndTime { get; set; }

    }
}