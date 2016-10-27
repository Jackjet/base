/*
 * 作者：Ldw    
 * 日期：2016.06.20
 * 描述：渠道管理
 * 修改记录：    
 * */
using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 渠道
    /// </summary>
    public class Channel : Entity<int>
    {
        /// <summary>
        /// 渠道名称
        /// </summary>
        public virtual string ChannelName { get; set; }
        
        /// <summary>
        /// 专享码
        /// </summary>
        public virtual string Code { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
    }
}