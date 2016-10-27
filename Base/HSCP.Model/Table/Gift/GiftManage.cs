/*
 * 作者：Ldw    
 * 日期：2016.07.26  
 * 描述：礼品管理
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 礼品管理
    /// </summary>
    public class GiftManage : Entity<int>
    {
        /// <summary>
        /// 礼品名称
        /// </summary>
        [Description("礼品名称")]
        public virtual string GiftName { get; set; }
        /// <summary>
        /// 礼品名称
        /// </summary>
        [Description("礼品简称")]
        public virtual string SimpleName { get; set; }
        /// <summary>
        /// 礼品类型
        /// </summary>
        [Description("礼品类型")]
        public virtual GiftTypeEnum GiftType { get; set; }
        /// <summary>
        /// 礼包状态
        /// </summary>
        [Description("礼包状态")]
        public virtual int State { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        public virtual string Img { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}