/*
 * 作者：conan
 * 日期：2016.07.26  
 * 描述：分享红包明细
 * 修改记录：    
 * */
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 分享红包明细
    /// </summary>
    public class ShareItem : Entity<int>
    {


        /// <summary>
        /// 分享活动id
        /// </summary>
        [Description("分享活动id")]
        public virtual int ShareRedPacketsId { get; set; }




        /// <summary>
        /// 礼包id
        /// </summary>
        [Description("礼包id")]
        public virtual int GiftManageId { get; set; }



        /// <summary>
        /// 礼包名称
        /// </summary>
    //    [Description("礼包名称")]
      //  public virtual string   GiftManageName { get; set; }



        /// <summary>
        /// 礼包价值
        /// </summary>
    //    [Description("礼包价值")]
     //   public virtual decimal GiftManagePrice { get; set; }





        /// <summary>
        /// 礼包获得几率
        /// </summary>
        [Description("礼包获得几率")]
        public virtual decimal Probability { get; set; }


        
    }
}