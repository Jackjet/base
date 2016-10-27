//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：资金流水
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
#region using
using System;
using Conan.Core;
using System.ComponentModel;
#endregion

namespace Conan.Model
{
    /// <summary>
    /// 资金流水
    /// </summary>
 
    public partial class CashJournal : Entity<int>
    {
        /// <summary>
        /// 交易编号
        /// </summary>
        [Description("交易编号")]
        public virtual string TraNumber { get; set; }


        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 账号余额 操作前
        /// </summary>
        [Description("账号余额")]
        public virtual decimal MemberAccount { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        [Description("操作")]
        public virtual GenreEnum Genre { get; set; }
        /// <summary>
        /// 发生金额 
        /// </summary>
        [Description("发生金额")]
        public virtual decimal ChangeAmount { get; set; }
        /// <summary>
        /// 操作后  剩余金额 
        /// </summary>
        [Description("剩余金额")]
        public virtual decimal Amount { get; set; }

        /// <summary>
        /// 门店Id
        /// </summary>
        [Description("门店Id")]
        public virtual int? StoreId { get; set; }
        /// <summary>
        /// 单据号
        /// </summary>
        [Description("单据号")]
        public virtual string RelationId { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public PayTypes PaytType { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        [Description("交易时间")]
        public virtual DateTime CreateTime { get; set; }


    }
}

