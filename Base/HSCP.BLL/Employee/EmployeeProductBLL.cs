
//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工产品
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

namespace Conan.BLL
{
    /// <summary>
    /// 员工产品
    /// </summary>
    public class EmployeeProductBLL : BaseBll<EmployeeProduct>
    {
        #region 构造函数
        private static EmployeeProductBLL instance;
        public static EmployeeProductBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeProductBLL();
            }
            return instance;
        }
        #endregion

        #region 获取员工擅长产品
        /// <summary>
        /// 获取员工擅长产品
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public List<EmployeeProduct> GetEmployeeProductListByEmployeeId(int EmployeeId)
        {
          return    TableNoTracking().Where(o => o.EmployeeId == EmployeeId).ToList();
         
        }
        #endregion

        #region 删除员工擅长的产品
        /// <summary>
        /// 删除员工擅长的产品
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DeleteProByEmployeeId(int EmployeeId)
        {
           
            string sql = " delete [EmployeeProduct]  where  [EmployeeId] = @EmployeeId";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@EmployeeId", EmployeeId);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);

        }
        #endregion

        
    }
}
