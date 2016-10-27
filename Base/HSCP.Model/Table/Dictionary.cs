using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    public class Dictionary : Entity<int>
    {
        /// <summary>
        /// 类型
        /// </summary>
        [Description("类型")]
        public virtual DictionaryEnum TypeValue { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        [Description("类型名称")]
        public virtual string TypeText { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        public virtual string Text { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        [Description("属性")]
        public virtual string Option { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        public virtual string Img { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        [Description("是否隐藏")]
        public virtual bool IsHide { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }
        /// <summary>
        /// 是否可编辑
        /// </summary>
        [Description("是否可编辑")]
        public virtual bool IsEditable { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        [Description("是否默认")]
        public virtual bool IsDefault { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public virtual int Sort { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}
