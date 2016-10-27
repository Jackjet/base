/*
 * 作者：Ldw    
 * 日期：2016.06.18  
 * 描述：消息中心
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Conan.Model
{
    [NotMapped]
    public class MessageViewModel : Message
    {
    }
}
