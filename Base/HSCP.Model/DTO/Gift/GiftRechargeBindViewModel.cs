/*
 * 作者：Ldw    
 * 日期：2016.08.04 
 * 描述：充值送礼活动记录
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 充值送礼活动记录
    /// </summary>
    [NotMapped]

    public class GiftRechargeBindViewModel : GiftRechargeBind
    {
        public string GiftManageName { get; set; }
        public string[] GiftManageIds { get; set; }
    }
}
