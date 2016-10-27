using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 流水操作
    /// </summary>
    public enum GenreEnum
    {
        提现 =2,
        充值 = 3,
        //订单
        消费 = 4,
        充值赠送=5,
        退款 = 99,
        扣款=100
       
    }
}
