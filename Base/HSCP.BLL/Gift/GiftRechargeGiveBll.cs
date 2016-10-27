/*
 * 作者：Ldw    
 * 日期：2016.07.27 
 * 描述：充值送礼
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
    /// 充值送礼
    /// </summary>
    public class GiftRechargeGiveBll : BaseBll<GiftRechargeGive>
    {
        #region 构造函数
        private static GiftRechargeGiveBll instance;
        public static GiftRechargeGiveBll GetInstance()
        {
            if (instance == null)
            {
                instance = new GiftRechargeGiveBll();
            }
            return instance;
        }
        #endregion
    }
}
