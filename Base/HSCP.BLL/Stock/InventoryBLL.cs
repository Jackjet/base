/****************************************************** 

    文件名称：
    功能描述：库存
    作    者：coanan
    日    期：2016.06.02
    修改记录：

*******************************************************/
using Conan.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Conan.Utils;
using System.Linq;
using System.Text;
using Conan.DAL;
using System.Data;
using Conan.Core;
using PetaPoco;
using System.Threading;

namespace Conan.BLL
{
    /// <summary>
    /// 库存
    /// </summary>
    public class InventoryBLL : BaseBll<Inventory>
    {
        #region 构造函数
        private static InventoryBLL instance;
        public static InventoryBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new InventoryBLL();
            }
            return instance;
        }
        #endregion

        #region 选择员工列表 （开单）
            /// <summary>
            /// 选择员工列表 （开单）
            /// </summary>
            /// <param name="StoreId">门店id</param>
            /// <param name="PrdouctId">产品id</param>
            /// <param name="StartTime">开始时间</param>
            /// <param name="EndTime">结束时间</param>
            /// <param name="AreaId">区域id</param>
            /// <returns></returns>
        public DataTable GeteListSelectkd(int StoreId, int PrdouctId, DateTime StartTime, DateTime EndTime, int AreaId)
        {
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            if (StartTime.Date != EndTime.Date)
            {
                ts2 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
            }
            List<Times> list = InventoryBLL.GetInstance().GetTimes(ts1, ts2);
            List<int> listidok = list.Select(o => o.Id).ToList();
            bool flag = false;
            if (StartTime.Date == EndTime.AddHours(interval).AddSeconds(-1).Date)
            {
                flag = true;
            }
            string str1 = "";
            string str2 = "";
            int z = 0;
            foreach (var a in listidok)
            {
                str1 += "   and   time" + a + "  in (1,2)  ";
                str2 += "  and   time" + a + "=0   ";
                z = a;
            }
            if (flag == true)
            {
                int n = ZConvert.StrToInt((interval / 0.5));
                for (int j = 0; j < n; j++)
                {
                    z++;
                    str1 += "   and  ( time" + z + "  in (1,2) or     time" + z + "  is  null  )";
                    str2 += "  and   time" + z + "=0   ";
                }
            }
            #endregion
            #region 查询
            List<SqlParameter> paramList = new List<SqlParameter>();
            DateTime dts = StartTime;
            DateTime dte = EndTime.AddHours(ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan")));
            string sql = "select   [EmployeeId]   from ";
            sql += "  [StockOutInView]  WITH (NOLock)  where areaid = " + AreaId + " and  [StoreId] = " + StoreId + " and PrdouctId = " + PrdouctId + " and   [CreTime] = '" + StartTime.Date + "' ";
            sql += str1;
            sql += " and ";
            sql += " [EmployeeId] not in  ";


            string sqlInventory = " ";
            sqlInventory += "   ";
            sqlInventory += " select  [EmployeeId]  from ";
            sqlInventory += "  [Inventory]   WITH (NOLock)  where ";
            sqlInventory += " [CreTime] = '" + StartTime.Date + "' ";
            sqlInventory += str2;
            sqlInventory += "     ";
            DataTable dtInventory = SqlQueryForDataTatable(sqlInventory, paramList);
            List<int> tempeids = new List<int>();
            if (dtInventory != null && dtInventory.Rows.Count > 0)
            {
                for (int j = 0; j < dtInventory.Rows.Count; j++)
                {
                    tempeids.Add(ZConvert.StrToInt(dtInventory.Rows[j][0].ToString()));
                }
            }
           


            string  sqlOrderWaiter = "   ";
            sqlOrderWaiter += "     SELECT  ";
            sqlOrderWaiter += "    Employee.Id  ";
            sqlOrderWaiter += "  FROM  [dbo].[OrderWaiter]  ";
            sqlOrderWaiter += "      left join Employee on ";
            sqlOrderWaiter += "  [OrderWaiter].ServiceNo=Employee.No ";
            sqlOrderWaiter += " where   IsFlag = 1  and KStime is  not null  and KEtime is not null ";
            sqlOrderWaiter += " and    '" + dts + "'<KEtime and  KStime<'" + dte + "' ";
            sqlOrderWaiter += "    and  Employee.Id   is  not  null     ";
            DataTable dtOrderWaiter = SqlQueryForDataTatable(sqlOrderWaiter, paramList);
            if (dtOrderWaiter != null && dtOrderWaiter.Rows.Count > 0)
            {
                for (int j = 0; j < dtOrderWaiter.Rows.Count; j++)
                {
                    tempeids.Add(ZConvert.StrToInt(dtOrderWaiter.Rows[j][0].ToString()));
                }
            }
            tempeids.Add(0);







            sql += " (    "+string.Join(",", tempeids);
            //sql += " select  [EmployeeId]  from ";
            //sql += "  [Inventory]   WITH (NOLock)  where ";
            //sql += " [CreTime] = '" + StartTime.Date + "' ";
            //sql += str2;
            sql += "   ) ";
            //sql += " and ";
            //sql += " [EmployeeId] not in  ";
            //sql += " ( ";
            //sql += "     SELECT  ";
            //sql += "    Employee.Id  ";
            //sql += "  FROM  [dbo].[OrderWaiter]  ";
            //sql += "      left join Employee on ";
            //sql += "  [OrderWaiter].ServiceNo=Employee.No ";
            //sql += " where   IsFlag = 1  and KStime is  not null  and KEtime is not null ";
            //sql += " and    '" + dts + "'<KEtime and  KStime<'" + dte + "' ";
            //sql += "    and  Employee.Id   is  not  null   ) ";
           
            DataTable dt = SqlQueryForDataTatable(sql, paramList);
            List<int> eids = new List<int>();
            if(dt!=null  &&  dt.Rows.Count>0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    eids.Add(ZConvert.StrToInt(dt.Rows[j][0].ToString()));
                }
            }
            eids.Add(0);
            string sql2 = "  SELECT [EmployeeId], COUNT([PrdouctId]) as pcount   FROM  [EmployeeProduct] ";
            sql2 += "   where [EmployeeId] in ("+ string.Join(",",eids) + ")  ";
            sql2 += "  group by  [EmployeeId]  order by  COUNT([PrdouctId]) asc  ";
            List<SqlParameter> paramList2 = new List<SqlParameter>();
            DataTable dt2 = SqlQueryForDataTatable(sql2, paramList2);
            #endregion
            return dt2;
        }

        //日期？？？？
        public DataTable GeteListSelectkdids(int StoreId, int PrdouctId, int AreaId)
        {
            string sql = "   SELECT [Employee].[Id]   FROM  [dbo].[Employee]  left join   EmployeeServeAreadetail  on [Employee].Id = EmployeeServeAreadetail.EmployeeId  ";
                   sql += "     left join   EmployeeProduct on  [Employee].Id = EmployeeProduct.EmployeeId  ";
                   sql += "    where EmployeeServeAreadetail.AreaId = " + AreaId + "  and EmployeeProduct.PrdouctId = "+ PrdouctId + "  and [Employee].StoreId = "+ StoreId + "  and [Employee].State =1 and  Employee.EmployeeType=10 ";
            List<SqlParameter> paramList = new List<SqlParameter>();  
            DataTable dt = SqlQueryForDataTatable(sql, paramList);
            return dt;
        }
        #endregion

        #region 产生库存 服务
        /// <summary>
        /// 产生库存 服务
        /// </summary>

        public void MadeStock()
        {
            #region 清除历史库存
             
            string sqltdel = "  delete    from dbo.Inventory where  CreTime<'"+ DateTime.Now.AddDays(-10).Date + "' ;  delete    from dbo.InventoryHistory where  CreTime<'"+ DateTime.Now.AddDays(-10).Date + "' ;   delete    from dbo.InventoryOver where  CreTime<'"+ DateTime.Now.AddDays(-10).Date + "'  ;    delete    from dbo.InventoryOverHistory where  CreTime<'"+ DateTime.Now.AddDays(-10).Date + "' ;   ";

            ExecuteSqlCommand(sqltdel, null);



            #endregion



            int Stockdate = ZConvert.StrToInt(ZConfig.GetConfigString("Stockdate"));

            //using (DistributedTransaction tran = new DistributedTransaction())
            //{
            // 上架的 服务员工
            var Employeelist = EmployeeBLL.GetInstance().TableNoTracking().Where(o => o.State == EmployeeStateEnum.上架 && o.EmployeeType == EmployeeTypeEnum.服务员工).ToList();
            if (Employeelist != null && Employeelist.Count > 0)
            {
                DateTime Time = DateTime.Now;
                for (int z = 0; z < Stockdate; z++)
                {
                    int t = z == 0 ? 0 : 1;
                    Time = Time.AddDays(t);

                    var InventoryHistory = InventoryHistoryBLL.GetInstance().TableNoTracking().Where(o => o.CreTime == Time.Date).FirstOrDefault();
                    if (InventoryHistory == null)
                    {
                        #region 处理
                        foreach (var item in Employeelist)
                        {
                            using (DistributedTransaction tran = new DistributedTransaction())
                            {
                                #region 删除

                                string sqldel = "delete  [Inventory] where [EmployeeId]=" + item.Id + " and  [CreTime]='" + Time.Date + "'";
                                ExecuteSqlCommand(sqldel, null);

                                #endregion
                                var EmployeeTime = EmployeeTimeDetailBLL.GetInstance().TableNoTracking().Where(o => o.EmployeeId == item.Id && o.Day == Time.Date).FirstOrDefault();
                                if (EmployeeTime != null)
                                {
                                    #region 禁用操作
                                    if (EmployeeTime.IsEnable == false)
                                    {
                                        //添加不可用
                                        string sql = "INSERT INTO [dbo].[Inventory] ([StoreId] ,[EmployeeId] ,[CreTime] ,[IsDriver] ) VALUES(" + item.StoreId + "," + item.Id + ",'" + Time.Date + "'," + (item.IsDriver ? 1 : 0) + ")";
                                        ExecuteSqlCommand(sql, null);

                                    }
                                    #endregion
                                    #region 启用 操作
                                    else
                                    {
                                        TimeSpan ts1 = EmployeeTime.StartTime;
                                        TimeSpan ts2 = EmployeeTime.EndTime;
                                        List<Times> list = InventoryBLL.GetInstance().GetTimes(ts1, ts2);
                                        List<int> listidok = list.Select(o => o.Id).ToList();

                                        string str1 = "";
                                        string str2 = "";

                                        int j = 1;
                                        foreach (var a in listidok)
                                        {
                                            str1 += ",time" + a;
                                            str2 += ",1";
                                            j++;
                                        }
                                        string sql = "INSERT INTO [dbo].[Inventory] ([StoreId] ,[EmployeeId] ,[CreTime] ,[IsDriver]" + str1;

                                        sql += "    ) VALUES(" + item.StoreId + "," + item.Id + ",'" + Time.Date + "'," + (item.IsDriver ? 1 : 0) + "" + str2 + ")";


                                        ExecuteSqlCommand(sql, null);

                                    }
                                    #endregion
                                }
                                tran.Complete();
                            }

                        }
                        //添加记录
                        InventoryHistory obj = new InventoryHistory();
                        obj.CreTime = Time.Date;
                        InventoryHistoryBLL.GetInstance().Add(obj);
                        #endregion
                    }
                }
            }
            //    tran.Complete();
            //}
        }

        #endregion

        #region 分配库存 （后台开单）
        /// <summary>
        /// 分配库存
        /// </summary>
        /// <param name="StoreId">门店id</param>
        /// <param name="PrdouctId">产品id</param>
        /// <param name="StartTime">开始时间 </param>
        /// <param name="EndTime">结束时间 计算好的时间</param>
        /// <param name="AreaId">区域id</param>
        ///  <param name="PNum">人数</param>
        ///   <param name="BillNo">订单编号</param>
        ///   <param name="interval">时间间隔</param>
        /// <returns>false 库存不足  true  ok </returns>
        public bool GeteList(int StoreId, int PrdouctId, DateTime StartTime, DateTime EndTime, int AreaId, int PNum, string BillNo)
        {
            if(PNum<1)
            {
                return true;
            }

            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段

            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            if (StartTime.Date != EndTime.Date)
            {
                ts2 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
            }
            List<Times> list = InventoryBLL.GetInstance().GetTimes(ts1, ts2);
            List<int> listidok = list.Select(o => o.Id).ToList();
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));

            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }


            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();
            string str1 = "";
            string str2 = "";
            int nt = ZConvert.StrToInt((interval / 0.5));
            int di = 1;
            foreach (var a in listidokt)
            {
                if (di <= listidokt.Count - nt)
                {
                    str1 += "   and   time" + a + "=1  ";
                }
                else
                {
                    str1 += "   and  ( time" + a + "=1   or   time" + a + " is  null  )";
                }




                str2 += "    and   time" + a + "  in (0,2)   ";



                di++;
            }







            string str3 = "";
            foreach (var a in listidokt)
            {
                str3 += "     time" + a + "=0,";
            }
         
            #endregion
            #region 查询
            StringBuilder sql = new StringBuilder();
            sql.Append(" select   [EmployeeId]    from "); 
            
            sql.Append("  [StockOutInView]   WITH (NOLock)  where areaid = @AreaId and  [StoreId] = @StoreId and PrdouctId = @PrdouctId and   [CreTime] = @CreTime ");
            sql.Append(str1);
            sql.Append(" and ");
            sql.Append(" [EmployeeId] not in  ");
            sql.Append(" ( ");
            sql.Append(" select  [EmployeeId]  from ");
            sql.Append(" [Inventory]  WITH (NOLock)  where ");
            sql.Append(" [CreTime] = @CreTime ");
            sql.Append(str2);
            sql.Append(" ) ");
          
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@StoreId", StoreId);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            SqlParameter sp2 = new SqlParameter("@PrdouctId", PrdouctId);
            sp2.DbType = DbType.AnsiString;
            paramList.Add(sp2);
            SqlParameter sp3 = new SqlParameter("@CreTime", StartTime.Date);
            sp3.DbType = DbType.AnsiString;
            paramList.Add(sp3);
            SqlParameter sp4 = new SqlParameter("@AreaId", AreaId);
            sp4.DbType = DbType.AnsiString;
            paramList.Add(sp4);
            DataTable dts = SqlQueryForDataTatable(sql.ToString(), paramList);
            
            string nostr = "  ";
            if (dts != null)
            {
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    int EmployeeId = ZConvert.StrToInt(dts.Rows[i]["EmployeeId"].ToString());
                    nostr += "   " + EmployeeId + ",  ";
                }
            }
            nostr += " 0  ";
            StringBuilder sb = new StringBuilder();
            sb.Append("   select  top "+ PNum + "     [EmployeeId]  ,COUNT([PrdouctId]) as pcount  from  [EmployeeProduct]  ");
            sb.Append("    where  [EmployeeId]  in (" + nostr + "   )  ");
            sb.Append("      group by [EmployeeId]  order by  COUNT([PrdouctId]) asc ");
            List<SqlParameter> paramLists = new List<SqlParameter>();
            DataTable dt = EmployeeProductBLL.GetInstance().SqlQueryForDataTatable(sb.ToString(), paramLists);
         
            #endregion
        
            #region 库存不足
            if (dt != null)
            {
                if (dt.Rows.Count < PNum)
                {
                    #region MyRegion
                    #region 查找溢出库存的
                    int ti = PNum - dt.Rows.Count;
                    string sqlt = "   SELECT   *   FROM  [dbo].[InventoryOver]   WITH (NOLock) ";
                    sqlt += "     where  [StoreId] = @StoreId   and  ";
                    sqlt += "     [ProductId] = @ProductId  ";
                    sqlt += "     and   [CreTime] = @CreTime  ";


                    foreach (var a in listidok)
                    {
                        sqlt += "    and  [Times" + a + "] + " + ti + " <=[Time" + a + "]  ";

                    }

                    List<SqlParameter> paramListt = new List<SqlParameter>();
                    SqlParameter spt = new SqlParameter("@StoreId", StoreId);
                    spt.DbType = DbType.AnsiString;
                    paramListt.Add(spt);
                    SqlParameter spt2 = new SqlParameter("@ProductId", PrdouctId);
                    spt2.DbType = DbType.AnsiString;
                    paramListt.Add(spt2);
                    SqlParameter spt3 = new SqlParameter("@CreTime", StartTime.Date);
                    spt3.DbType = DbType.AnsiString;
                    paramListt.Add(spt3);



                    DataTable dtt = SqlQueryForDataTatable(sqlt, paramListt);
                    #endregion
                    if (dtt != null && dtt.Rows.Count > 0)
                    {
                        #region 更新 溢出库存的
                        #region MyRegion
                        string sqlt2 = "  update  [InventoryOver]   set     ";
                        string tt = "";
                        foreach (var a in listidokt)
                        {
                            tt += "      [Times" + a + "]=  case when  [Times" + a + "] + " + ti + " > [Time" + a + "]      then  [Time" + a + "]    else       [Times" + a + "]+" + ti + "        end,";
                        }
                        if (!string.IsNullOrEmpty(tt))
                        {
                            tt = tt.Substring(0, tt.Length - 1);
                        }

                        sqlt2 += tt;


                        sqlt2 += "  where  [StoreId]=@StoreId  and    ";
                        sqlt2 += "   [ProductId] =@ProductId  ";
                        sqlt2 += "    and   [CreTime]=@CreTime   ";
                        #endregion


                        List<SqlParameter> paramListt2 = new List<SqlParameter>();
                        SqlParameter spt21 = new SqlParameter("@StoreId", StoreId);
                        spt21.DbType = DbType.AnsiString;
                        paramListt2.Add(spt21);
                        SqlParameter spt22 = new SqlParameter("@ProductId", PrdouctId);
                        spt22.DbType = DbType.AnsiString;
                        paramListt2.Add(spt22);
                        SqlParameter spt32 = new SqlParameter("@CreTime", StartTime.Date);
                        spt32.DbType = DbType.AnsiString;
                        paramListt2.Add(spt32);
                        if (!string.IsNullOrEmpty(tt))
                        {
                            ExecuteSqlCommand(sqlt2, paramListt2);
                        }
                        #endregion
                    }
                    else
                    {
                        //库存不足
                        return false;
                    }
                    #endregion
                }
                else
                {

                }
            }
            else
            {

                #region MyRegion
                #region 查找溢出库存的
                int ti = PNum;
                string sqlt = "   SELECT   *   FROM  [dbo].[InventoryOver]   WITH (NOLock) ";
                sqlt += "     where  [StoreId] = @StoreId   and  ";
                sqlt += "     [ProductId] = @ProductId  ";
                sqlt += "     and   [CreTime] = @CreTime  ";


                foreach (var a in listidok)
                {
                    sqlt += "    and  [Times" + a + "] + " + ti + " <=[Time" + a + "]  ";

                }

                List<SqlParameter> paramListt = new List<SqlParameter>();
                SqlParameter spt = new SqlParameter("@StoreId", StoreId);
                spt.DbType = DbType.AnsiString;
                paramListt.Add(spt);
                SqlParameter spt2 = new SqlParameter("@ProductId", PrdouctId);
                spt2.DbType = DbType.AnsiString;
                paramListt.Add(spt2);
                SqlParameter spt3 = new SqlParameter("@CreTime", StartTime.Date);
                spt3.DbType = DbType.AnsiString;
                paramListt.Add(spt3);



                DataTable dtt = SqlQueryForDataTatable(sqlt, paramListt);
                #endregion
                if (dtt != null && dtt.Rows.Count > 0)
                {

                    #region 更新 溢出库存的
                    #region MyRegion
                    string sqlt2 = "  update  [InventoryOver]   set     ";

                    string tt = "";
                    foreach (var a in listidokt)
                    {
     
                        tt += "      [Times" + a + "]=  case when  [Times" + a + "] + " + ti + " > [Time" + a + "]      then  [Time" + a + "]    else       [Times" + a + "]+" + ti + "        end,";

                    }
                    if (!string.IsNullOrEmpty(tt))
                    {
                        tt = tt.Substring(0, tt.Length - 1);
                    }

                    sqlt2 += tt;


                    sqlt2 += "  where  [StoreId]=@StoreId  and    ";
                    sqlt2 += "   [ProductId] =@PrdouctId  ";
                    sqlt2 += "    and   [CreTime]=@CreTime   ";
                    #endregion


                    List<SqlParameter> paramListt2 = new List<SqlParameter>();
                    SqlParameter spt21 = new SqlParameter("@StoreId", StoreId);
                    spt21.DbType = DbType.AnsiString;
                    paramListt2.Add(spt21);
                    SqlParameter spt22 = new SqlParameter("@PrdouctId", PrdouctId);
                    spt22.DbType = DbType.AnsiString;
                    paramListt2.Add(spt22);
                    SqlParameter spt32 = new SqlParameter("@CreTime", StartTime.Date);
                    spt32.DbType = DbType.AnsiString;
                    paramListt2.Add(spt32);
                    if (!string.IsNullOrEmpty(tt))
                    {
                        ExecuteSqlCommand(sqlt2, paramListt2);
                    }
                    #endregion



                }
                else
                {
                    //库存不足
                    return false;
                }
                #endregion

            }
            #endregion
         
            #region 预派库存操作 
            if (dt != null && dt.Rows.Count > 0)
            {
                bool temp = true;
                int flag = 0;
                if (dt.Rows.Count >= PNum)
                {
                    flag = PNum;
                }
                else
                      if (dt.Rows.Count < PNum)
                {
                    flag = dt.Rows.Count;
                }


                for (int i = 0; i < flag; i++)
                {
                    PreStock PreStock = new PreStock();
                    PreStock.WaiterType = WaiterTypes.服务员工;
                    PreStock.BillNo = BillNo;
                    int EmployeeId = ZConvert.StrToInt(dt.Rows[i]["EmployeeId"].ToString());
                    string no = EmployeeBLL.GetInstance().Table().Where(o => o.Id == EmployeeId).Select(o => o.No).FirstOrDefault();
                    PreStock.ServiceNo = no;
                    PreStock.StartTime = StartTime;
                    PreStock.EndTime = EndTime;
                    PreStockBLL.GetInstance().Add(PreStock);
                    #region  修改对应的库存
                    if (!string.IsNullOrEmpty(str3))
                    {
                        str3 = str3.Substring(0, str3.Length - 1);
                    }

                    int t = 0;
                    #region MyRegion

                    int n = ZConvert.StrToInt((interval / 0.5));
                    int m = 1;
                 string sqlbase = "   delete dbo.Inventory where Id=-1 ;    ";
                  string sqlext = " delete dbo.Inventory where Id=-1 ;   ";
                    foreach (var itemid in listidokt)
                    {
                        #region base
                        if (m <= listidokt.Count - n)
                        {

                            ////string sqlupdate = " update  [Inventory]   set  time" + itemid + "=2";
                            ////sqlupdate += "  where   [EmployeeId]=@EmployeeId    and  [CreTime]=@CreTime   and  [StoreId]=@StoreId  and time" + itemid + "=1";
                            ////List<SqlParameter> paramListupdate = new List<SqlParameter>();
                            ////SqlParameter spu = new SqlParameter("@StoreId", StoreId);
                            ////spu.DbType = DbType.AnsiString;
                            ////paramListupdate.Add(spu);
                            ////SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                            ////spu2.DbType = DbType.AnsiString;
                            ////paramListupdate.Add(spu2);
                            ////SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                            ////spu3.DbType = DbType.AnsiString;
                            ////paramListupdate.Add(spu3);
                            ////t += ExecuteSqlCommand(sqlupdate, paramListupdate);



                            sqlbase += "   update  [Inventory]   set  time" + itemid + "=2";
                            sqlbase += "  where   [EmployeeId]=" + EmployeeId + "    and  [CreTime]='" + StartTime.Date + "'   and  [StoreId]=" + StoreId + "  and time" + itemid + "=1;  ";

                            if (m == listidokt.Count - n)
                            {
                                List<SqlParameter> paramListupdate = new List<SqlParameter>();
                                t += ExecuteSqlCommand(sqlbase, paramListupdate);
                            }
                        }
                        #endregion
                        #region ext
                        else
                        {
                            string sqlupdate = " select *   from Inventory    WITH (NOLock) ";
                            sqlupdate += "  where   [EmployeeId]=@EmployeeId    and  [CreTime]=@CreTime   and  [StoreId]=@StoreId  and ( time" + itemid + "   is  null       )";
                            List<SqlParameter> paramListupdate = new List<SqlParameter>();
                            SqlParameter spu = new SqlParameter("@StoreId", StoreId);
                            spu.DbType = DbType.AnsiString;
                            paramListupdate.Add(spu);
                            SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                            spu2.DbType = DbType.AnsiString;
                            paramListupdate.Add(spu2);
                            SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                            spu3.DbType = DbType.AnsiString;
                            paramListupdate.Add(spu3);
                            DataTable objdts = SqlQueryForDataTatable(sqlupdate, paramListupdate);

                            if (objdts != null && objdts.Rows.Count > 0)
                            {
                                t += 1;

                            }
                            else
                            {
                                ////string sqlupdate2 = " update  [Inventory]   set  time" + itemid + "=2";
                                ////sqlupdate2 += "  where   [EmployeeId]=@EmployeeId    and  [CreTime]=@CreTime   and  [StoreId]=@StoreId  and ( time" + itemid + "=1     )";
                                ////List<SqlParameter> paramListupdate2 = new List<SqlParameter>();
                                ////SqlParameter spu21 = new SqlParameter("@StoreId", StoreId);
                                ////spu21.DbType = DbType.AnsiString;
                                ////paramListupdate2.Add(spu21);
                                ////SqlParameter spu22 = new SqlParameter("@EmployeeId", EmployeeId);
                                ////spu22.DbType = DbType.AnsiString;
                                ////paramListupdate2.Add(spu22);
                                ////SqlParameter spu32 = new SqlParameter("@CreTime", StartTime.Date);
                                ////spu32.DbType = DbType.AnsiString;
                                ////paramListupdate2.Add(spu32);
                                ////t += ExecuteSqlCommand(sqlupdate2, paramListupdate2);

                                sqlext += "   update  [Inventory]   set  time" + itemid + "=2";
                                sqlext += "   where   [EmployeeId]=" + EmployeeId + "    and  [CreTime]='" + StartTime.Date + "'   and  [StoreId]=" + StoreId + "  and ( time" + itemid + "=1     ) ;   ";


                            }
                            if (m == listidokt.Count)
                            {
                                List<SqlParameter> paramListupdate2 = new List<SqlParameter>();
                                t += ExecuteSqlCommand(sqlext, paramListupdate2);
                            }



                        }
                        #endregion
                        m++;

                    }
                    #endregion
                  
                    if (listidokt.Count != t)
                 
                    {
                        temp = false;
                        break;
                    }




                    #endregion
                }

                if (!temp)
                {
                    //更新 有问题  并发  库存不住
                    return false;
                }


            }
            #endregion
         
            return true;
        }
        #endregion

        #region 释放库存  预派到可用 2-1
        /// <summary>
        /// 释放库存 预派到可用  2-1
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="interval">时间间隔</param>
        public bool ReStovk(int EmployeeId, DateTime StartTime, DateTime EndTime)
        {
            if (string.IsNullOrEmpty(StartTime.ToString()) || string.IsNullOrEmpty(EndTime.ToString()))
            {
                return true;
            }
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));

            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }


            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();

            #endregion

            #region sql
            string sqlupdate = "";
            int t = 0;
            foreach (var a in listidokt)
            {

                 sqlupdate += "  update  [Inventory]   set       time" + a + "=1";
                 sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and      time" + a + "=2;  ";

                //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                //spu2.DbType = DbType.AnsiString;
                //paramListupdate.Add(spu2);
                //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                //spu3.DbType = DbType.AnsiString;
                //paramListupdate.Add(spu3);
                //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }

            if(!string.IsNullOrEmpty(sqlupdate))
            {
                List<SqlParameter> paramListupdate = new List<SqlParameter>();

                t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }
            





            if (listidokt.Count != t)
            {
                //更新 有问题  并发  库存不住
                return false;
            }
            else
            {
                return true;
            }

            #endregion

        }
        #endregion

        #region 释放库存  占用到可用   0-1
        /// <summary>
        /// 释放库存  占用到可用   0-1
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="interval">时间间隔</param>
        public bool ReStovkZyToKy(int EmployeeId, DateTime StartTime, DateTime EndTime)
        {
            if (string.IsNullOrEmpty(StartTime.ToString()) || string.IsNullOrEmpty(EndTime.ToString()))
            {
                return true;
            }

            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));
            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }

            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();

            #endregion

            #region sql
            int t = 0;
            string sqlupdate = "";
            foreach (var a in listidokt)
            {

                 sqlupdate += "  update  [Inventory]   set       time" + a + "=1";
                sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and      time" + a + "=0  ;   ";
                //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                //spu2.DbType = DbType.AnsiString;
                //paramListupdate.Add(spu2);
                //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                //spu3.DbType = DbType.AnsiString;
                //paramListupdate.Add(spu3);
                //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }

            if(!string .IsNullOrEmpty(sqlupdate))
            {
                List<SqlParameter> paramListupdate = new List<SqlParameter>();

                t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }
          


            if (listidokt.Count != t)
            {
                //更新 有问题  并发  库存不住
                return false;
            }
            else
            {
                return true;
            }

            #endregion

        }
        #endregion

        #region 释放库存  占用到可用   0-1 删除补单
        /// <summary>
        /// 释放库存  占用到可用   0-1 删除补单
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="interval">时间间隔</param>
        public bool ReStovkZyToKyforDelete(int EmployeeId, DateTime StartTime, DateTime EndTime)
        {

            if (string.IsNullOrEmpty(StartTime.ToString()) || string.IsNullOrEmpty(EndTime.ToString()))
            {
                return true;
            }
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            bool flag = false;
            if (StartTime.Date != EndTime.Date)
            {
                DateTime dts = StartTime;
                DateTime dte = StartTime.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                flag = ReStovkZyToKyforDeleteItem(EmployeeId, dts, dte, 0);
                flag = ReStovkZyToKyforDeleteItem(EmployeeId, EndTime.Date, EndTime, interval);
            }
            else
            {
                flag = ReStovkZyToKyforDeleteItem(EmployeeId, StartTime, EndTime, interval);
            }
            return flag;

        }
        bool ReStovkZyToKyforDeleteItem(int EmployeeId, DateTime StartTime, DateTime EndTime, Double interval)
        {

            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));

            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }


            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();

            #endregion

            #region sql
            int t = 0;
            string sqlupdate = "";
            foreach (var a in listidokt)
            {

                 sqlupdate += "   update  [Inventory]   set       time" + a + "=1";
                sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and      time" + a + "    is not null ;   ";
                //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                //spu2.DbType = DbType.AnsiString;
                //paramListupdate.Add(spu2);
                //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                //spu3.DbType = DbType.AnsiString;
                //paramListupdate.Add(spu3);
                //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }
            if(!string.IsNullOrEmpty(sqlupdate))
            {
                List<SqlParameter> paramListupdate = new List<SqlParameter>();

                t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }
           




            if (listidokt.Count != t)
            {
                //更新 有问题  并发  库存不住
                return false;
            }
            else
            {
                return true;
            }

            #endregion
        }
        #endregion

        #region 占用库存 可用倒雨派
        /// <summary>
        /// 占用库存
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="interval">时间间隔</param>
        public bool OcupyStovk(int EmployeeId, DateTime StartTime, DateTime EndTime)
        {
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));
            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }
            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();
            #endregion

            #region sql
            int t = 0;
            int n = ZConvert.StrToInt((interval / 0.5));
            int m = 1;
            string sqlupdate = "";
            foreach (var a in listidokt)
            {
                if (m <= listidokt.Count - n)
                {
                     sqlupdate += " update  [Inventory]   set       time" + a + "=2";
                     sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and      time" + a + "=1 ;  ";
                    ////List<SqlParameter> paramListupdate = new List<SqlParameter>();
                    ////SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                    ////spu2.DbType = DbType.AnsiString;
                    ////paramListupdate.Add(spu2);
                    ////SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                    ////spu3.DbType = DbType.AnsiString;
                    ////paramListupdate.Add(spu3);
                    ////t += ExecuteSqlCommand(sqlupdate, paramListupdate);
                }
                else


                {
                     sqlupdate += "   update  [Inventory]   set       time" + a + "=2";
                     sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and   (     time" + a + "=1   or    or  time" + a + "     is null   ) ;   ";
                    ////List<SqlParameter> paramListupdate = new List<SqlParameter>();
                    ////SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                    ////spu2.DbType = DbType.AnsiString;
                    ////paramListupdate.Add(spu2);
                    ////SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                    ////spu3.DbType = DbType.AnsiString;
                    ////paramListupdate.Add(spu3);
                    ////t += ExecuteSqlCommand(sqlupdate, paramListupdate);
                }


                m++;

            }

            if(!string.IsNullOrEmpty(sqlupdate))
            {
                List<SqlParameter> paramListupdate = new List<SqlParameter>();
                t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }

            if (listidokt.Count != t)
            {
                //更新 有问题  并发  库存不住
                return false;
            }
            else
            {
                return true;
            }

            #endregion

        }
        #endregion

        #region 占用库存 可用到占用 1-0
        /// <summary>
        /// 占用库存 可用到占用  1-0
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="interval">时间间隔</param>
        public bool OcupyStovkKyToZy(int EmployeeId, DateTime StartTime, DateTime EndTime)
        {
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));
            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }
            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();
            #endregion

            #region sql
            int t = 0;
            int n = ZConvert.StrToInt((interval / 0.5));
            int m = 1;
            string sqlupdate = "";
            foreach (var a in listidokt)
            {

                if (m <= listidokt.Count - n)
                {
                     sqlupdate += "   update  [Inventory]   set       time" + a + "=0";
                    sqlupdate += "    where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and      time" + a + "=1  ;  ";
                    //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                    //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                    //spu2.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu2);
                    //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                    //spu3.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu3);
                    //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
                }
                else


                {
                     sqlupdate += "   update  [Inventory]   set       time" + a + "=0";
                    sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and   (   time" + a + "=1   or  time" + a + "     is null       )  ;   ";
                    //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                    //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                    //spu2.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu2);
                    //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                    //spu3.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu3);
                    //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
                }

                m++;


            }

            if(!string.IsNullOrEmpty(sqlupdate))
            {
                List<SqlParameter> paramListupdate = new List<SqlParameter>();
              
                t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }

            if (listidokt.Count != t)
            {
                //更新 有问题  并发  库存不住
                return false;
            }
            else
            {
                return true;
            }

            #endregion

        }
        #endregion

        #region 选择员工列表 （派单）
        /// <summary>
        /// 选择员工列表 （派单）
        /// </summary>
        /// <param name="StoreId">门店id</param>
        /// <param name="PrdouctId">产品id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>

        /// <param name="AreaId">区域id</param>
        /// <returns></returns>
        public DataTable GeteListSelect(int StoreId, int PrdouctId, DateTime StartTime, DateTime EndTime, int AreaId, string BillItemNo = "")
        {
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            if (StartTime.Date != EndTime.Date)
            {
                ts2 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
            }
            List<Times> list = InventoryBLL.GetInstance().GetTimes(ts1, ts2);
            List<int> listidok = list.Select(o => o.Id).ToList();

  
            bool flag = false;
            if (StartTime.Date == EndTime.AddHours(interval).AddSeconds(-1).Date)
            {
                flag = true;

            }
            

            string str1 = "";
            string str2 = "";

            int z = 0;
            foreach (var a in listidok)
            {
                str1 += "   and   time" + a + "  in (1,2)  ";
                str2 += "  and   time" + a + "=0   ";

                z = a;
            }

            if(flag==true)
            {

                int n = ZConvert.StrToInt((interval / 0.5));

                for(int j=0;j<n;j++)
                {
                    z++;
                    str1 += "   and  ( time" + z + "  in (1,2) or     time" + z + "  is  null  )";
                    str2 += "  and   time" + z + "=0   ";

                   
                }


            }

            //string str3 = "";
            //foreach (var a in listidokt)
            //{

            //    str3 += "     time" + a + "=0,";

            //}

            #endregion
       
            #region 查询
            DateTime dts = StartTime;
            DateTime dte = EndTime.AddHours(ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan")));



            string sqlnoid = "     SELECT  ";
            sqlnoid += "    Employee.Id  ";
            sqlnoid += "  FROM  [dbo].[OrderWaiter]  ";
            sqlnoid += "      left join Employee on ";
            sqlnoid += "  [OrderWaiter].ServiceNo=Employee.No ";
            sqlnoid += " where  BillItemNo!='" + BillItemNo + "' and IsFlag = 1  and KStime is  not null  and KEtime is not null ";
            sqlnoid += " and    '" + dts + "'<KEtime and  KStime<'" + dte + "' ";
            sqlnoid += "    and  Employee.Id   is  not  null      ";
            List<SqlParameter> paramListnoid = new List<SqlParameter>();
            DataTable dtnoid = SqlQueryForDataTatable(sqlnoid, paramListnoid);
            List<int> enoids = new List<int>();
            if (dtnoid != null && dtnoid.Rows.Count > 0)
            {
                for (int j = 0; j < dtnoid.Rows.Count; j++)
                {
                    enoids.Add(ZConvert.StrToInt(dtnoid.Rows[j][0].ToString()));
                }
            }
            enoids.Add(0);


            string sqlInventory = "  ";
            sqlInventory += " select  [EmployeeId]  from ";
            sqlInventory += "   [Inventory]   WITH (NOLock)  where ";
            sqlInventory += " [CreTime] = '" + StartTime.Date + "' ";
            sqlInventory += str2;
            sqlInventory += "    ";
            DataTable dtnoidInventory = SqlQueryForDataTatable(sqlInventory, paramListnoid);
          
            if (dtnoidInventory != null && dtnoidInventory.Rows.Count > 0)
            {
                for (int j = 0; j < dtnoidInventory.Rows.Count; j++)
                {
                    enoids.Add(ZConvert.StrToInt(dtnoidInventory.Rows[j][0].ToString()));
                }
            }







            string sql = "select   [EmployeeId]    from ";
            sql += "  [StockOutInView]  WITH (NOLock)  where areaid = " + AreaId + " and  [StoreId] = " + StoreId + " and PrdouctId = " + PrdouctId + " and   [CreTime] = '" + StartTime.Date + "' ";
            sql += str1;
            sql += " and ";
            //sql += " [EmployeeId] not in  ";
            //sql += " ( ";
            //sql += " select  [EmployeeId]  from ";
            //sql += "   [Inventory]   WITH (NOLock)  where ";
            //sql += " [CreTime] = '" + StartTime.Date + "' ";
            //sql += str2;
            //sql += " ) ";
            //sql += " and ";
            sql += "   [EmployeeId] not in  ";
            sql += " ( ";
      
            sql += "    " + string.Join(",", enoids) + "  )   ";
         
            List<SqlParameter> paramList = new List<SqlParameter>();
           
            DataTable dt = SqlQueryForDataTatable(sql, paramList);

         
            List<int> eids = new List<int>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    eids.Add(ZConvert.StrToInt(dt.Rows[j][0].ToString()));
                }
            }
            eids.Add(0);

            #endregion
         
            string sql2 = "  SELECT [EmployeeId], COUNT([PrdouctId]) as pcount   FROM  [EmployeeProduct] ";
            sql2 += "   where[EmployeeId] in (" + string.Join(",", eids) + ")  ";
            sql2 += "  group by[EmployeeId]  order by  COUNT([PrdouctId]) asc  ";
            List<SqlParameter> paramList2 = new List<SqlParameter>();
            DataTable dt2 = SqlQueryForDataTatable(sql2, paramList2);
         
            return dt2;
        }
        #endregion

        #region 占用库存 可用到占用 0,1,2 -0
        /// <summary>
        /// 占用库存 可用到占用 0,1,2 -0
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="interval">时间间隔</param>
        public bool OcupyStovkToZy(int EmployeeId, DateTime StartTime, DateTime EndTime)
        {
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));
            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }

            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();
            #endregion

            #region sql
            int t = 0;
            string sqlupdate = "";
            foreach (var a in listidokt)
            {

                 sqlupdate += "   update  [Inventory]   set       time" + a + "=0";
                sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'   ;  ";
                //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                //spu2.DbType = DbType.AnsiString;
                //paramListupdate.Add(spu2);
                //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                //spu3.DbType = DbType.AnsiString;
                //paramListupdate.Add(spu3);
                //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }

            if(!string.IsNullOrEmpty(sqlupdate))
            {
                List<SqlParameter> paramListupdate = new List<SqlParameter>();

                t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }
        


            if (listidokt.Count != t)
            {
                //更新 有问题  并发  库存不住
                return false;
            }
            else
            {
                return true;
            }

            #endregion

        }
        #endregion

        #region 占用库存 可用到占用 1,2 -0
        /// <summary>
        /// 占用库存 可用到占用 1,2 -0
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="interval">时间间隔</param>
        public bool OcupyStovkTwoToZy(int EmployeeId, DateTime StartTime, DateTime EndTime)
        {
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));

            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));
            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }

            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();
            #endregion

            #region sql
            int t = 0;
            int n = ZConvert.StrToInt((interval / 0.5));
            string sqlupdate = "";

            int m = 1;
            foreach (var a in listidokt)
            {
                if (m <= listidokt.Count - n)


                {
                     sqlupdate += " update  [Inventory]   set       time" + a + "=0";
                    sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and    time" + a + "    in (1,2)  ;   ";
                    //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                    //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                    //spu2.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu2);
                    //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                    //spu3.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu3);
                    //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
                }

                else


                {
                     sqlupdate += "   update  [Inventory]   set       time" + a + "=0";
                    sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and (   time" + a + "     in (1,2)   or  time" + a + "    is null )   ;  ";
                    //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                    //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                    //spu2.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu2);
                    //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                    //spu3.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu3);
                    //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
                }


                m++;
            }


            if(!string.IsNullOrEmpty(sqlupdate))
            {
                List<SqlParameter> paramListupdate = new List<SqlParameter>();
              
                t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }

            if (listidokt.Count != t)
            {
                //更新 有问题  并发  库存不住
                return false;
            }
            else
            {
                return true;
            }

            #endregion

        }
        #endregion

        #region 占用库存 可用到占用 1,2 -0  隔天的 补单专用
        /// <summary>
        /// 占用库存 可用到占用 1,2 -0 隔天的 补单专用
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="interval">时间间隔</param>
        public bool OcupyStovkTwoToZyTwo(int EmployeeId, DateTime StartTime, DateTime EndTime)
        {
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            bool flag = false;
            if (StartTime.Date != EndTime.Date)
            {
                DateTime dts = StartTime;
                DateTime dte = StartTime.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                flag = OcupyStovkTwoToZyforDay(EmployeeId, dts, dte, 0);
                flag = OcupyStovkTwoToZyforDay(EmployeeId, EndTime.Date, EndTime, interval);
            }
            else
            {
                flag = OcupyStovkTwoToZyforDay(EmployeeId, StartTime, EndTime, interval);
            }
            return flag;
        }
        bool OcupyStovkTwoToZyforDay(int EmployeeId, DateTime StartTime, DateTime EndTime, Double interval)
        {

            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));
            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }


            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();
            #endregion

            #region sql
            int t = 0;
            int n = ZConvert.StrToInt((interval / 0.5));
            string sqlupdate = "";

            int m = 1;
            foreach (var a in listidokt)
            {
                if (m <= listidokt.Count - n)


                {
                     sqlupdate += "    update  [Inventory]   set       time" + a + "=0";
                    sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and    time" + a + "    is not null   ;   ";
                    //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                    //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                    //spu2.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu2);
                    //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                    //spu3.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu3);
                    //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
                }

                else


                {
                     sqlupdate += "    update  [Inventory]   set       time" + a + "=0";
                    sqlupdate += "  where   [EmployeeId]="+ EmployeeId + "    and  [CreTime]='"+ StartTime.Date + "'  and (   time" + a + "    is not null    )    ;   ";
                    //List<SqlParameter> paramListupdate = new List<SqlParameter>();
                    //SqlParameter spu2 = new SqlParameter("@EmployeeId", EmployeeId);
                    //spu2.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu2);
                    //SqlParameter spu3 = new SqlParameter("@CreTime", StartTime.Date);
                    //spu3.DbType = DbType.AnsiString;
                    //paramListupdate.Add(spu3);
                    //t += ExecuteSqlCommand(sqlupdate, paramListupdate);
                }


                m++;
            }

            if(!string.IsNullOrEmpty(sqlupdate))
            {
                List<SqlParameter> paramListupdate = new List<SqlParameter>();
            
                t += ExecuteSqlCommand(sqlupdate, paramListupdate);
            }


            if (listidokt.Count != t)
            {
                //更新 有问题  并发  库存不住
                return false;
            }
            else
            {
                return true;
            }

            #endregion
        }
        #endregion

        #region   修改库存  入库  上下架  离职 重新入库
        /// <summary>
        /// 入库  上下架  离职 重新入库
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        public void StovkInByStatus(int EmployeeId)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(StovkInByStatuspro), EmployeeId);

            

        }


        void StovkInByStatuspro(object eid)
        {
            int EmployeeId = (int)eid;

            NLogger.Fatal("员工修改上下架、时间管理 id:" + EmployeeId);

            Employee(EmployeeId);


            var Employeelist = EmployeeBLL.GetInstance().TableNoTracking().Where(o => o.Id == EmployeeId && o.State == EmployeeStateEnum.上架 && o.EmployeeType == EmployeeTypeEnum.服务员工).FirstOrDefault();
            DateTime dt = DateTime.Now.Date;
            var InventoryHistory = InventoryHistoryBLL.GetInstance().TableNoTracking().Where(o => o.CreTime >= dt).ToList();
            if (InventoryHistory != null && InventoryHistory.Count > 0)
            {
                foreach (var item in InventoryHistory)
                {
                    #region 删除

                    string sqlselect = "select *  from  [Inventory] where [EmployeeId]=" + EmployeeId + " and  [CreTime]='" + item.CreTime + "'";
                    DataTable dtselect = SqlQueryForDataTatable(sqlselect, new List<SqlParameter>());



                    string sqldel = "delete  [Inventory] where [EmployeeId]=" + EmployeeId + " and  [CreTime]='" + item.CreTime + "'";
                    ExecuteSqlCommand(sqldel, null);

                    #endregion

                    if (Employeelist != null)
                    {
                        var EmployeeTime = EmployeeTimeDetailBLL.GetInstance().TableNoTracking().Where(o => o.EmployeeId == EmployeeId && o.Day == item.CreTime.Date).FirstOrDefault();
                        if (EmployeeTime != null)
                        {
                            #region 禁用操作
                            if (EmployeeTime.IsEnable == false)
                            {
                                //添加不可用
                                string sql = "INSERT INTO [dbo].[Inventory] ([StoreId] ,[EmployeeId] ,[CreTime] ,[IsDriver] ) VALUES(" + Employeelist.StoreId + "," + Employeelist.Id + ",'" + item.CreTime.Date + "'," + (Employeelist.IsDriver ? 1 : 0) + ")";
                                ExecuteSqlCommand(sql, null);

                            }
                            #endregion
                            #region 启用 操作
                            else
                            {
                                #region 添加
                                TimeSpan ts1 = EmployeeTime.StartTime;
                                TimeSpan ts2 = EmployeeTime.EndTime;
                                List<Times> list = InventoryBLL.GetInstance().GetTimes(ts1, ts2);
                                List<int> listidok = list.Select(o => o.Id).ToList();

                                string str1 = "";
                                string str2 = "";

                                int j = 1;
                                foreach (var a in listidok)
                                {
                                    str1 += ",time" + a;
                                    str2 += ",1";
                                    j++;
                                }
                                string sql = "INSERT INTO [dbo].[Inventory] ([StoreId] ,[EmployeeId] ,[CreTime] ,[IsDriver]" + str1;

                                sql += "    ) VALUES(" + Employeelist.StoreId + "," + Employeelist.Id + ",'" + item.CreTime.Date + "'," + (Employeelist.IsDriver ? 1 : 0) + "" + str2 + ")";


                                ExecuteSqlCommand(sql, null);
                                #endregion

                                #region 更新
                                if (dtselect != null && dtselect.Rows.Count > 0)
                                {
                                    string sqlupdate = "";

                                    for (int z = 1; z < 49; z++)
                                    {

                                        if (!string.IsNullOrWhiteSpace(dtselect.Rows[0]["Time" + z + ""].ToString()))
                                        {
                                            sqlupdate += "  update  [Inventory]   set       time" + z + "=" + dtselect.Rows[0]["Time" + z + ""].ToString();
                                            sqlupdate += "  where   [EmployeeId]=" + Employeelist.Id + "    and  [CreTime]='" + item.CreTime.Date + "'  and      time" + z + " is not   null;  ";

                                        }


                                    }

                                    if (!string.IsNullOrWhiteSpace(sqlupdate))
                                    {
                                        ExecuteSqlCommand(sqlupdate, null);
                                    }

                                }


                                #endregion

                            }
                            #endregion
                        }
                    }

                }
            }


        }


        void Employee(int EmployeeId)
        {
          
            try
            {
                DateTime today = DateTime.Today;
                DateTime maxDay = DateTime.Today.AddDays(ZConfig.GetConfigInt("Stockdate"));

                Database db = new Database("Xiaoyujia");

                List<int> ids = new List<int>(); ids.Add(EmployeeId);// db.Fetch<int>("select Id from [Employee] where [State]=1");

                //删除旧数据
                db.Execute(@"delete from EmployeeTimeDetail where day<@0
                             delete from EmployeeServeAreaDetail where day<@0", today);

                foreach (int id in ids)
                {
                    //读取模板
                    var dataTmp = db.QueryMultiple(@"select * from EmployeeTime where EmployeeId=@0
                                                 select * from EmployeeServeArea where EmployeeId=@0", id);

                    List<EmployeeTime> employeeTimes = dataTmp.Read<EmployeeTime>().ToList();
                    List<EmployeeServeArea> employeeServeAreas = dataTmp.Read<EmployeeServeArea>().ToList();
                    if (employeeTimes.Count != 7)
                    {
                        continue;
                    }

                    //Console.WriteLine($"{id}:{employeeTimes.Count};{employeeServeAreas.Count}");

                    DateTime dt = DateTime.Today.AddDays(-1);
                    DateTime? etday = db.FirstOrDefault<EmployeeTimeDetail>(@"select top 1 * from EmployeeTimeDetail where EmployeeId=@0 order by day desc", id)?.Day;
                    if (etday.HasValue && etday.Value > today)
                    {
                        dt = etday.Value.Date;
                    }

                    Sql sql = Sql.Builder;
                    for (int i = 1; i <= ZConfig.GetConfigInt("Stockdate") + 1; i++)
                    {
                        dt = dt.AddDays(1);
                        if (dt > maxDay.Date)
                        {
                            //Console.WriteLine($"{i}={dt};{maxDay};{dt == maxDay.Date}；{dt >= maxDay.Date}");
                            break;
                        }

                        // Console.WriteLine($"{i}======{dt}");

                        var et = employeeTimes.FirstOrDefault(o => o.Week == dt.DayOfWeek);
                        sql.Append($"INSERT INTO [EmployeeTimeDetail] ([EmployeeId],[StartTime] ,[EndTime] ,[Day],[IsEnable],[CreateTime]) VALUES({id} ,'{et.StartTime}' ,'{et.EndTime}' ,'{dt}',{(et.IsEnable ? 1 : 0)},GETDATE())");

                        var esa = employeeServeAreas.Where(o => o.Week == dt.DayOfWeek).Select(o => new { o.AreaId, o.AreaName }).ToList();

                        db.Execute(@"delete from EmployeeServeAreaDetail where EmployeeId=@0 and  Day=@1
                            ", id,dt);


                        foreach (var es in esa)
                        {
                            sql.Append($"INSERT INTO [EmployeeServeAreaDetail] ([EmployeeId],[AreaId] ,[AreaName] ,[Day]) VALUES({id} ,'{es.AreaId}' ,'{es.AreaName}' ,'{dt}')");
                        }
                    }
                    if (sql.SQL.Length > 0)
                        db.Execute(sql);
                }
            }
            catch (Exception exc)
            {
                //   Console.WriteLine(exc.Message);
                NLogger.Fatal(exc.ToString());
            }

        }

        #endregion

        #region 分配库存  前端
        /// <summary>
        /// 分配库存  前端
        /// </summary>
        /// <param name="PrdouctId">产品id</param>
        /// <param name="StartTime">开始时间 </param>
        /// <param name="EndTime">结束时间  计算好的时间</param>
        /// <param name="AreaId">区域id</param>
        ///  <param name="PNum">人数</param>
        ///   <param name="BillNo">订单编号</param>
        /// <returns> 门店id  0  没有可匹配的门店 库存不足    大于0 匹配的门店id 有库存   </returns>
        public int GeteListWeb(int PrdouctId, DateTime StartTime, DateTime EndTime, int AreaId, int PNum, string BillNo)
        {
            Double interval = ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan"));
            #region 组织字段
            TimeSpan ts1 = TimeSpan.Parse(StartTime.ToString("HH:mm"));
            TimeSpan ts2 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
            if (StartTime.Date != EndTime.Date)
            {
                ts2 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
            }
            List<Times> list = InventoryBLL.GetInstance().GetTimes(ts1, ts2);
            List<int> listidok = list.Select(o => o.Id).ToList();
            TimeSpan ts3 = TimeSpan.Parse(EndTime.AddHours(interval).ToString("HH:mm"));
            if (StartTime.Date != EndTime.AddSeconds(-1).AddHours(interval).Date)
            {
                if (StartTime.Date != EndTime.Date)
                {
                    ts3 = TimeSpan.Parse(EndTime.AddSeconds(-1).ToString("HH:mm"));
                }
                else
                {
                    ts3 = TimeSpan.Parse(EndTime.ToString("HH:mm"));
                }
            }
            List<Times> listt = InventoryBLL.GetInstance().GetTimes(ts1, ts3);
            List<int> listidokt = listt.Select(o => o.Id).ToList();
            string str1 = "";
          
            foreach (var a in listidok)
            {
                str1 += "   and   time" + a + "    is not null      ";
             
            }
         
            #endregion

            #region  --前端匹配店铺 符合条件的人员 去除被暂用的 得到 店铺，人员数量
            StringBuilder sql = new StringBuilder();
            sql.Append("  select   [StoreId] , COUNT( DISTINCT   [EmployeeId])  as pcount  from ");
            sql.Append("   [StockOutInView]   WITH (NOLock)  where areaid = @AreaId  and PrdouctId = @PrdouctId     and  [CreTime] =@CreTime  ");
            sql.Append(str1);
        
            sql.Append("    group by   [StoreId]   having COUNT(  DISTINCT  [EmployeeId]) >0       order by  COUNT( DISTINCT  [EmployeeId])   asc");
  
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp2 = new SqlParameter("@PrdouctId", PrdouctId);
            sp2.DbType = DbType.AnsiString;
            paramList.Add(sp2);
            SqlParameter sp3 = new SqlParameter("@CreTime", StartTime.Date);
            sp3.DbType = DbType.AnsiString;
            paramList.Add(sp3);
            SqlParameter sp4 = new SqlParameter("@AreaId", AreaId);
            sp4.DbType = DbType.AnsiString;
            paramList.Add(sp4);
            DataTable dt = SqlQueryForDataTatable(sql.ToString(), paramList);
            if (dt == null)
            {
                //库存不足
                return 0;
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    //库存不足
                    return 0;
                }
                else
                {
                    int flag = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        int StoreId = ZConvert.StrToInt(dt.Rows[j]["StoreId"]);
                        bool iskc = GeteList(StoreId, PrdouctId, StartTime, EndTime, AreaId, PNum, BillNo);
                        if (iskc)
                        {
                            flag = StoreId;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    return flag;
                }
            }
            #endregion

        }

        /// <summary>
        /// 获取门店id   不校验库存
        /// </summary>
        /// <param name="PrdouctId">产品id</param>
        /// <param name="StartTime">开始时间 </param>
        /// <param name="EndTime">结束时间  计算好的时间</param>
        /// <param name="AreaId">区域id</param>
        ///      <param name="PNum">人数</param>
        /// <returns>门店id  0  没有可匹配的门店   大于0 匹配的门店id</returns>
        public int GetStoreIdWeb(int PrdouctId, DateTime StartTime, DateTime EndTime, int AreaId, int PNum)
        {
            string sql = "    SELECT  top  1   [Employee].[Id]    ";
            sql += "    ,[Employee].[No]  ";
            sql += "    ,[Employee].[StoreId]  ";
            sql += "    ,EmployeeProduct.PrdouctId  ";
            sql += "   ,EmployeeServeAreadetail.AreaId  ";
            sql += "    ,EmployeeServeAreadetail.day  ";
            sql += "   FROM   [dbo].[Employee]   ";
            sql += "      left join  dbo.EmployeeProduct    on   [Employee].Id=EmployeeProduct.EmployeeId    ";
            sql += "     left   join   dbo.EmployeeServeAreadetail   on   [Employee].Id= EmployeeServeAreadetail.EmployeeId    ";
            sql += "     where   [Employee].[EmployeeType]= " + (int)EmployeeTypeEnum.服务员工 + "    and    [Employee].State= " + (int)EmployeeStateEnum.上架 + "  ";
            sql += "     and   EmployeeServeAreadetail.day= '" + StartTime.Date + "'    and    EmployeeProduct.PrdouctId= " + PrdouctId + "    ";
            sql += "     and EmployeeServeAreadetail.AreaId= " + AreaId + "      ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            DataTable dt = SqlQueryForDataTatable(sql.ToString(), paramList);
            if (dt == null)
            {
                //库存不足
                return 0;
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    //库存不足
                    return 0;
                }
                else
                {
                    return ZConvert.StrToInt(dt.Rows[0]["StoreId"]);
                }
            }
            

        }

        /// <summary>
        /// 后台开单  不校验库存  验证 
        /// </summary>
        /// <param name="PrdouctId"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="AreaId"></param>
        /// <param name="PNum"></param>
        /// <returns></returns>
        public int GetStorekd(int StoreId, int PrdouctId, DateTime StartTime, int AreaId)
        {
            string sql = "    SELECT   top  1  [Employee].[Id]    ";
            sql += "    ,[Employee].[No]  ";
            sql += "    ,[Employee].[StoreId]  ";
            sql += "    ,EmployeeProduct.PrdouctId  ";
            sql += "   ,EmployeeServeAreadetail.AreaId  ";
            sql += "    ,EmployeeServeAreadetail.day  ";
            sql += "   FROM   [dbo].[Employee]   ";
            sql += "      left join  dbo.EmployeeProduct    on   [Employee].Id=EmployeeProduct.EmployeeId    ";
            sql += "     left   join   dbo.EmployeeServeAreadetail   on   [Employee].Id= EmployeeServeAreadetail.EmployeeId    ";
            sql += "     where   [Employee].[EmployeeType]= " + (int)EmployeeTypeEnum.服务员工 + "    and    [Employee].State= " + (int)EmployeeStateEnum.上架 + "  ";
            sql += "     and   EmployeeServeAreadetail.day= '" + StartTime.Date + "'    and    EmployeeProduct.PrdouctId= " + PrdouctId + "    ";
            sql += "     and EmployeeServeAreadetail.AreaId= " + AreaId + "   and  [Employee].[StoreId] =" + StoreId;
            List<SqlParameter> paramList = new List<SqlParameter>();
            DataTable dt = SqlQueryForDataTatable(sql.ToString(), paramList);
            if (dt == null)
            {
                //库存不足
                return 0;
            }
            else
            {
                if (dt.Rows.Count == 0)
                {
                    //库存不足
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }




        #endregion

        #region 获取总库存
        /// <summary>
        /// 获取总库存
        /// </summary>
        /// <param name="StoreId">门店id</param>
        /// <param name="ProductCategoryId">分类id</param>
        /// <param name="CreateTime">日期</param>
        /// <param name="AreaId">区域id 默认可空 所有的区域</param>
        /// <returns></returns>
        public List<StockOutInView> GetStockTotal(int StoreId, int ProductCategoryId, DateTime CreateTime, int AreaId = 0)
        {
            //List<StockOutInView> list = new List<StockOutInView>();
            var sql = ReadOnlyRepository.SqlBuilder();

            ReadOnlyRepository readOnly = new ReadOnlyRepository();
            List<int> pids = readOnly.Fetch<int>("select id from  Product where ProductCategoryId = @0", ProductCategoryId);

            sql.Append("select *  from [StockOutInView]   WITH (NOLock)  where  [StoreId] = @0 ", StoreId);

            if (pids.Count > 0)
                sql.Append(" and  PrdouctId in (@0)", pids);
            if (AreaId != 0)
                sql.Append(" and  [AreaId]=@0", AreaId);

            sql.Append(" and  [CreTime]=@0", CreateTime.Date);
            return readOnly.Fetch<StockOutInView>(sql);


            //List<StockOutInView> list = new List<StockOutInView>();
            //StringBuilder sql = new StringBuilder();
            //sql.Append(" select  *   ");
            //sql.Append("     from [StockOutInView]  where  [StoreId] = @StoreId   and   PrdouctId   in  ");
            //sql.Append("   (select  id from  Product where ProductCategoryId = @ProductCategoryId)  and  [CreTime] = @CreTime  ");

            //if (AreaId != 0)
            //{
            //    sql.Append("    and  [AreaId]= " + AreaId + "  ");
            //}


            //List<SqlParameter> paramList = new List<SqlParameter>();
            //SqlParameter sp = new SqlParameter("@StoreId", StoreId);
            //sp.DbType = DbType.AnsiString;
            //paramList.Add(sp);
            //SqlParameter sp2 = new SqlParameter("@ProductCategoryId", ProductCategoryId);
            //sp2.DbType = DbType.AnsiString;
            //paramList.Add(sp2);
            //SqlParameter sp3 = new SqlParameter("@CreTime", CreateTime.Date);
            //sp3.DbType = DbType.AnsiString;
            //paramList.Add(sp3);

            //DataTable dt = SqlQueryForDataTatable(sql.ToString(), paramList);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    list = ZConvert.ToList<StockOutInView>(dt).ToList();
            //}
            //return list;
        }
        #endregion

        #region 获取时间段列表
        /// <summary>
        /// 获取时间段列表
        /// </summary>
        /// <param name="ts1">开始时间段</param>
        /// <param name="ts2">结束时间段</param>
        /// <returns></returns>
        public List<Times> GetTimes(TimeSpan ts1, TimeSpan ts2)
        {
            DateTime dt1 = DateTime.Parse(ts1.ToString());
            DateTime dt2 = DateTime.Parse(ts2.ToString());
            List<Times> listtimes = new List<Times>();
            for (int i = 0; i < 48; i++)
            {
                Times times = new Times();
                times.Id = i + 1;
                times.ts1 = DateTime.Parse("00:00:01").AddHours(i * ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan")));//.AddSeconds(i == 0 ? 0 : 1)
                times.ts2 = DateTime.Parse("00:30:00").AddHours(i * ZConvert.StrToDouble(ZConfig.GetConfigString("StockSpan")));
                listtimes.Add(times);
            }

            //  listtimes = listtimes.Where(o => dt1 < o.ts2 && o.ts1 < dt2).ToList();
            listtimes = listtimes.Where(o => dt1 < o.ts2 && o.ts1 < dt2).ToList();

            return listtimes;
        }

        #endregion

        #region   修改时间管理  校验是否派单
        /// <summary>
        /// 修改时间管理  校验是否派单
        /// </summary>
        /// <param name="EmployeeId">员工id</param>
        public string Mancheck(int EmployeeId)
        {

            string t= Mancheckyes(EmployeeId);
           

            var code = EmployeeBLL.GetInstance().TableNoTracking().Where(o => o.Id == EmployeeId).Select(o => o.No).FirstOrDefault();
            var EmployeeTimelist = EmployeeTimeDetailBLL.GetInstance().TableNoTracking().Where(o => o.EmployeeId == EmployeeId && o.IsEnable == false).ToList();
            if (EmployeeTimelist != null && EmployeeTimelist.Count > 0)
            {
                string str = "";
                foreach (var item in EmployeeTimelist)
                {
                    DateTime week = item.Day;
                    string sql = "    SELECT     *    ";
                    sql += "  FROM  [dbo].[OrderWaiter]   ";
                    sql += "   where   (  [ServiceNo] = '" + code + "' or  [CarCode] = '" + code + "'  ) and   [IsFlag] = 1   and   [Ketime]  is not null ";
                    sql += " and ";
                    sql += " '" + week .Date.ToString("yyyy/MM/dd")+ "' = CONVERT(varchar(10), KStime, 111)   ";
                    sql += "   and   [Ketime] >= GETDATE()    ";
                    List<SqlParameter> paramList = new List<SqlParameter>();

                    NLogger.Fatal(sql);
                    DataTable dts = SqlQueryForDataTatable(sql, paramList);
                    if (dts != null && dts.Rows.Count > 0)
                    {
                        str += week.Date.ToString("yyyy/MM/dd") + "被以下订单占用：";
                        for (int i = 0; i < dts.Rows.Count; i++)
                        {
                            str += dts.Rows[i]["BillNo"].ToString() + ";";
                        }
                    }
                }
                return str+t;
            }
            else
            {
                return ""+t;
            }
        }


        public string Mancheckyes(int EmployeeId)
        {
            var code = EmployeeBLL.GetInstance().TableNoTracking().Where(o => o.Id == EmployeeId).Select(o => o.No).FirstOrDefault();
            var EmployeeTimelist = EmployeeTimeDetailBLL.GetInstance().TableNoTracking().Where(o => o.EmployeeId == EmployeeId && o.IsEnable ==true).ToList();
            if (EmployeeTimelist != null && EmployeeTimelist.Count > 0)
            {
                string str = "";
                foreach (var item in EmployeeTimelist)
                {
                    DateTime week = item.Day;
                    string sql = "    SELECT     *    ";
                    sql += "  FROM  [dbo].[OrderWaiter]   ";
                    sql += "   where   (  [ServiceNo] = '" + code + "' or  [CarCode] = '" + code + "'  ) and   [IsFlag] = 1   and   [KStime]  is not null    and   [Ketime]  is not null  ";
                    sql += " and ";
                    sql += " '" + week.Date.ToString("yyyy/MM/dd") + "' = CONVERT(varchar(10), KStime, 111)   ";
                    sql += "   and   [Ketime] >= GETDATE()    ";
                    
                    sql += "   and (  [Kstime]< '"+ week.Add(item.StartTime) + "' or    [Ketime]> '" + week.Add(item.EndTime) + "'  ) ";


                    List<SqlParameter> paramList = new List<SqlParameter>();

                    NLogger.Fatal(sql);
                    DataTable dts = SqlQueryForDataTatable(sql, paramList);
                    if (dts != null && dts.Rows.Count > 0)
                    {
                        str += week.Date.ToString("yyyy/MM/dd") + "被以下订单占用：";
                        for (int i = 0; i < dts.Rows.Count; i++)
                        {
                            str += dts.Rows[i]["BillNo"].ToString() + ";";
                        }
                    }
                }
                return str;
            }
            else
            {
                return "";
            }
        }


        string DayOfWeekName(DayOfWeek w)
        {
            string str = "";
            switch (w)
            {
                case DayOfWeek.Sunday:
                    str = "星期日";
                    break;
                case DayOfWeek.Monday:
                    str = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    str = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    str = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    str = "星期四";
                    break;
                case DayOfWeek.Friday:
                    str = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    str = "星期六";
                    break;
                default:
                    break;
            }
            return str;
        }


        public string Mancheckdowm(int EmployeeId)
        {
            var code = EmployeeBLL.GetInstance().TableNoTracking().Where(o => o.Id == EmployeeId).Select(o => o.No).FirstOrDefault();
            string str = "";
            string sql = "    SELECT     *    ";
            sql += "  FROM  [dbo].[OrderWaiter]   ";
            sql += "   where   (  [ServiceNo] = '" + code + "' or  [CarCode] = '" + code + "'  ) and   [IsFlag] = 1   and   [Ketime]  is not null ";
            sql += "   and   [Ketime] >= GETDATE()    ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            DataTable dts = SqlQueryForDataTatable(sql, paramList);
            if (dts != null && dts.Rows.Count > 0)
            {
                str += "被以下订单占用：";
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    str += dts.Rows[i]["BillNo"].ToString() + ";";
                }
            }
            return str;
        }



        #endregion

    }
}