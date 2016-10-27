//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 订单相关表
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
    /// 订单主表
    /// </summary>
    public partial class Order : Entity<int>
    {
        /// <summary>
        ///预约人数
        /// </summary>
        [Description("预约人数")]
        public virtual int? YjNum { get; set; }

        /// <summary>
        ///是否议价订单
        /// </summary>
        [Description("是否议价订单")]
        public virtual bool? IsYj { get; set; }


        /// <summary>
        /// 导数据过来的单号  3.0 的订单  原来的订单号  crm订单  对应的主键id  年卡订单 对应的卡号
        /// </summary>
        [Description("导数据过来的单号")]
        public virtual string DaoNo { get; set; }

        /// <summary>
        /// 原来 优惠券金额
        /// </summary>
        [Description("原来 优惠券金额")]
        public virtual decimal? SYHQAmount { get; set; }

        /// <summary>
        /// 导数据 有  true   没有  为空
        /// </summary>
        [Description("导数据")]
        public virtual bool? IsDao { get; set; }

        /// <summary>
        /// 是否手签 有  true   没有  为空
        /// </summary>
        [Description("是否手签")]
        public virtual bool? IsSign { get; set; }

        //客户反馈实际支付金额
        public virtual decimal? FeedbackAmount { get; set; }

        /// <summary>
        /// 已完成时间
        /// </summary>
        [Description("已完成时间")]
        public virtual DateTime? ByOveretime { get; set; }

        /// <summary>
        /// 派单员id
        /// </summary>
        [Description("派单员")]
        public virtual int? Singlemember { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        [Description("派单时间")]
        public virtual DateTime? Singletime { get; set; }

        /// <summary>
        /// 可退款金额
        /// </summary>
        [Description("可退款金额")]
        public virtual decimal? QAmount { get; set; } = 0;

        /// <summary>
        /// 部门id  -- 统计；数据权限
        /// </summary>
        [Description("部门id")]
        public virtual int? DepartId { get; set; } = 0;

        /// <summary>
        /// 员工备注
        /// </summary>
        [Description("员工备注")]
        public virtual string EmployRemark { get; set; }

        /// <summary>
        /// 总订单号
        /// </summary>
        [Description("总订单号")]
        public virtual string BillNo { get; set; }

        /// <summary>
        /// 订单状态  
        /// </summary>
        [Description("订单状态")]
        public virtual OrderStateEnum OrderState { get; set; }

        /// <summary>
        /// 订单金额     计算的金额        
        /// </summary>
        [Description("订单金额")]
        public virtual decimal TotalAmount { get; set; }

        /// <summary>
        /// 修改之后的总金额  - （总订单分单）  一般是和订单金额一样      
        /// </summary>
        [Description("修改之后的总金额")]
        public virtual decimal RealTotalAmount { get; set; }

        /// <summary>
        /// 客户付款金额（客户实际支付的金额）  实收金额   
        /// </summary>
        [Description("客户付款金额")]
        public virtual decimal Amount { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        [Description("申请时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        [Description("门店id")]
        public virtual int StoreId { get; set; }

        /// <summary>
        /// 业务渠道  (订单来源)
        /// </summary>
        [Description("业务渠道")]
        public virtual BusinessChannel BuChannel { get; set; }

        /// <summary>
        /// 开发人
        /// </summary>
        [Description("开发人")]
        public virtual string Developer { get; set; }
        /// <summary>
        /// 开发人费
        /// </summary>
        [Description("开发人费")]
        public virtual decimal? DevelopAmount { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        [Description("订单备注")]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 所属产品id  服务项目
        /// </summary>
        [Description("所属产品id")]
        public virtual int ProductId { get; set; }
        /// <summary>
        /// 产品名称(描述) 服务项目
        /// </summary>
        [Description("产品名称")]
        public virtual string ProductName { get; set; }

        /// <summary>
        /// sku 内容实体 json 格式 快照  项目下的全部sku 信息
        /// </summary>
        [Description("sku内容实体")]
        public virtual string SkuDetail { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        [Description("优先级")]
        public virtual OrderPriorityEnum Priority { get; set; }
        /// <summary>
        /// 服务员工等级
        /// </summary>
        [Description("服务员工等级")]
        public virtual int StaffVevel { get; set; }


        /// <summary>
        ///   薪酬结算人
        /// </summary>
        [Description("薪酬结算人")]
        public virtual int? PaySettlementPerson { get; set; }



        /// <summary>
        ///  薪酬结算
        /// </summary>
        [Description("薪酬结算")]
        public virtual SettlementLabelEnum PaySettlement { get; set; } = SettlementLabelEnum.未结算;
     
        /// <summary>
        ///   薪酬结算时间
        /// </summary>
        [Description("薪酬结算时间")]
        public virtual DateTime? PaySettlementTime { get; set; }

        /// <summary>
        ///  薪酬计算 (服务自动计算员工薪酬)
        /// </summary>
        [Description("是否计算工资")]
        public virtual bool IsPayoff { get; set; } = false;
        /// <summary>
        ///   薪酬计算
        /// </summary>
        [Description("计算时间")]
        public virtual DateTime? SettlementTime { get; set; }


        /// <summary>
        /// 是否集团单  true  是   false 否 
        /// </summary>
        [Description("是否集团单")]
        public virtual bool IsGroup { get; set; } = false;

        /// <summary>
        /// 是否集团单拆单过来的订单    true  是   false 否 
        /// </summary>
        [Description("是否集团单拆单过来的订单")]
        public virtual bool IsSplit { get; set; } = false;

        #region 集团单  拆单  
        /// <summary>
        /// 拆弹人id
        /// </summary>
        [Description("拆弹人id")]
        public virtual int? SplitUserId { get; set; }

        /// <summary>
        /// 拆弹人
        /// </summary>
        [Description("拆弹人")]
        public virtual string SplitUserName { get; set; }

        /// <summary>
        /// 拆单时间
        /// </summary>
        [Description("拆单时间")]
        public virtual DateTime? SplitTime { get; set; }

        /// <summary>
        /// 拆单数量
        /// </summary>
        [Description("拆单数量")]
        public virtual int? SplitNum { get; set; }
        /// <summary>
        /// 拆单数量
        /// </summary>
        [Description("可拆单数量")]
        public virtual int? TotalSplitNum { get; set; }
        #endregion

        /// <summary>
        /// 预约服务开始时间
        /// </summary>
        [Description("预约服务开始时间")]
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 预约服务结束时间  预留
        /// </summary>
        [Description("预约服务结束时间")]
        public virtual DateTime? EndTime { get; set; }
        /// <summary>
        /// 真实服务开始时间  集团单 合同开始时间
        /// </summary>
        [Description("真实服务开始时间")]
        public virtual DateTime? RealStartTime { get; set; }
        /// <summary>
        /// 真实服务结束时间  集团单 合同结束时间
        /// </summary>
        [Description("真实服务结束时间")]
        public virtual DateTime? RealEndTime { get; set; }

        /// <summary>
        /// 薪酬是否修改  
        /// </summary>
        [Description("薪酬是否修改")]
        public virtual bool IsmodWages { get; set; } = false;

        /// <summary>
        /// 是否网络前台下单
        /// </summary>
        public virtual bool? IsNet { get; set; }

    }
}