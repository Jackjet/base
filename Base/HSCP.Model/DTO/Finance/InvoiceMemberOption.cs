using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class InvoiceMemberOption
    {

        public string Account { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public int? MemberId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 账号余额（开始）
        /// </summary>
        public decimal? AccountBalanceBegin { get; set; }
        /// <summary>
        /// 账号余额（结束）
        /// </summary>
        public decimal? AccountBalanceEnd { get; set; }
        /// <summary>
        /// 注册时间（开始）
        /// </summary
        public virtual DateTime? RegisterTimeBegin { get; set; }
        /// <summary>
        /// 注册时间(结束)
        /// </summary>
        public virtual DateTime? RegisterTimeEnd { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual MemberState State { get; set; }
    }
}
