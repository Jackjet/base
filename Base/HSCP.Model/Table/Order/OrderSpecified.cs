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
using System.Collections.Generic;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 下单指定员工/车辆表
    /// </summary>
    public class OrderSpecified : Entity<int>
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [Description("订单编号")]
        public virtual string BillNo { get; set; }

        /// <summary>
        /// 员工编号/车牌号
        /// </summary>
        [Description("员工编号/车牌号")]
        public virtual string ServiceNo { get; set; }

        /// <summary>
        /// 服务员工/车辆  类型
        /// </summary>
        [Description("服务员工/车辆")]
        public virtual WaiterTypes WaiterType { get; set; }
    }
}
