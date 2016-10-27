using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 指定人员车辆添加
    /// </summary>
  

    public class OrderWaiterAdd
    {

        /// <summary>
        /// 车辆编号 类型=车辆
        /// </summary>
        public virtual string[] CCode { get; set; }



        /// <summary>
        /// 司机编号 类型=车辆
        /// </summary>
        public virtual string[] CarCode { get; set; }


        /// <summary>
        /// 服务员工/车辆  类型
        /// </summary>

        public virtual int[] WaiterType { get; set; }

        /// <summary>
        /// 子订单号
        /// </summary>
     
        public virtual string  BillItemNo { get; set; }
        /// <summary>
        /// 服务编号 （人员编号 /车辆编号）
        /// </summary>
      
        public virtual string[] ServiceNo { get; set; }

        /// <summary>
        /// 服务名称（人员名称/司机）
        /// </summary>
     
        public virtual string[] ServiceName { get; set; }
        /// <summary>
        /// 服务人员手机号
        /// </summary>
      
        public virtual string[] Tel { get; set; }




        /// <summary>
        /// 是否队长  true  是  false  否
        /// </summary>
      
        public virtual string   IsLeader { get; set; }


        /// <summary>
        /// 是否指定员工  true  是  false  否
        /// </summary>

        public virtual string[] IsSpecify { get; set; }


    }
}
