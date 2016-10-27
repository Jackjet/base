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
    /// 角色权限
    /// </summary>
    public class RolePermissionBLL : BaseBll<RolePermission>
    {
        #region 构造函数
        private static RolePermissionBLL instance;
        public static RolePermissionBLL GetInstance()
        {
            if (instance == null)
                instance = new RolePermissionBLL();

            return instance;
        }
        #endregion

        #region 删除角色权限
        /// <summary>
        /// 删除角色权限
        /// </summary>
        /// <param name="pids"></param>
        /// <returns></returns>
        public int DeleteRolePermission(string[] code, int RoleId)
        {

            string sql = " delete  [RolePermission]  where [RoleId] = @RoleId and [PermissionCode]  not in (";
            int i = 1;
            string temp = "";
            foreach (var item in code)
            {
                temp += "   @PermissionCode" + i.ToString() + ",";
                i++;
            }
            sql += temp.Substring(0, temp.Length - 1);

            sql += "  )  ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@RoleId", RoleId);
            paramList.Add(sp);

            int j = 1;
            foreach (var item in code)
            {
                SqlParameter sp2 = new SqlParameter("@PermissionCode" + j.ToString(), item);
                paramList.Add(sp2);
                j++;
            }
            

            return ExecuteSqlCommand(sql, paramList);



        }
        public int DeleteRolePermissionAll(int RoleId)
        {

            string sql = " delete  [RolePermission]  where [RoleId] = @RoleId  ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@RoleId", RoleId);
            paramList.Add(sp);

            return ExecuteSqlCommand(sql, paramList);



        }
        #endregion

    }
}
