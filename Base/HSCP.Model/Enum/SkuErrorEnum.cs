using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public enum SkuErrorEnum
    {
        正常 = 0,
        产品的价格不服务,
        服务时间不存在,
        服务地区不存在,
        服务时间和服务地区不服务,
        Sku不存在
    }
}
