/*
 * 作者：Ldw    
 * 日期：2016.06.18  
 * 描述：消息中心
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Model
{
    public class MessageOption
    {
        /// <summary>
        /// 开始创建时间
        /// </summary>
        public virtual DateTime? StartCreateTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        public virtual DateTime? EndCreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageEnum? State { get; set; }
    }
}
