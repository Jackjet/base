/****************************************************** 

    文件名称：
    功能描述：预库存
    作    者：coanan
    日    期：2016.06.02
    修改记录：

*******************************************************/
using HSCP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HSCP.Utils;
using System.Linq;
using System.Text;
using HSCP.DAL;

namespace HSCP.BLL
{
    /// <summary>
    /// 溢出库存
    /// </summary>
    public class OverflowBLL : BaseBll<Overflow>
    {
        #region 构造函数
        private static OverflowBLL instance;
        public static OverflowBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new OverflowBLL();
            }
            return instance;
        }
        #endregion

      

    }
}