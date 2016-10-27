using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 订单拆单 添加
    /// </summary>
    public class OrderSpAdd
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string BillNo { get; set; }

        /// <summary>
        /// 新产品id
        /// </summary>
        public virtual int[] newpid { get; set; }



        /// <summary>
        /// sku1
        /// </summary>
        public virtual string[] sku1 { get; set; }



        /// <summary>
        /// sku2
        /// </summary>
        public virtual string[] sku2 { get; set; }


        /// <summary>
        /// sku3
        /// </summary>
        public virtual string[] sku3 { get; set; }


        /// <summary>
        /// 服务时间
        /// </summary>
        public virtual string[] CreateTime { get; set; }


        /// <summary>
        /// 开始时段
        /// </summary>
        public virtual string[] StartTime { get; set; }

        /// <summary>
        /// 结束时段
        /// </summary>
        public virtual string[] EndTime { get; set; }


        /// <summary>
        /// 销售id1
        /// </summary>
        public virtual int[] saleid1 { get; set; }


        /// <summary>
        /// 销售id2
        /// </summary>
        public virtual int[] saleid2 { get; set; }


        /// <summary>
        /// 销售值1
        /// </summary>
        public virtual int[] salenum1 { get; set; }


        /// <summary>
        /// 销售值2
        /// </summary>
        public virtual int[] salenum2 { get; set; }

        /// <summary>
        /// 改动后的价格
        /// </summary>
        public virtual string[] Sprice { get; set; }



        public virtual  List<OrderSpAdddetail>   ServiceNolist { get; set; }

      



    }

    public class OrderSpAdddetail
    {
        public virtual string[] ServiceNo { get; set; }

    }
}
