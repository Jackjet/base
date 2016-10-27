//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工可服务时间
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
    /// 员工可服务时间
    /// </summary>
    public class EmployeeTimeBLL : BaseBll<EmployeeTime>
    {
        #region 构造函数
        private static EmployeeTimeBLL instance;
        public static EmployeeTimeBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeTimeBLL();
            }
            return instance;
        }
        #endregion

        //#region 删除员工服务时间
        ///// <summary>
        ///// 删除员工服务时间
        ///// </summary>
        ///// <param name="EmployeeId"></param>
        ///// <returns></returns>
        //public int DeleteByEmployeeId(int EmployeeId)
        //{

        //    string sql = " delete EmployeeTime  where  [EmployeeId] = @EmployeeId";
        //    List<SqlParameter> paramList = new List<SqlParameter>();
        //    SqlParameter sp = new SqlParameter("@EmployeeId", EmployeeId);
        //    sp.DbType = DbType.AnsiString;
        //    paramList.Add(sp);
        //    return ExecuteSqlCommand(sql, paramList);

        //}
        //#endregion

        //#region 修改 时间开关
        ///// <summary>
        ///// 修改 时间开关
        ///// </summary>
        ///// <param name="EmployeeId"></param>
        ///// <returns></returns>
        //public int UpdateIsEnable(int EmployeeId)
        //{

        //    string sql = "    update [EmployeeTime]  set [IsEnable] = 0  from  [EmployeeTime],EmployeeServeArea   ";
        //    sql += "     where  [EmployeeTime].CreateTime = EmployeeServeArea.CreateTime   ";
        //    sql += "       and   ";
        //    sql += "     [EmployeeTime].EmployeeId = EmployeeServeArea.EmployeeId   and    EmployeeServeArea.AreaStr = ''   ";
        //    sql += "    and  [EmployeeTime].EmployeeId = @EmployeeId   and  [EmployeeTime].IsEnable = 1   ";
        //    List<SqlParameter> paramList = new List<SqlParameter>();
        //    SqlParameter sp = new SqlParameter("@EmployeeId", EmployeeId);
        //    sp.DbType = DbType.AnsiString;
        //    paramList.Add(sp);
        //    return ExecuteSqlCommand(sql, paramList);

        //}
        //#endregion

    }
}
