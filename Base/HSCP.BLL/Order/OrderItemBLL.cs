//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：子订单sku 明细
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
using System.Data;
#endregion

namespace Conan.BLL
{
    /// <summary>
    /// 子订单sku 明细
    /// </summary>
    public class OrderItemBLL : BaseBll<OrderItem>
    {
        #region 构造函数
        private static OrderItemBLL instance;
        public static OrderItemBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderItemBLL();

            return instance;
        }
        #endregion

        #region 根据单号删除
        /// <summary>
        /// 根据单号删除
        /// </summary>
        /// <param name="BillItemNo"></param>
        /// <returns></returns>
        public int DeleteByBillItemNo(string  BillItemNo)
        {
            
            string sql = "delete[OrderItem] where[BillItemNo] = @BillItemNo";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillItemNo", BillItemNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
          return  ExecuteSqlCommand(sql, paramList);
            

        }
        #endregion



        



    }
}
