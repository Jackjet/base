/****************************************************** 

    文件名称：SkuTime.cs
    功能描述：sku 对应 服务时间段 
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// sku 对应 服务时间段 
    /// </summary>
    public class SkuTime : Entity<int>
    {
        /// <summary>
        /// 服务产品Id
        /// </summary>
        public virtual int ProductId { get; set; }
        /// <summary>
        /// 周几
        /// </summary>
        public virtual DayOfWeek Week { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual TimeSpan StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual TimeSpan EndTime { get; set; }
        /// <summary>
        /// 时间段
        /// </summary>
        public virtual int TimeSlotNo { get; set; }
    }
}
