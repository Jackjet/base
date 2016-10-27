/*
 * 作者：Ldw    
 * 日期：2016.07.26  
 * 描述：礼品管理
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
    /// 礼品管理
    /// </summary>
    public class GiftManageBll : BaseBll<GiftManage>
    {
        #region 构造函数
        private static GiftManageBll instance;
        public static GiftManageBll GetInstance()
        {
            if (instance == null)
            {
                instance = new GiftManageBll();
            }
            return instance;
        }
        #endregion
    }
}
