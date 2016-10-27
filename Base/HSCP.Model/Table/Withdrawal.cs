using System;
using System.Text;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
    public partial class Withdrawal : Entity<int>
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        [Description("客户编号")]
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 客户账号
        /// </summary>
         [Description("客户账号")]
        public virtual string Account { get; set; }
        /// <summary>
        /// 提现时间
        /// </summary>
        [Description("提现时间")]
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 提现操作人账号
        /// </summary>
        [Description("操作人")]
        public virtual string WithdrawalPeople { get; set; }
        /// <summary>
        /// 提现类型 -0：后台员工提现 1：会员自己提现
        /// </summary>
        [Description("提现类型")]
        public virtual int WithdrawalType { get; set; }
        /// <summary>
        /// 提现原因
        /// </summary>
        [Description("提现原因")]
        public virtual string WithdrawalWhy { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [Description("账户余额")]
        public virtual decimal Amount { get; set; }
        /// <summary>
        /// 提现金额
        /// </summary>
        [Description("提现金额")]
        public virtual decimal WithdrawalAmount { get; set; }
        /// <summary>
        /// 是否已经操作了退款 
        /// </summary>
        [Description("反馈状态")]
        public bool IsOperation { get; set; }
        /// <summary>
        /// 打款时间
        /// </summary>
        [Description("打款时间")]
        public virtual DateTime? HitTime { get; set; }
        /// <summary>
        /// 打款操作人
        /// </summary>
        [Description("打款操作人")]
        public virtual string HitlPeople { get; set; }

    }
}