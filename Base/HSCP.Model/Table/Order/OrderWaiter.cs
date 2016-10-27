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
    /// 服务人员/车辆表
    /// </summary>
    public class OrderWaiter : Entity<int>
    {



        /// <summary>
        ///  库存开始时间
        /// </summary>
    
        public virtual DateTime? KStime { get; set; }



        /// <summary>
        ///  库存结束时间
        /// </summary>

        public virtual DateTime? KEtime { get; set; }




        /// <summary>
        /// 服务员工/车辆  类型
        /// </summary>
        [Description("服务员工/车辆  类型")]
        public virtual WaiterTypes WaiterType { get; set; }

        /// <summary>
        /// 子订单号
        /// </summary>
        [Description("子订单号")]
        public virtual string BillItemNo { get; set; }
        /// <summary>
        /// 服务编号 （人员编号 /车辆编号）
        /// </summary>
        [Description("服务编号 （人员编号 /车辆编号）")]
        public virtual string  ServiceNo{ get; set; }



        /// <summary>
        /// 司机编号  类型为车辆起作用
        /// </summary>
        [Description("司机编号")]
        public virtual string CarCode { get; set; }


        /// <summary>
        /// 车辆编号  类型为车辆起作用
        /// </summary>
        [Description("车辆编号")]
        public virtual string CCode { get; set; }



        /// <summary>
        /// 服务名称（人员名称/司机）
        /// </summary>
        [Description("服务名称（人员名称/司机）")]
        public virtual string ServiceName { get; set; }
        /// <summary>
        /// 服务人员手机号
        /// </summary>
        [Description("服务人员手机号")]
        public virtual string Tel { get; set; }




        /// <summary>
        /// 是否队长  true  是  false  否
        /// </summary>
        [Description("是否队长")]
        public virtual bool? IsLeader { get; set; }


        /// <summary>
        /// 是否指定员工  true  是  false  否
        /// </summary>
        [Description("是否指定员工")]
        public virtual bool? IsSpecify { get; set; }



        /// <summary>
        /// 理论开始时间 （员工实时库存）
        /// </summary>
        [Description("理论开始时间")]
        public virtual DateTime? YStartTime { get; set; }


        /// <summary>
        ///  理论结束时间 （员工实时库存）
        /// </summary>
        [Description("理论结束时间")]
        public virtual DateTime? YEndTime { get; set; }

        #region 预报时

        /// <summary>
        /// 开始时间
        /// </summary>
        [Description("开始时间")]
        public virtual DateTime? StartTime { get; set; }


        /// <summary>
        /// 预计结束时间
        /// </summary>
        [Description("预计结束时间")]
        public virtual DateTime? EndTime { get; set; }

        #endregion





        /// <summary>
        ///  派单时间
        /// </summary>
        [Description("派单时间")]
        public virtual DateTime? CreTime { get; set; }


        /// <summary>
        ///  派单人
        /// </summary>
        [Description("派单人")]
        public virtual string CreUser { get; set; }


        /// <summary>
        ///  唯一标识
        /// </summary>
        [Description("唯一标识")]
        public virtual bool IsFlag { get; set; }


        /// <summary>
        ///  订单号 
        /// </summary>
        [Description("订单号")]
        public virtual string BillNo { get; set; }



        /// <summary>
        ///  实际完成时间
        /// </summary>
        [Description("实际完成时间")]
        public virtual DateTime? RealEndTime { get; set; }

    }
}