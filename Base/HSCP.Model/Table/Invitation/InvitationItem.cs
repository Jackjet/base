/*
 * 作者：conan
 * 日期：2016.07.26  
 * 描述：邀请礼包明细
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 邀请礼包明细
    /// </summary>
    public class InvitationItem : Entity<int>
    {


        /// <summary>
        /// 分享活动id
        /// </summary>
        [Description("分享活动id")]
        public virtual int InvitationId { get; set; }




        /// <summary>
        /// 礼包id
        /// </summary>
        [Description("礼包id")]
        public virtual int GiftManageId { get; set; }



        /// <summary>
        /// 礼包名称
        /// </summary>
    //    [Description("礼包名称")]
     //   public virtual string   GiftManageName { get; set; }



        /// <summary>
        /// 礼包价值
        /// </summary>
    //    [Description("礼包价值")]
     //   public virtual decimal GiftManagePrice { get; set; }





        /// <summary>
        /// 包含优惠券
        /// </summary>
    //    [Description("包含优惠券")]
    //    public virtual string  Probability { get; set; }



        /// <summary>
        /// 类型
        /// </summary>
        [Description("类型")]
        public virtual TEnum Type { get; set; }





    }
}