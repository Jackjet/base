/*
 * 作者：Ldw    
 * 日期：2016.06.20
 * 描述：渠道管理
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Model
{
    public class ChannelOption
    {
        /// <summary>
        /// 专享码
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public virtual string ChannelName { get; set; }
        /// <summary>
        /// 优惠卷名称
        /// </summary>
        public virtual string CouponGroupIdName { get; set; }
    }
}
