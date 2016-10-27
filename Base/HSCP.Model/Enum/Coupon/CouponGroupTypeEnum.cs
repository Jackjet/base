using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public enum CouponGroupTypEnum
    {
        所有 = 1,
        免费,
        付费
    }
    public enum CouponType
    {
        未绑定 = 1,
        已绑定,
        已使用,
        已过期
    }
}
