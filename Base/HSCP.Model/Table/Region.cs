using Conan.Core;
using System;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 区域  大区
    /// </summary>
    public partial class Region : Entity<int>
    {
        /// <summary>
        /// 地区名称
        /// </summary>
        [Description("地区名称")]
        public virtual string Name { get; set; }

        /// <summary>
        /// 名称拼音
        /// </summary>
        [Description("名称拼音")]
        public virtual string Pinyin { get; set; }

        /// <summary>
        /// 状态  1 是 0  否
        /// </summary>
        [Description("状态")]
        public virtual int State { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public virtual int Sort { get; set; }




    }
}

