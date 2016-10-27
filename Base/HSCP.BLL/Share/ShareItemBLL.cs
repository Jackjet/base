using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using Conan.Core;
using System.Data.SqlClient;

namespace Conan.BLL
{
    /// <summary>
    /// 分享红包明细
    /// </summary>
    public class ShareItemBLL : BaseBll<ShareItem>
    {
        #region 构造函数
        private static ShareItemBLL instance;
        public static ShareItemBLL GetInstance()
        {
            if (instance == null)
                instance = new ShareItemBLL();

            return instance;
        }
        #endregion



        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ShareRedPacketsId"></param>
        /// <returns></returns>
        public int DeleteShareItem(int ShareRedPacketsId)
        {
            string sql = "delete   [ShareItem]   where   [ShareRedPacketsId] = @ShareRedPacketsId";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@ShareRedPacketsId", ShareRedPacketsId);
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);


        }
        #endregion





    }
}
