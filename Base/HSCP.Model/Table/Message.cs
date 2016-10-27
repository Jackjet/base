/*
 * 作者：Ldw    
 * 日期：2016.06.18  
 * 描述：消息中心
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    ///消息中心
    /// </summary>
    public class Message : Entity<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题")]
        public virtual string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Description("内容")]
        public virtual string MessageContent { get; set; }
        /// <summary>
        /// 推送人
        /// </summary>
        [Description("推送人")]
        public virtual string PushPeople { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 阅读时间
        /// </summary>
        [Description("阅读时间")]
        public virtual DateTime? ReadTime { get; set; }
        /// <summary>
        /// 接收人
        /// </summary>
        [Description("接收人")]
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public virtual MessageEnum State { get; set; }
    }
}