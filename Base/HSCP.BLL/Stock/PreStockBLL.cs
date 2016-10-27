/****************************************************** 

    文件名称：
    功能描述：预库存
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
using System.Data;

namespace Conan.BLL
{
    /// <summary>
    /// 预库存
    /// </summary>
    public class PreStockBLL : BaseBll<PreStock>
    {
        #region 构造函数
        private static PreStockBLL instance;
        public static PreStockBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new PreStockBLL();
            }
            return instance;
        }
        #endregion

        #region 删除 预库存
        /// <summary>
        /// 删除 预库存
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public int DeleteByBillNo(string BillNo)
        {

            string sql = "   delete  [PreStock]  where  [BillNo] = @BillNo ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillNo", BillNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);


        }
        #endregion

    }
}