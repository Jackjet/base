using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum MethodPaymentEnum
    {
        支付宝 = 1,
        微信,
        银联,

        现金 = 20,
        股份POS机,
        服务POS机,

        股份银行转账,
        服务银行转账,
        业绩卡转账,
        股份支付宝,
        服务财付通,

        股份糯米,
        服务大众,

        第三方_糯米 = 50,
        第三方_淘宝,
        第三方_大众,
        第三方_美团

    }

}
