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
    public class SendModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title{get;set;}
        /// <summary>
        /// 内容
        /// </summary>
        public string MessageContent { get; set; }
        /// <summary>
        /// 推送人
        /// </summary>
        public string PushPeople { get; set; }
        /// <summary>
        /// 接受人id
        /// </summary>
        public List<int> MemberId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;


    }
}
