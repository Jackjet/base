//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：服务人员/车辆薪酬
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using Conan.Core;
using System.Data.SqlClient;
using System.Data;
using Conan.Utils;

#endregion

namespace Conan.BLL
{
    /// <summary>
    /// 服务人员/车辆薪酬
    /// </summary>
    public class OrderWagesBLL : BaseBll<OrderWages>
    {
        #region 构造函数
        private static OrderWagesBLL instance;
        public static OrderWagesBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderWagesBLL();

            return instance;
        }
        #endregion

        #region 删除 薪酬
        /// <summary>
        /// 删除 薪酬
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public int DeleteByBillNo(string BillNo)
        {

            string sql = "  delete OrderWages where BillItemNo in (select BillItemNo  from ordersub where billno = @BillNo) ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillNo", BillNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);


        }
        #endregion

        #region  薪酬求和
     
        public decimal GetByBillNo(string sql)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            DataTable dt= SqlQueryForDataTatable(sql, paramList);

            return ZConvert.StrToDecimal(  dt.Rows[0][0].ToString());

        }
        #endregion


    }
}
