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
using Conan.Model;

namespace Conan.BLL
{
    /// <summary>
    /// 消息中心
    /// </summary>
    public   class MessageBll : BaseBll<Message>
    {
        #region 构造函数
        private static MessageBll instance;
        public static MessageBll GetInstance()
        {
            if (instance == null)
            {
                instance = new MessageBll();
            }
            return instance;
        }
        #endregion




    }
}
