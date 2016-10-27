//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：取消订单人员表
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
using Conan.DAL;
#endregion

namespace Conan.BLL
{
    /// <summary>
    /// 取消订单人员表
    /// </summary>
    public class OrderCacelItemBLL : BaseBll<OrderCacelItem>
    {
        #region 构造函数
        private static OrderCacelItemBLL instance;
        public static OrderCacelItemBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderCacelItemBLL();

            return instance;
        }
        #endregion

        #region 取消订单备份人员信息
        /// <summary>
        /// 取消订单备份人员信息
        /// </summary>
        /// <param name="BillNo"></param>
        public void CacelOrderbak(string BillNo)
        {
            string sqlstr = "    INSERT INTO   [dbo].[OrderCacelItem]   ";
            sqlstr += "     ( [WaiterType]   ";
            sqlstr += "  ,[BillItemNo]   ";
            sqlstr += "    ,[ServiceNo]   ";
            sqlstr += "    ,[CarCode]   ";
            sqlstr += "    ,[CCode]   ";
            sqlstr += "     ,[ServiceName]   ";
            sqlstr += "     ,[Tel]   ";
            sqlstr += "     ,[IsLeader]   ";
            sqlstr += "     ,[IsFlag]   ";
            sqlstr += "     ,[BillNo] )   ";
            sqlstr += "    select   ";
            sqlstr += "   [WaiterType]   ";
            sqlstr += "      ,[BillItemNo]   ";
            sqlstr += "     ,[ServiceNo]   ";
            sqlstr += "      ,[CarCode]   ";
            sqlstr += "     ,[CCode]   ";
            sqlstr += "      ,[ServiceName]   ";
            sqlstr += "     ,[Tel]   ";
            sqlstr += "     ,[IsLeader]   ";
            sqlstr += "    ,[IsFlag]   ";
            sqlstr += "     ,[BillNo]   ";
            sqlstr += "    from   OrderWaiter  where   [BillNo]='"+ BillNo + "'   ";
            List<SqlParameter> paramListt2 = new List<SqlParameter>();
            ExecuteSqlCommand(sqlstr, paramListt2);
        }
        #endregion

    }
}
