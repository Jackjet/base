using System;
using Conan.Core;

namespace Conan.Model
{

    /// <summary>
    ///  发票
    /// </summary>
    public partial class Invoice : Entity<int>
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public virtual int MemberId { get; set; }

        /// <summary>
        /// 发票状态
        /// </summary>
        public virtual InvoiceStateEnum InvoiceState { get; set; }
        /// <summary>
        /// 发票类型
        /// </summary>
        public virtual int InvoiceType { get; set; }
        /// <summary>
        /// 发票类型名称
        /// </summary>
        public virtual string InvoiceTypeName { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public virtual string Header { get; set; }
        /// <summary>
        /// 发票编号
        /// </summary>
        public virtual string InvoiceCode { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public virtual decimal Amount { get; set; }

 
        /// <summary>
        /// 发票项目   --保洁 搬家 技术
        /// </summary>
        public virtual string ProjectTitle { get; set; }
        /// <summary>
        /// 税点
        /// </summary>
        public virtual decimal TaxPoint { get; set; }
        /// <summary>
        /// 投递方式  枚举 DeliveryTypeEnum
        /// </summary>
        public virtual DeliveryTypeEnum DeliveryType { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public virtual string ContactName { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public virtual string Proposer { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        public virtual string OrderIds { get; set; }

        /// <summary>
        /// 保持开票对应的，充值记录，在报废后需要还原开票状态
        /// </summary>
        public virtual string PaymentIds { get; set; }


        public virtual DateTime CreateTime { get; set; }

        public virtual DateTime? ScrappedTime { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public virtual int OperationId { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>

        public virtual string OperationName { get; set; }
    }
}