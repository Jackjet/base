//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工  测试历史版本
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
using Conan.Utils;
using System.Threading;
using System.Text.RegularExpressions;

namespace Conan.BLL
{
    /// <summary>
    /// 员工
    /// </summary>
    public class EmployeeBLL : BaseBll<Employee>
    {
        #region 构造函数
        private static EmployeeBLL instance;
        public static EmployeeBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeBLL();
            }
            return instance;
        }
        #endregion

        #region 获取员工擅长产品
        /// <summary>
        /// 获取员工擅长产品列表
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public string GetProductNameByEmployeeId(int EmployeeId)
        {
            string result = "";
            string sql = "select Product.Name   from EmployeeProduct left join  Product on EmployeeProduct.PrdouctId= Product.Id where EmployeeProduct.EmployeeId= @EmployeeId";
            List<SqlParameter>   paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@EmployeeId", EmployeeId);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            DataTable dt =  SqlQueryForDataTatable(sql, paramList);

            for(int i=0;i<dt.Rows.Count;i++)
            {
                result += dt.Rows[i]["Name"].ToString()+",";
            }
            if(!string .IsNullOrEmpty(result))
            {
                result = result.Substring(0, result.Length - 1);
            }
            return result;

        }
        #endregion

        #region 员工对象
        public Employee GetObj(int ID)
        {
            return Get(ID);
        }
        #endregion

        #region 登录
        public OptResult Login(string Username, string Password, string ip = "")
        {
            Employee user = TableNoTracking().Where(o => o.No == Username && o.EmployeeType== EmployeeTypeEnum.支持员工 && o.State== EmployeeStateEnum.上架).FirstOrDefault();
            if (user == null)
                return new OptResult("帐号不存在");

            if (user.Password != CryptographyUtils.EncryptString(Password))
            {
                OperateLogBLL.GetInstance().LoginLog("用户登录", "密码不正确", user.Id, user.RealName, ip);
                return new OptResult("密码不正确");
            }

            OperateLogBLL.GetInstance().LoginLog("用户登录", "登录成功", user.Id, user.RealName, ip);
            return new OptResult() { Data = user, Msg = "登录成功" };
        }

        #endregion

     
    }
}