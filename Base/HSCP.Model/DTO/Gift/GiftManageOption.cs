/*
 * 作者：Ldw    
 * 日期：2016.07.26  
 * 描述：礼品管理
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
    public class GiftManageOption
    {
        public string GiftName { get; set; }
        public GiftTypeEnum GiftType { get; set; }
    }

    public class ShareRedPacketsOption
    {
        public string GiftName { get; set; }
      
    }


    public class ShareRedBindOption
    {
        public string account { get; set; }

        public DateTime? stime { get; set; }

        public DateTime? etime { get; set; }

        public int id { get; set; }

    }




    public class InvitationBindOption
    {
        public string account { get; set; }

        public string reaccount { get; set; }

        public DateTime? stime { get; set; }

        public DateTime? etime { get; set; }

        public int id { get; set; }

    }




}
