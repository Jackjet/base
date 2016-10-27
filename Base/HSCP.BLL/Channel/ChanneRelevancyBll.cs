/*
 * 作者：Ldw    
 * 日期：2016.06.20
 * 描述：渠道管理
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
    /// 渠道优惠卷
    /// </summary>
    public   class ChanneRelevancyBLL : BaseBll<ChanneRelevancy>
    {
        #region 构造函数
        private static ChanneRelevancyBLL instance;
        public static ChanneRelevancyBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new ChanneRelevancyBLL();
            }
            return instance;
        }
        #endregion




    }
}
