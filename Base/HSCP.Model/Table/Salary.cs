using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 员工薪酬计算
    /// </summary>
    public class Salary : Entity<int>
    {
        /// <summary>
        /// 产品编号 
        /// </summary>
        [Description("产品ID")]
        public virtual int? ProductId { get; set; }
        /// <summary>
        /// 产品分类编号 
        /// </summary>
        [Description("产品分类ID")]
        public virtual int ProductCategoryId { get; set; }

        //队长附加提成   队长 总提成 =队长附加提成+普通员工提成

        /// <summary>
        /// 队长附加(好评)提成 
        /// </summary>
        [Description("队长附加(好评)提成")]
        public virtual float LeaderGood { get; set; }
        /// <summary>
        /// 队长附加(差评)提成
        /// </summary>
        [Description("队长附加(差评)提成")]
        public virtual float LeaderBad { get; set; }
        /// <summary>
        /// 全职(好评) 提成
        /// </summary>
        [Description("全职(好评)提成")]
        public virtual float OrdinaryGood { get; set; }
        /// <summary>
        /// 全职 (差评)提成
        /// </summary>
        [Description("全职(差评)提成")]
        public virtual float OrdinaryBad { get; set; }
        /// <summary>
        /// 兼职(好评) 提成
        /// </summary>
        [Description("兼职(好评)提成")]
        public virtual float ParttimeGood { get; set; }
        /// <summary>
        /// 兼职(差评)提成
        /// </summary>
        [Description("兼职(差评)提成")]
        public virtual float ParttimeBad { get; set; }
    }
}