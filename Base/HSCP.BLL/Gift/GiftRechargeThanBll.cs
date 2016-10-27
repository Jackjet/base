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
    public class GiftRechargeThanBll : BaseBll<GiftRechargeThan>
    {
        #region 构造函数
        private static GiftRechargeThanBll instance;
        public static GiftRechargeThanBll GetInstance()
        {
            if (instance == null)
            {
                instance = new GiftRechargeThanBll();
            }
            return instance;
        }
        #endregion
    }
}
