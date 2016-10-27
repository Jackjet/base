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
    /// 角色产品
    /// </summary>
    public class RoleProductBLL : BaseBll<RoleProduct>
    {
        #region 构造函数
        private static RoleProductBLL instance;
        public static RoleProductBLL GetInstance()
        {
            if (instance == null)
                instance = new RoleProductBLL();

            return instance;
        }
        #endregion

        #region 删除角色产品
        /// <summary>
        /// 删除角色产品
        /// </summary>
        /// <param name="pids"></param>
        /// <returns></returns>
        public int  DeleteRoleProduct(int[] ProductId,int RoleId)
        {

            string sql = " delete  [RoleProduct]  where [RoleId] = @RoleId and [ProductId]  not in (";
            int i = 1;
            string temp = "";
            foreach (var item in ProductId)
            {
                temp += "   @ProductId"+i.ToString()+",";
                i++;
            }
            sql+= temp.Substring(0, temp.Length-1);

               sql += "  )  ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@RoleId", RoleId);
            paramList.Add(sp);

            int j = 1;
            foreach (var item in ProductId)
            {
                SqlParameter sp2 = new SqlParameter("@ProductId"+j.ToString(), item);
                paramList.Add(sp2);
                j++;
            }




           




           return    ExecuteSqlCommand(sql, paramList);

        

        }
        public int DeleteRoleProductAll( int RoleId)
        {

            string sql = " delete  [RoleProduct]  where [RoleId] = @RoleId  ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@RoleId", RoleId);
            paramList.Add(sp);
           
            return ExecuteSqlCommand(sql, paramList);



        }
        #endregion


    }
}
