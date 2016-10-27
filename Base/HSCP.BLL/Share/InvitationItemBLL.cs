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
    /// 邀请礼包明细
    /// </summary>
    public class InvitationItemBLL : BaseBll<InvitationItem>
    {
        #region 构造函数
        private static InvitationItemBLL instance;
        public static InvitationItemBLL GetInstance()
        {
            if (instance == null)
                instance = new InvitationItemBLL();

            return instance;
        }
        #endregion





        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="InvitationItem"></param>
        /// <returns></returns>
        public int DeleteInvitationItem(int InvitationId)
        {
            string sql = "delete   [InvitationItem]   where   InvitationId = @InvitationId";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@InvitationId", InvitationId);
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);


        }
        #endregion





    }
}
