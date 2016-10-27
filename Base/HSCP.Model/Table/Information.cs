/*
 * 作者：Ldw    
 * 日期：2016.06.27
 * 描述：咨讯
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 咨讯
    /// </summary>
    public class Information : Entity<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题")]
        public virtual string Title { get; set; }
        /// <summary>
        /// 显示渠道
        /// </summary>
        [Description("显示渠道")]
        public virtual string Channel { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public virtual string Describe { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        public virtual string Img { get; set; }
        /// <summary>
        /// 显示类型  图文资讯=0,链接跳转=1
        /// </summary>
        [Description("显示类型")]
        public virtual int DisplayType { get; set; }
        /// <summary>
        /// 链接跳转
        /// </summary>
        [Description("链接跳转")]
        public virtual string TypeUrl { get; set; }
        /// <summary>
        /// 图文资讯
        /// </summary>
        [Description("图文资讯")]
        public virtual string TypeContent { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        public virtual DateTime UpdateTime { get; set; }
    }
}