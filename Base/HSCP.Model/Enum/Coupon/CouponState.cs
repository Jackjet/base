using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 
    /// </summary>
    //public enum CouponState { 未激活 = 1, 已激活, 已使用, 已过期 }
    public enum CouponState {
        未绑定 = 1,
        已绑定,
        已使用,
        已过期
    }
    

}
