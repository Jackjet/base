using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 列表实体
    /// </summary>
    [NotMapped]

    public class OrderViewModel : Order
    {


        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 会员标签
        /// </summary>
        public string Tags { get; set; }


        /// <summary>
        /// 门店
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 是否欠款
        /// </summary>
        public string IsArrears { get; set; }


        /// <summary>
        /// 是否退款
        /// </summary>
        public string IsTks { get; set; }
        
        ///// <summary>
        ///// 服务开始时间
        ///// </summary>
        //public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public virtual string Street { get; set; }

        /// <summary>
        /// 拆单状态
        /// </summary>
        public virtual string  SplitName { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public virtual string codestr { get; set; }
        /// <summary>
        /// 少于两个员工编号
        /// </summary>
        public virtual string codetwo { get; set; }
        /// <summary>
        /// 多于两个员工编号
        /// </summary>
        public virtual string codemor { get; set; }

      


        /// <summary>
        /// 员工数量
        /// </summary>
        public virtual int codenum { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual string content { get; set; }


    }
    /// <summary>
    /// 结算列表实体
    /// </summary>
    [NotMapped]

    public class OrderSettlementViewModel : Order
    {
        /// <summary>
        /// 门店
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 会员账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 员工薪酬
        /// </summary>
        public List<OrderWages> OrderWage { get; set; } = new List<OrderWages>();
        /// <summary>
        /// excel泛型中使用到的员工薪酬
        /// </summary>
        public string TOrderWage { get; set; }
        /// <summary>
        /// 薪酬结算人
        /// </summary>
        public string PaySettlementPersonName { get; set; }

    }
    /// <summary>
    /// 退款列表实体
    /// </summary>
    [NotMapped]

    public class OrderRefundViewModel : Order
    {
        /// <summary>
        /// 门店
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 会员账户
        /// </summary>
        public string Account { get; set; }
    }
    /// <summary>
    /// 订单预报时报表实体
    /// </summary>
    [NotMapped]

    public class OrderybViewModel : Order
    {
        /// <summary>
        /// 门店
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public virtual string codestr { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public virtual string Street { get; set; }
        /// <summary>
        /// 少于两个员工编号
        /// </summary>
        public virtual string codetwo { get; set; }
        /// <summary>
        /// 多于两个员工编号
        /// </summary>
        public virtual string codemor { get; set; }
    }
}
