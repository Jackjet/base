using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 库存状态
    /// </summary>
    public enum InventoryEnum
    {
        可服务 = 1,
        占用 = 0,
        预派 = 2,
    }
 
}
