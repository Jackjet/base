/****************************************************** 

    文件名称：PriceTempletItem.cs
    功能描述：价格模板详情
    作    者：Jxw
    日    期：2016.05.11
    修改记录：

*******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 价格模板时间段
    /// </summary>
    public class PriceTempletTime : Entity<int>
    {
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
    }
}
