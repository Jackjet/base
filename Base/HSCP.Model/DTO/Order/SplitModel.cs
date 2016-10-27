using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Conan.Core;
using Conan.Model;
using System;

namespace Conan.Model
{
    /// <summary>
    /// 已拆单列表
    /// </summary>
    public class SplitModel 
    {


        /// <summary>
        /// 指定服务
        /// </summary>
        public virtual string zdservice { get; set; }


        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string BillNo { get; set; }

        /// <summary>
        /// 服务日期 开始
        /// </summary>
        public virtual  DateTime  stime { get; set; }


        /// <summary>
        /// 服务日期 结束
        /// </summary>
        public virtual DateTime etime { get; set; }

        /// <summary>
        /// 订单状态  
        /// </summary>
        public virtual OrderStateEnum OrderState { get; set; }



        /// <summary>
        /// 销售
        /// </summary>
        public virtual string  salestr { get; set; }


        /// <summary>
        /// 金额
        /// </summary>
        public virtual string awge { get; set; }



    }


}