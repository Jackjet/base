
using System;
using System.Collections.Generic;
namespace Conan.Model
{
    /// <summary>
    /// 条件实体
    /// </summary>
    public class OrderOption
    {

        public string remark { get; set; }


        public string fremark { get; set; }



        /// <summary>
        ///开单人
        /// </summary>
        public string kdr { get; set; }

        /// <summary>
        ///导数据单号
        /// </summary>
        public string DaoNo { get; set; }


        /// <summary>
        /// 是否退款 1 是 0  否
        /// </summary>
        public int IsTk { get; set; }



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

        public virtual int lblId { get; set; }


        /// <summary>
        /// 订单状态  
        /// </summary>
        public virtual int OrderState { get; set; }


        public virtual int BuChannel { get; set; } = -1;


        /// <summary>
        /// 是否欠款 1 是 0  否
        /// </summary>
        public int IsArrears { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; }

        /// <summary>
        /// 会员账号
        /// </summary>
        public virtual string Account { get; set; }


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
        /// <summary>
        /// 员工编号
        /// </summary>
        public virtual string EmployeeNo { get; set; }
        /// <summary>
        /// 结算标签
        /// </summary>
        public virtual SettlementLabelEnum SettlementLabel { get; set; }
        /// <summary>
        /// 工作性质
        /// </summary>
        public virtual WorkingPropertys WorkingPropertys { get; set; }
        /// <summary>
        /// 是否是结算界面
        /// </summary>
        public virtual bool IsSettlement { get; set; } = false;

        /// <summary>
        /// 是否可派单
        /// </summary>
        public bool? IsOK { get; set; }

    }

    /// <summary>
    /// 订单结算条件实体
    /// </summary>
    public class OrderSettlementOption
    {
        /// <summary>
        /// 总订单号
        /// </summary>
        public string BillNo { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public virtual int StoreId { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; }

        /// <summary>
        /// 会员账号
        /// </summary>
        public virtual string Account { get; set; }

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
        /// 薪酬结算开始时间
        /// </summary>
        public virtual DateTime? StartPaySettlement { get; set; }
        /// <summary>
        /// 薪酬结算结束时间
        /// </summary>
        public virtual DateTime? EndPaySettlement { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public virtual string EmployeeNo { get; set; }
        /// <summary>
        /// 结算人
        /// </summary>
        public virtual string PaySettlementPerson { get; set; }



        /// <summary>
        /// 标签
        /// </summary>
        public virtual int lblId { get; set; }
        


        /// <summary>
        /// 结算标签
        /// </summary>
        public virtual SettlementLabelEnum? SettlementLabel { get; set; }
        /// <summary>
        /// 工作性质
        /// </summary>
        public virtual WorkingPropertys WorkingPropertys { get; set; }
        /// <summary>
        /// 是否是结算界面
        /// </summary>
        public virtual bool IsSettlement { get; set; } = false;
    }
}
 