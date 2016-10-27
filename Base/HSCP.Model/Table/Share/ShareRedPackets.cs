/*
 * 作者：conan
 * 日期：2016.07.26  
 * 描述：分享红包
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 分享红包
    /// </summary>
    public class ShareRedPackets : OtherEntity<int>
    {
        /// <summary>
        /// 活动名称
        /// </summary>
        [Description("活动名称")]
        public virtual string Name { get; set; }

        /// <summary>
        /// 开始有效期
        /// </summary>
        [Description("开始有效期")]
        public virtual DateTime StartValidity { get; set; }
        /// <summary>
        /// 结束有效期
        /// </summary>
        [Description("结束有效期")]
        public virtual DateTime EndValidity { get; set; }

        /// <summary>
        /// 状态  未启用 = 1, 启用
        /// </summary>
        [Description("状态")]
        public virtual RedEnum State { get; set; }



        /// <summary>
        /// 分享图标
        /// </summary>
        [Description("分享图标")]
        public virtual string ShareImg { get; set; }




        /// <summary>
        /// 分享标题
        /// </summary>
        [Description("分享标题")]
        public virtual string ShareTitle { get; set; }




        /// <summary>
        /// 背景图标
        /// </summary>
        [Description("背景图标")]
        public virtual string BgImg { get; set; }



        /// <summary>
        /// 活动规则
        /// </summary>
        [Description("活动规则")]
        public virtual string rules { get; set; }



        /// <summary>
        /// 礼包发放数量
        /// </summary>
        [Description("礼包发放数量")]
        public virtual int Num { get; set; }
    }
}