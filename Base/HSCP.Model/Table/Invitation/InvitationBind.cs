/*
 * 作者：conan
 * 日期：2016.07.26  
 * 描述：领取邀请明细
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 领取邀请明细
    /// </summary>
    public class InvitationBind : Entity<int>
    {
        /// <summary>
        /// 分享活动id
        /// </summary>
        [Description("分享活动id")]
        public virtual int InvitationId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
    //    [Description("活动名称")]
      //  public virtual string InvitationName { get; set; }



        #region 邀请

        /// <summary>
        /// 分享活动明细id
        /// </summary>
        [Description("分享活动明细id")]
        public virtual int InvitationItemId { get; set; }




        /// <summary>
        /// 礼包id
        /// </summary>
        [Description("礼包id")]
        public virtual int GiftManageId { get; set; }



        /// <summary>
        /// 礼包名称
        /// </summary>
    //    [Description("礼包名称")]
     //   public virtual string GiftManageName { get; set; }


        #endregion



        #region 注册

        /// <summary>
        /// 分享活动明细id  注册
        /// </summary>
        [Description("分享活动明细id 注册")]
        public virtual int ReInvitationItemId { get; set; }




        /// <summary>
        /// 礼包id 注册
        /// </summary>
        [Description("礼包id 注册")]
        public virtual int ReGiftManageId { get; set; }



        /// <summary>
        /// 礼包名称 注册
        /// </summary>
     //   [Description("礼包名称  注册")]
      //  public virtual string ReGiftManageName { get; set; }



        #endregion











        /// <summary>
        /// 绑定时间
        /// </summary>
        [Description("绑定时间")]
        public virtual DateTime BindTime { get; set; }



        /// <summary>
        /// 会员Id
        /// </summary>

        [Description("会员Id")]
        public virtual int MemberId { get; set; }



        /// <summary>
        /// 会员号
        /// </summary>
        [Description("会员号")]
        public virtual string Account { get; set; }







        /// <summary>
        /// 注册会员Id
        /// </summary>

        [Description("注册会员Id")]
        public virtual int ReMemberId { get; set; }



        /// <summary>
        /// 注册会员号
        /// </summary>
        [Description("注册会员号")]
        public virtual string ReAccount { get; set; }




    }
}