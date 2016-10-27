/****************************************************** 

    文件名称：PriceTemplet.cs
    功能描述：价格模板
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
    public class PriceTemplet : Entity<int>
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        [Description(" 价格模板名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Description("开始时间")]
        public virtual DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Description("结束时间")]
        public virtual DateTime EndTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public virtual PriceTempletStateEnum State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>
        [Description("编辑时间")]
        public virtual DateTime EditTime { get; set; }
    }
}
