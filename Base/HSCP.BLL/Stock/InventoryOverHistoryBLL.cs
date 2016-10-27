/****************************************************** 

    文件名称：
    功能描述：库存更新历史
    作    者：coanan
    日    期：2016.06.02
    修改记录：

*******************************************************/
using Conan.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Conan.Utils;
using System.Linq;
using System.Text;
using Conan.DAL;

namespace Conan.BLL
{
    /// <summary>
    /// 库存更新历史
    /// </summary>
    public class InventoryOverHistoryBLL : BaseBll<InventoryOverHistory>
    {
        #region 构造函数
        private static InventoryOverHistoryBLL instance;
        public static InventoryOverHistoryBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new InventoryOverHistoryBLL();
            }
            return instance;
        }
        #endregion

     

    }
}