/*
 * 作者：Ldw    
 * 日期：2016.06.20
 * 描述：渠道管理
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Conan.Model
{
    [NotMapped]
    public class ChannelViewModel : Channel
    {
        public ChannelViewModel()
        {
            ChanneRelevancys = new List<ChanneRelevancyViewModel>();
        }
        public List<ChanneRelevancyViewModel> ChanneRelevancys { get; set; }

    }
}
