//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工门店 职能范围
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.11
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using System.Data.SqlClient;
using System.Data;
using Conan.Core;
using Conan.DAL;

namespace Conan.BLL
{
    /// <summary>
    /// 员工门店 职能范围
    /// </summary>
    public class EmployeeStoreBLL : BaseBll<EmployeeStore>
    {
        #region 构造函数
        private static EmployeeStoreBLL instance;
        public static EmployeeStoreBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeStoreBLL();
            }
            return instance;
        }
        #endregion

        #region 删除 职能范围
        /// <summary>
        ///  删除 职能范围
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DeleteEmployeeStore(int EmployeeId,List<int> StoreIds)
        {
            string sid = "0";
            foreach(var s in  StoreIds)
            {
                sid += ","+s;
            }

            string sql = " delete [EmployeeStore]  where  [EmployeeId] = @EmployeeId  and [StoreId] not  in ("+sid+")";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@EmployeeId", EmployeeId);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);

        }
        #endregion

        #region  删除 职能范围
        /// <summary>
        ///  删除 职能范围
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DeleteEmployeeStoreAll(int EmployeeId)
        {
            string sql = " delete [EmployeeStore]  where  [EmployeeId] = @EmployeeId  ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@EmployeeId", EmployeeId);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);

        }
        #endregion


    }
}
