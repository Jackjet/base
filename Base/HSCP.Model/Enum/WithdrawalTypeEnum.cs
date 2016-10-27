using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 提现方式
    /// </summary>
    public enum WithdrawalType
    {
        未知 = 0,
        现金提现,
        银行转账,
        微信转帐,
        支付宝转帐,
        原路退回,
        清零
    }
}
