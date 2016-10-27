//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单材料
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
#endregion

namespace Conan.BLL
{
    /// <summary>
    /// 订单材料
    /// </summary>
    public class OrderMaterialBLL : BaseBll<OrderMaterial>
    {
        #region 构造函数
        private static OrderMaterialBLL instance;
        public static OrderMaterialBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderMaterialBLL();

            return instance;
        }
        #endregion

        #region 根据单号删除订单材料
        /// <summary>
        /// 根据单号删除订单材料
        /// </summary>
        /// <param name="BillItemNo"></param>
        /// <returns></returns>
        public int DeleteOrderMaterial(string BillItemNo)
        {
            string sql = "  delete  OrderMaterial  where   BillItemNo=@BillItemNo    ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp1 = new SqlParameter("@BillItemNo", BillItemNo);
            sp1.DbType = DbType.AnsiString;
            paramList.Add(sp1);
            return ExecuteSqlCommand(sql, paramList);
        }
        #endregion

       

    }
}
