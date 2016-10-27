using System;
using System.Collections.Generic;
namespace Conan.Model
{
    /// <summary>
    /// 条件实体
    /// </summary>
    public class MemberOrderOption
    {

        /// <summary>
        /// 会员ID
        /// </summary>
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 拆单状态    1 已拆单  2  未拆单 0  不限
        /// </summary>
        public virtual int SplitState { get; set; }


        /// <summary>
        /// 总订单号
        /// </summary>
        public string BillNo { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public virtual int StoreId { get; set; }
        /// <summary>
        /// 订单状态  
        /// </summary>
        public virtual int OrderState { get; set; }
        /// <summary>
        /// 是否欠款 1 是 0  否
        /// </summary>
        public int IsArrears { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public virtual string Street { get; set; }

        /// <summary>
        /// 所属类型  服务项目
        /// </summary>
        public virtual int ServiceId { get; set; }


        /// <summary>
        /// 所属产品id  服务项目
        /// </summary>
        public virtual int ProductId { get; set; }
        /// <summary>
        /// 服务开始时间
        /// </summary>
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 服务结束时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }
        /// <summary>
        /// 结束申请时间
        /// </summary>
        public virtual DateTime? EndCreateTime { get; set; }
    }
}
 