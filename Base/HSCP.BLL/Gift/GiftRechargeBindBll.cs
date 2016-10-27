/*
 * 作者：Ldw    
 * 日期：2016.08.04 
 * 描述：充值送礼活动记录
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using System.Data.SqlClient;

namespace Conan.BLL
{
    /// <summary>
    /// 充值送礼活动记录
    /// </summary>
    public class GiftRechargeBindBll : BaseBll<GiftRechargeBind>
    {
        #region 构造函数
        private static GiftRechargeBindBll instance;
        public static GiftRechargeBindBll GetInstance()
        {
            if (instance == null)
            {
                instance = new GiftRechargeBindBll();
            }
            return instance;
        }
        #endregion
    }
}
