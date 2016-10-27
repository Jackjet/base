using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 订单状态枚举
    /// </summary>
    public enum OrderStateEnum
    {
        已接单 = 10,
        派单待确认 = 20,
        拒绝接单 = 30,
        已派单 = 40,
        执行中 = 50,
        开始服务 = 60,
        服务结束 = 70,
        已完成 = 80,
        已评价 = 90,
        已取消 = 99
    }


    /// <summary>
    /// 改价原因
    /// </summary>
    public enum OrdechangeEnum
    {
        客户原因 = 1,
        平台原因 = 2,
        员工原因 = 3
       
    }

    /// <summary>
    /// 结算标签
    /// </summary>
    public enum SettlementLabelEnum
    {
        未结算 = 1,
        已结算 = 2

    }

    /// <summary>
    /// 订单预报时报表的预报状态
    /// </summary>
    public enum OrderybEnum
    {
        不限 = 1,
        是 = 2,
        否 = 3

    }


}
