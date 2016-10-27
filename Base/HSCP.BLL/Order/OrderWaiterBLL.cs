//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：服务人员/车辆
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
    /// 服务人员/车辆
    /// </summary>
    public class OrderWaiterBLL : BaseBll<OrderWaiter>
    {
        #region 构造函数
        private static OrderWaiterBLL instance;
        public static OrderWaiterBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderWaiterBLL();

            return instance;
        }
        #endregion

        #region 删除 派单车辆 人员
        /// <summary>
        /// 删除 派单车辆 人员
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int  DeleteOrderWaiterByBillItemNo(string  BillItemNo)
        {

          
            string sql = "  delete  OrderWaiter   where  BillItemNo=@BillItemNo ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillItemNo", BillItemNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return  ExecuteSqlCommand(sql, paramList);

         
        }

        public int DeleteOrderWaiterByBillNo(string BillNo)
        {
            OrderCacelItemBLL.GetInstance().CacelOrderbak(BillNo);


            string sql = "  delete  OrderWaiter   where  BillNo=@BillNo ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillNo", BillNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);
        }


        public int DeleteOrderWaiterhtByBillNo(string BillNo)
        {
          

            string sql = "  delete  OrderWaiter   where  BillNo=@BillNo ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillNo", BillNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);
        }


        #endregion

        #region 开始服务时间 派单车辆 人员
        /// <summary>
        /// 开始服务时间 派单车辆 人员
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int UpdateOrderWaiterByBillNo(string BillNo,DateTime StartTime)
        {

            string sql = "  update  OrderWaiter  set KStime=@StartTime,  [StartTime]=@StartTime  where IsFlag=1  and    BillNo=@BillNo   ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillNo", BillNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);

            SqlParameter sp2 = new SqlParameter("@StartTime", StartTime);
            sp2.DbType = DbType.AnsiString;
            paramList.Add(sp2);
            return ExecuteSqlCommand(sql, paramList);


        }


        /// <summary>
        /// 历史  不校验
        /// </summary>
        /// <param name="BillNo"></param>
        /// <param name="StartTime"></param>
        /// <returns></returns>
        public int UpdateOrderWaiterByBillNo2(string BillNo, DateTime StartTime)
        {
           var order =   OrderBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo).FirstOrDefault();
            if (DateTime.Now.Date >= order.StartTime.Value.AddDays(2).Date)
            {
                StartTime = order.StartTime.Value;

            }
                string sql = "  update  OrderWaiter  set KStime=@StartTime,  [StartTime]=@StartTime  where IsFlag=1  and    BillNo=@BillNo   ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillNo", BillNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);

            SqlParameter sp2 = new SqlParameter("@StartTime", StartTime);
            sp2.DbType = DbType.AnsiString;
            paramList.Add(sp2);
            return ExecuteSqlCommand(sql, paramList);


        }

        #endregion

        #region 结束服务  实际完成时间
        /// <summary>
        /// 结束服务  实际完成时间
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int UpdateRealEndTime(string BillNo, DateTime RealEndTime)
        {

            string sql = "  update  OrderWaiter  set  [RealEndTime]=@RealEndTime  where IsFlag=1  and    BillNo=@BillNo ; update  OrderWaiter  set  [EndTime]=@RealEndTime  where EndTime is null and  IsFlag=1  and    BillNo=@BillNo ;  ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@BillNo", BillNo);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);

            SqlParameter sp2 = new SqlParameter("@RealEndTime", RealEndTime);
            sp2.DbType = DbType.AnsiString;
            paramList.Add(sp2);
            return ExecuteSqlCommand(sql, paramList);


        }
        #endregion
    }
}
