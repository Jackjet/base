
using System;
using System.Collections.Generic;
namespace Conan.Model
{
    /// <summary>
    /// 条件实体
    /// </summary>
    public class OrderTkOption
    {

     
        /// <summary>
        /// 总订单号
        /// </summary>
        public string BillNo { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public virtual string No { get; set; }


        /// <summary>
        /// 退款状态
        /// </summary>
        public virtual int tkstatus { get; set; }



        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }
      
    }



    /// <summary>
    /// 退钱操作
    /// </summary>
    public class OrderTkModel2
    {
        /// <summary>
        /// 总订单号
        /// </summary>
        public virtual string BillNo { get; set; }



        /// <summary>
        ///子单号
        /// </summary>
        public List<OrderTkitem> PromoterList { get; set; } = new List<OrderTkitem>();



        /// <summary>
        /// 子单号
        /// </summary>
        public virtual string[] BillitemNo { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public virtual string[] BillitemNoamount { get; set; }



        public virtual int[] id { get; set; }


        public virtual int[] btype { get; set; }




    }
    public class OrderTkitem
    {

        public virtual string BillitemNo { get; set; }

        public virtual int id { get; set; }


        public virtual int btype { get; set; }

        public virtual string decname { get; set; }


        public virtual string BillitemNoamount { get; set; }
    }

    }
 