/*
 * 作者：Ldw    
 * 日期：2016.08.04 
 * 描述：充值送礼活动记录
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class GiftRechargeBindOption
    {
        public DateTime? StartCreateTime { get; set; }
        public DateTime? EndCreateTime { get; set; }
        public string Account { get; set; }
        public string phone { get; set; }
        public GiveGifTypeEnum GiveType { get; set; }
        public int GiftRechargeId { get; set; }
        public int GiftName { get; set; }
    }
}
