/*
 * 作者：Ldw    
 * 日期：2016.06.27
 * 描述：咨讯
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Conan.Model
{
    [NotMapped]
    public class InformationViewModel : Information
    {
    }

    [NotMapped]

    public class InvitationBindview : InvitationBind
    {
      

        /// <summary>
        /// 活动名称
        /// </summary>
        //    [Description("活动名称")]
      public virtual string InvitationName { get; set; }



     

        /// <summary>
        /// 礼包名称
        /// </summary>
        //    [Description("礼包名称")]
       public virtual string GiftManageName { get; set; }


     


   

     


        /// <summary>
        /// 礼包名称 注册
        /// </summary>
        //   [Description("礼包名称  注册")]
        public virtual string ReGiftManageName { get; set; }

















    }




    [NotMapped]
    public class ShareRedBindview : ShareRedBind
    {


        /// <summary>
        /// 礼包名称
        /// </summary>
        //   [Description("礼包名称")]
        public virtual string GiftManageName { get; set; }


        /// <summary>
        /// 活动名称
        /// </summary>
        //    [Description("活动名称")]
        public virtual string ShareRedPacketsName { get; set; }


    }





}
