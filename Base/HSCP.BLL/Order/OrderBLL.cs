//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单
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
using Conan.Utils;
#endregion

namespace Conan.BLL
{
    /// <summary>
    /// 订单
    /// </summary>
    public class OrderBLL : BaseBll<Order>
    {
        #region 构造函数
        private static OrderBLL instance;
        public static OrderBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderBLL();

            return instance;
        }
        #endregion
        //---------MongoDB
        #region 初始化 地理位置
        /// <summary>
        /// 初始化 地理位置
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public void IniLngLat()
        {
            DateTime dt = DateTime.Now;
            try
            {
                //删除历史数据
                long day = ZConvert.StrToLong(DateTimeUtility.ConvertToTimeStamp(dt.Date));
                UserLocations.Deletehis(day);

                // 初始化地址  
                var Employeelist=   EmployeeBLL.GetInstance().TableNoTracking().Where(o => o.EmployeeType == EmployeeTypeEnum.服务员工).Take(1).ToList();
                if(Employeelist!=null)
                {
                    for(int i=0;i<2;i++)
                    {
                        if(i==1)
                             day = ZConvert.StrToLong(DateTimeUtility.ConvertToTimeStamp(dt.AddDays(1).Date));

                        foreach (var Employee in Employeelist)
                        {
                            UserLocation UserLoc = new UserLocation();
                            UserLoc.EmployeeId = Employee.Id;
                            UserLoc.BillNo = "0";
                            UserLoc.Day = day;
                            UserLoc.StartTime = day;
                            //经纬度？  家庭地址？
                            UserLoc.Loc = new LocData() { lat = 24.468293, lon = 118.115433 };
                            UserLocations.Insert(UserLoc);

                        }
                    }

                    
                }


                for (int i = 0; i < 2; i++)
                {
                   long  tday = ZConvert.StrToLong(DateTimeUtility.ConvertToTimeStamp(dt.AddDays(i).Date));

                    //初始化 订单  
                    if (i == 1)
                        dt = dt.AddDays(1);

                    DateTime td = dt.Date;
                    DateTime te = td.AddDays(1);
                    var OrderWaiterlist = OrderWaiterBLL.GetInstance().TableNoTracking().Where(o => o.IsFlag == true && o.WaiterType == WaiterTypes.服务员工 && o.KStime!=null  &&  o.KStime.Value>= td && o.KStime.Value <te ).Take(1).ToList();
                    var snolist= OrderWaiterlist.Select(o => o.ServiceNo).ToList();
                    var tempEmployee=  EmployeeBLL.GetInstance().TableNoTracking().Where(o => snolist.Contains(o.No)).ToList();
                    var BillNolist = OrderWaiterlist.Select(o => o.BillNo).ToList();
                    var OrderAddrlist = OrderAddrBLL .GetInstance().TableNoTracking().Where(o => BillNolist.Contains(o.BillNo)).ToList();

                    if (OrderWaiterlist != null)
                    {
                        foreach (var OrderWaiter in OrderWaiterlist)
                        {
                            UserLocation UserLoc = new UserLocation();
                            var t=  tempEmployee.Where(o => o.No == OrderWaiter.ServiceNo).FirstOrDefault();
                            int tid =t!=null ?t.Id:0;
                            UserLoc.EmployeeId = tid;
                            UserLoc.BillNo = OrderWaiter.BillNo;
                            UserLoc.Day = tday;
                            UserLoc.StartTime =ZConvert.StrToLong(DateTimeUtility.ConvertToTimeStamp(OrderWaiter.KStime.Value.Date));

                            var oadr = OrderAddrlist.Where(o => o.BillNo == OrderWaiter.BillNo).FirstOrDefault();
                            if(oadr!=null && oadr.Lat.HasValue && oadr.Lng.HasValue)
                            {
                                UserLoc.Loc = new LocData() { lat = oadr.Lat.Value, lon = oadr.Lng.Value };
                            }
                            else
                            {

                                //派单的都有地址
                                //经纬度？
                              //  UserLoc.Loc = new LocData() { lat = 24.468293, lon = 118.115433 };
                            }
                            
                            UserLocations.Insert(UserLoc);
                        }
                    }

               }




            }
            catch (Exception ex)
            {
                NLogger.Error("初始化地理位置:" + ex.ToString());
               
            }

        }

        #endregion

        #region 高德  获取 经纬度
        /// <summary>
        /// 初始化 地理位置
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public string  GetLngLat(string addr)
        {

            try
            {
                string location = "";
                var wclient = new System.Net.WebClient();
                byte[] jsonbyte = System.Text.Encoding.UTF8.GetBytes("key=0de15829912943d1c14de65c7f0b854d&address=" + addr + "&city=");
                byte[] ret = wclient.UploadData("http://restapi.amap.com/v3/geocode/geo", "POST", jsonbyte);
                if (ret != null)
                {
                    string jsons = System.Text.Encoding.UTF8.GetString(ret);
                    var objneighborhood = JsonHelper.DeserializeObject<Root>(jsons);
                    if (objneighborhood != null)
                    {
                        if (objneighborhood.geocodes != null && objneighborhood.geocodes.Count > 0)
                            location = objneighborhood.geocodes[0].location;
                    }
                }
                return location;
            }
            catch (Exception ex)
            {
                NLogger.Error("初始化地理位置:"+ex.ToString());
                return "";
            }
           
        }

        #endregion

        #region 添加或更新用户位置信息
        /// <summary>
        /// 添加或更新用户位置信息
        /// </summary>
        /// <param name="UserLoc"></param>
        public static void Insert(UserLocation UserLoc)
        {
            UserLocations.Insert(UserLoc);
        }
        #endregion

        #region 获取范围内的员工列表
        
        List<UserLocationResult> GetUserLocationsList(double lon, double lat, int pageIndex, int pageSize,long day,long StartTime)
        {
            List<UserLocationResult> objList = new List<UserLocationResult>();
            objList= UserLocations.GetNear( lon,  lat,  pageIndex,  pageSize,day, StartTime);
           
         
            return objList;
        }


        /// <summary>
        /// 获取范围内的员工列表
        /// </summary>
        /// <param name="lon">经度</param>
        /// <param name="lat">纬度</param>
        /// <param name="day">日期  时间戳</param>
        /// <param name="StartTime">  需要派单的订单的 预约服务时间  时间戳</param>
        /// <returns>满足条件的员工距离列表</returns>
        public List<GeoEmployeeIdlist> GetEmployeeIdbygo(double lon, double lat, long day, long StartTime)
        {
            List<GeoEmployeeIdlist> list = new List<GeoEmployeeIdlist>();
            int pageIndex = 0;
            int pageSize = 10000;
            List<UserLocationResult> objList = OrderBLL.GetInstance().GetUserLocationsList(lon, lat, pageIndex, pageSize, day, StartTime);
            var query =
            from u in objList
            group u by u.EmployeeId into g
            orderby g.Key
            from u2 in g
            where u2.StartTime == g.Max(u3 => u3.StartTime)
            select u2;


            if (query != null && query.Count() > 0)
            {
                foreach (var item in query)
                {
                    GeoEmployeeIdlist GeoEmployeeIdlist = new GeoEmployeeIdlist();
                    GeoEmployeeIdlist.EmployeeId = item.EmployeeId;
                    GeoEmployeeIdlist.Distance = item.Distance;

                    list.Add(GeoEmployeeIdlist);
                }

            }

            return list;
        }


        #endregion

        #region 删除指定项
        /// <summary>
        /// 删除指定项
        /// </summary>
        /// <param name="UserLoc"></param>
        public void DeleteUserLocation(long Day, string BillNo, int EmployeeId)
        {
            UserLocations.Deleteitem( Day,  BillNo,  EmployeeId);
        }
        #endregion

     

        //---------------MongoDB
        #region 获取订单服务人数 时长  实体
        /// <summary>
        /// 获取订单服务人数 时长
        /// </summary>
        /// <param name="BillNo"></param>
        public void GetOrderHH(OrderAdd model, double TheoreticalWorks, out double totalhour, out int totalperson)
        {
          
             totalhour = 0; //总时长
                                  //人数  默认1 人 
             totalperson = 0;
            #region 理论时长 人数
            if (model.SalesId1 != null)
            {
                int z = 0;
                foreach (var item in model.SalesId1)
                {
                    #region 属性1
                    int s1 = model.SalesId1[z];
                    var SkuUnit1 = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.Id == s1).FirstOrDefault();
                    bool IsTheoreticalWork = SkuUnit1.IsTheoreticalWork;
                    if (IsTheoreticalWork)
                    {
                        totalhour += model.SalesIdNum1[z] * TheoreticalWorks;

                    }

                    if (SkuUnit1.UnitName.Contains("人"))
                    {
                        totalperson += model.SalesIdNum1[z];

                    }


                    #endregion

                    #region 属性2
                    if (model.SalesId2 != null)
                    {
                        int s2 = model.SalesId2[z];
                        var SkuUnit2 = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.Id == s2).FirstOrDefault();
                        bool IsTheoreticalWork2 = SkuUnit2.IsTheoreticalWork;
                        if (IsTheoreticalWork2)
                        {
                            totalhour += model.SalesIdNum2[z] * TheoreticalWorks;

                        }


                        if (SkuUnit2.UnitName.Contains("人"))
                        {
                            totalperson += model.SalesIdNum2[z];

                        }

                    }
                    #endregion

                    z++;
                }
            }
            #endregion
            if (totalperson == 0)
            {
                totalperson = 1;
            }

            if (totalhour == 0)
            {
                totalhour = 1 * TheoreticalWorks;
            }



        }
        #endregion

        #region 获取订单服务人数 时长  订单明细
        /// <summary>
        /// 获取订单服务人数 时长
        /// </summary>
        /// <param name="BillNo"></param>
        public void GetOrderHH(List<OrderItem> OrderItemlistend, double TheoreticalWorks,out double totalhoure, out int totalpersone)
        {
            #region 结束计算
             totalhoure = 0; //总时长
            totalpersone = 0;
            List<OrderItem> OrderItemliste = OrderItemlistend;
            #region 计算理论时长
            if (OrderItemliste != null)
            {
                foreach (var item in OrderItemliste)
                {
                    SkuDes OrderItemSkuDes = JsonHelper.DeserializeObject<SkuDes>(item.SkuDes);
                    #region 属性1
                    if (OrderItemSkuDes.Units != null && OrderItemSkuDes.Units.Count() != 0)
                    {
                        int SalesId1 = OrderItemSkuDes.Units[0].Id;
                        int SalesIdNum1 = OrderItemSkuDes.Units[0].Value;

                        var SkuUnit1 = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.Id == SalesId1).FirstOrDefault();
                        bool IsTheoreticalWork = SkuUnit1.IsTheoreticalWork;
                        if (IsTheoreticalWork)
                        {
                            totalhoure += SalesIdNum1 * TheoreticalWorks;

                        }
                        if (SkuUnit1.UnitName.Contains("人"))
                        {
                            totalpersone += SalesIdNum1;

                        }


                    }
                    #endregion

                    #region 属性2
                    if (OrderItemSkuDes.Units != null && OrderItemSkuDes.Units.Count() > 1)
                    {
                        int SalesId2 = OrderItemSkuDes.Units[1].Id;
                        int SalesIdNum2 = OrderItemSkuDes.Units[1].Value;

                        var SkuUnit2 = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.Id == SalesId2).FirstOrDefault();

                        bool IsTheoreticalWork = SkuUnit2.IsTheoreticalWork;
                        if (IsTheoreticalWork)
                        {
                            totalhoure += SalesIdNum2 * TheoreticalWorks;

                        }

                        if (SkuUnit2.UnitName.Contains("人"))
                        {
                            totalpersone += SalesIdNum2;

                        }

                    }
                    #endregion




                }
            }
            #endregion
            if (totalpersone == 0)
            {
                totalpersone = 1;
            }

            if (totalhoure == 0)
            {
                totalhoure = 1 * TheoreticalWorks;
            }
         
            #endregion

        }
        #endregion

        #region 溢价计算 
        /// <summary>
        /// 溢价计算
        /// </summary>
        /// <param name="BillNo"></param>
        public OptResult Orderyj(string BillNo)
        {
            string str = "";
            var order = OrderBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo).FirstOrDefault();
            var OrderAddr = OrderAddrBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo).FirstOrDefault();
            var product = ProductBll.GetInstance().TableNoTracking().Where(o => o.Id == order.ProductId).FirstOrDefault();
            int zh = 1;
            var SkuUnitlist = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.ProductId == product.Id).ToList();
            if (SkuUnitlist != null)
            {
                foreach (var items in SkuUnitlist)
                {
                    if (items.IsTheoreticalWork == true)
                    {
                        zh = items.MinValue;
                        break;
                    }
                }
            }


            MemberLevel objMemberLevel = MemberBLL.GetInstance().TableNoTracking().Where(o => o.Id == order.MemberId).FirstOrDefault().Level;
            OptResult r = new OptResult();
            decimal nprice = 0;
            decimal yjprice = 0;
            IRepository<OrderSub> repository = DalContext.Repository<OrderSub>();
            var objOrderSub = OrderSubBLL.GetInstance().Table(repository).Where(o => o.BillNo == BillNo && o.IsDefault == true).FirstOrDefault();
            var OrderItemlists = OrderItemBLL.GetInstance().TableNoTracking().Where(o => o.BillItemNo == objOrderSub.BillItemNo).ToList();
            #region 开始计算
            var work = product.TheoreticalWork;
            double TheoreticalWorks = work.HasValue ? work.Value : 0;
            double totalhours = 0; //总时长
            int totalpersons = 0;
            List<OrderItem> OrderItemlist = OrderItemlists;
            #region 计算理论时长
            if (OrderItemlist != null)
            {
                foreach (var item in OrderItemlist)
                {
                    SkuDes OrderItemSkuDes = JsonHelper.DeserializeObject<SkuDes>(item.SkuDes);
                    #region 属性1
                    if (OrderItemSkuDes.Units != null && OrderItemSkuDes.Units.Count() != 0)
                    {
                        int SalesId1 = OrderItemSkuDes.Units[0].Id;
                        int SalesIdNum1 = OrderItemSkuDes.Units[0].Value;

                        var SkuUnit1 = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.Id == SalesId1).FirstOrDefault();

                        if (SkuUnit1 != null)
                        {


                            bool IsTheoreticalWork = SkuUnit1.IsTheoreticalWork;
                            if (IsTheoreticalWork)
                            {
                                totalhours += SalesIdNum1 * TheoreticalWorks;

                            }
                            if (SkuUnit1.UnitName.Contains("人"))
                            {
                                totalpersons += SalesIdNum1;

                            }
                        }
                        else
                        {
                            if (OrderItemSkuDes.Units[0].UnitName.Contains("人"))
                            {
                                totalpersons += SalesIdNum1;

                            }


                            if (OrderItemSkuDes.Units[0].UnitName.Contains("时"))
                            {
                                totalhours += SalesIdNum1 * TheoreticalWorks;

                            }
                        }


                    }
                    #endregion

                    #region 属性2
                    if (OrderItemSkuDes.Units != null && OrderItemSkuDes.Units.Count() > 1)
                    {
                        int SalesId2 = OrderItemSkuDes.Units[1].Id;
                        int SalesIdNum2 = OrderItemSkuDes.Units[1].Value;






                        var SkuUnit2 = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.Id == SalesId2).FirstOrDefault();
                        if (SkuUnit2 != null)
                        {


                            bool IsTheoreticalWork = SkuUnit2.IsTheoreticalWork;
                            if (IsTheoreticalWork)
                            {
                                totalhours += SalesIdNum2 * TheoreticalWorks;

                            }

                            if (SkuUnit2.UnitName.Contains("人"))
                            {
                                totalpersons += SalesIdNum2;

                            }
                        }
                        else
                        {
                            if (OrderItemSkuDes.Units[1].UnitName.Contains("人"))
                            {
                                totalpersons += SalesIdNum2;

                            }


                            if (OrderItemSkuDes.Units[1].UnitName.Contains("时"))
                            {
                                totalhours += SalesIdNum2 * TheoreticalWorks;

                            }
                        }



                    }
                    #endregion




                }
            }
            #endregion
            if (totalpersons == 0)
            {
                totalpersons = 1;
            }
            if (totalhours == 0)
            {
                totalhours = 1 * TheoreticalWorks;
            }

            #endregion

            #region 价格
            if (OrderItemlist != null)
            {
                foreach (var item in OrderItemlist)
                {
                    SkuDes OrderItemSkuDes = JsonHelper.DeserializeObject<SkuDes>(item.SkuDes);


                    string tempsku2 = ",";

                    foreach (var sname in OrderItemSkuDes.SkuNames)
                    {
                        tempsku2 += sname + ",";
                    }

                    DateTime dtt = Convert.ToDateTime(order.StartTime);
                    SkuErrorViewModel SkuErrorViewModel = ProductBll.GetSkuPriceYj(order.ProductId, OrderAddr.AreaId, dtt, tempsku2, objMemberLevel);
                    SkuPrice objSkuPrice = SkuErrorViewModel.SkuPriceView;
                    if (SkuErrorViewModel.SkuError != SkuErrorEnum.正常)
                    {
                        str = SkuErrorViewModel.SkuError.ToString();
                        r.State = OptState.Error;
                        r.Msg = str;
                        return r;
                    }

                    nprice = objSkuPrice != null ? objSkuPrice.Price : 0;
                    yjprice = nprice;

                    if (order.IsYj == true)
                    {

                        if (product != null)
                        {
                            if (product.SpillPrice != null)
                            {
                                yjprice = (ZConvert.StrToDecimal(nprice) * product.SpillPrice.Value);
                            }
                        }
                    }






                }
            }



            #endregion
            decimal totalprice = 0;
            var OrderWaiterlist = OrderWaiterBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo && o.IsFlag == true).ToList();
            if (OrderWaiterlist != null && OrderWaiterlist.Count > 0)
            {
                foreach (var item in OrderWaiterlist)
                {
                    TimeSpan ss = item.RealEndTime.Value - item.StartTime.Value;
                    //总长
                    int zt = ZConvert.StrToInt(ss.TotalMinutes / 15);

                    //  zh = zh * 60;
                    int Tzh = zh * 60;
                    if (ss.TotalMinutes < Tzh)
                    {
                        zt = ZConvert.StrToInt(Tzh / 15);
                    }





                    //sku长
                    double zc = (totalhours * 60) / 15;

                    if (zt <= zc)
                    {
                        totalprice += (((zt * 15) / 60) * yjprice);
                    }
                    else
                    {

                        totalprice += ((((ZConvert.StrToDecimal(zc)) * 15) / 60) * yjprice);

                        totalprice += ((((ZConvert.StrToDecimal(zt) - ZConvert.StrToDecimal(zc)) * 15) / 60) * nprice);

                    }
                }
            }

            objOrderSub.RealTotalAmount = totalprice;

            objOrderSub.TotalAmount = totalprice;

            OrderSubBLL.GetInstance().Update(objOrderSub, repository);

            r.State = OptState.Success;

            return r;



        }
        #endregion

        #region 更新订单预约人数
        /// <summary>
        /// 更新订单预约人数
        /// </summary>
        /// <param name="BillNo"></param>
        public void UpdateYY(string BillNo)
        {

            #region 结束计算
            int totalpersone = 0;
            string BillItemNo = OrderSubBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo && o.IsDefault == true).Select(o => o.BillItemNo).FirstOrDefault();
            List<OrderItem> OrderItemliste = OrderItemBLL.GetInstance().TableNoTracking().Where(o => o.BillItemNo == BillItemNo).ToList();
            #region 计算理论时长
            if (OrderItemliste != null)
            {
                foreach (var item in OrderItemliste)
                {
                    SkuDes OrderItemSkuDes = JsonHelper.DeserializeObject<SkuDes>(item.SkuDes);
                    #region 属性1
                    if (OrderItemSkuDes.Units != null && OrderItemSkuDes.Units.Count() != 0)
                    {
                        int SalesId1 = OrderItemSkuDes.Units[0].Id;
                        int SalesIdNum1 = OrderItemSkuDes.Units[0].Value;

                        var SkuUnit1 = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.Id == SalesId1).FirstOrDefault();

                        if (SkuUnit1.UnitName.Contains("人"))
                        {
                            totalpersone += SalesIdNum1;

                        }


                    }
                    #endregion

                    #region 属性2
                    if (OrderItemSkuDes.Units != null && OrderItemSkuDes.Units.Count() > 1)
                    {
                        int SalesId2 = OrderItemSkuDes.Units[1].Id;
                        int SalesIdNum2 = OrderItemSkuDes.Units[1].Value;

                        var SkuUnit2 = SkuUnitBll.GetInstance().TableNoTracking().Where(o => o.Id == SalesId2).FirstOrDefault();



                        if (SkuUnit2.UnitName.Contains("人"))
                        {
                            totalpersone += SalesIdNum2;

                        }

                    }
                    #endregion




                }
            }
            #endregion
            if (totalpersone == 0)
            {
                totalpersone = 1;
            }



            #endregion



            IRepository<Order> repository = DalContext.Repository<Order>();
            var order = OrderBLL.GetInstance().Table(repository).Where(o => o.BillNo == BillNo).FirstOrDefault();
            order.YjNum = totalpersone;
            OrderBLL.GetInstance().Update(order, repository);




        }
        #endregion

        #region 更新订单优惠券抵用金额
        /// <summary>
        /// 更新订单优惠券抵用金额
        /// </summary>
        /// <param name="BillNo"></param>
        public void UpdateSYHQAmount(string BillNo)
        {
            IRepository<Order> repository = DalContext.Repository<Order>();
            var order = OrderBLL.GetInstance().Table(repository).Where(o => o.BillNo == BillNo).FirstOrDefault();
            if (order != null)
            {
                if (order.IsDao == false)
                {
                    var OrderPay = OrderPayBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo && o.PayType == PayTypes.优惠券).FirstOrDefault();
                    if (OrderPay != null)
                    {
                        order.SYHQAmount = OrderPay.PayValue;
                        OrderBLL.GetInstance().Update(order, repository);
                    }
                }
            }



        }
        #endregion

        #region 根据总订单号获取订单
        /// <summary>
        /// 根据总订单号获取订单
        /// </summary>
        /// <param name="BillNo">总订单号</param>
        /// <returns>订单对象</returns>
        public Order GetOrderByBillNo(string BillNo, IRepository<Order> repository = null)
        {
            return Table(repository).Where(o => o.BillNo == BillNo).FirstOrDefault();
        }
        #endregion

        #region 根据总订单号 计算金额
        /// <summary>
        /// 根据总订单号 计算金额
        /// </summary>
        /// <param name="BillNo">总订单号</param>
        /// <returns></returns>
        public void UpdateOrderAmountByBillNo(string BillNo)
        {
            IRepository<Order> repository = DalContext.Repository<Order>();
            var order = OrderBLL.GetInstance().Table(repository).Where(o => o.BillNo == BillNo).FirstOrDefault();
            var ordersub = OrderSubBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo).ToList();
            order.TotalAmount = ordersub.Select(o => o.TotalAmount).Sum();
            order.RealTotalAmount = ordersub.Select(o => o.RealTotalAmount).Sum();
            OrderBLL.GetInstance().Update(order, repository);
        }
        /// <summary>
        /// 根据总订单号 计算金额  集团单
        /// </summary>
        /// <param name="BillNo"></param>
        public void GUpdateOrderAmountByBillNo(string BillNo)
        {
            IRepository<Order> repository = DalContext.Repository<Order>();
            var order = OrderBLL.GetInstance().Table(repository).Where(o => o.BillNo == BillNo).FirstOrDefault();
            var ordersub = OrderSubBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo).ToList();
            order.TotalAmount = ordersub.Select(o => o.TotalAmount).Sum();
            order.RealTotalAmount = ordersub.Select(o => o.RealTotalAmount).Sum();
            order.Amount = order.RealTotalAmount;
            OrderBLL.GetInstance().Update(order, repository);
        }
        #endregion

        #region 根据单号修改部门
        /// <summary>
        /// 根据单号修改部门
        /// </summary>
        /// <param name="BillNo"></param>
        /// <param name="DepartId"></param>
        /// <returns></returns>
        public int UpdateDepart(string BillNo, int DepartId)
        {
            string sql = "update  [order]  set  [DepartId] = @DepartId  where BillNo = @BillNo ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp1 = new SqlParameter("@BillNo", BillNo);
            sp1.DbType = DbType.AnsiString;
            paramList.Add(sp1);
            SqlParameter sp = new SqlParameter("@DepartId", DepartId);
            sp.DbType = DbType.AnsiString;
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);
        }
        #endregion

        #region 根据单号删除订单
        /// <summary>
        /// 根据单号删除订单
        /// </summary>
        /// <param name="BillNo"></param>
        /// <param name="DepartId"></param>
        /// <returns></returns>
        public int DeleteOrder(string BillNo)
        {
            string sql = " delete [order] where BillNo=@BillNo; delete [ordersub] where BillNo=@BillNo; delete OrderWaiter where BillNo=@BillNo ; delete  from PreStock  where  BillNo=@BillNo ;delete from OrderSplit where [TargetBillNo]=@BillNo";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp1 = new SqlParameter("@BillNo", BillNo);
            sp1.DbType = DbType.AnsiString;
            paramList.Add(sp1);
            return ExecuteSqlCommand(sql, paramList);
        }
        #endregion

        #region 修改拆弹数量
        /// <summary>
        /// 修改拆弹数量
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public int UpdateSplitNum(string BillNo)
        {
            string sql = " update   [order] set SplitNum=(SELECT  COUNT(0)   FROM   [OrderSplit]   where  [SourceBillNo] = @BillNo)  where   BillNo = @BillNo  ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp1 = new SqlParameter("@BillNo", BillNo);
            sp1.DbType = DbType.AnsiString;
            paramList.Add(sp1);
            return ExecuteSqlCommand(sql, paramList);
        }
        #endregion

        #region 统计报表
        //public List<FinancialStatisticalViewModel> GetFinancialTotal(string filterCompanyEarnings,string filterEmployeesEarnings, string filterEmployeesToal, List<SqlParameter> paramListCompanyEarnings, List<SqlParameter> paramListEmployeesEarnings, List<SqlParameter> paramListEmployeesToal)
        //{
        //    //查询同部门同产品的统计
        //    StringBuilder sbCompanyEarnings = new StringBuilder();
        //    sbCompanyEarnings.AppendFormat("select  E.StoreName, A.StoreId,G.Id as DepartmentId,G.Path,G.Name ," +
        //        "D.ProductCategoryId,D.Id,D.Name as ProductName," +
        //        "Sum(B.RealTotalAmount) as RealTotalAmount " +
        //        "from[Order] A " +
        //        "Left join OrderSub B on A.BillNO = B.BillNo " +
        //        "Left join Product D on A.ProductId = D.Id " +
        //        "Left join Store E on A.StoreId = E.ID " +
        //        "Left join Department G on G.Id = A.DepartId " +
        //        "where   (A.OrderState = 90 or A.OrderState = 80) and G.id is not null  {0} " +
        //        "group by E.StoreName, A.StoreId, G.Id, G.Path, G.Name, D.ProductCategoryId, D.Id, D.Name", filterCompanyEarnings);
        //    string sqlCompanyEarnings = sbCompanyEarnings.ToString();
        //    DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
        //    //查询员工在本部门的统计
        //    StringBuilder sbEmployeesEarnings = new StringBuilder();
        //    sbEmployeesEarnings.AppendFormat("select dp.Id,dp.Name,od.ProductId,od.ProductName,E.StoreName,E.Id as StoreId,sum(ow.RealWage) as EmployeeAmount " +
        //                               "from OrderWages as ow " +
        //                               "left join Employee as emp on ow.No = emp.No " +
        //                               "left join Department as dp on dp.Id = emp.DepartId " +
        //                               "left join[Order] as od on od.BillNo = ow.BillNo " +
        //                               "Left join Product pt on od.ProductId = pt.Id "+
        //                               "Left join Store E on od.StoreId = E.ID "+
        //                               "where (od.OrderState = 90 or od.OrderState = 80) and dp.id is not null and dp.Id is not null and od.ProductId is not null {0} " +
        //                               "group by dp.Id, dp.Name, od.ProductId, od.ProductName,E.StoreName,E.Id", filterEmployeesEarnings);
        //    string sqlEmployeesEarnings = sbEmployeesEarnings.ToString();
        //    DataTable dtEmployeesEarnings = SqlQueryForDataTatable(sqlEmployeesEarnings, paramListEmployeesEarnings);
        //    //查询在同个部门定单的所有员工收入
        //    StringBuilder sbEmployeesToal = new StringBuilder();
        //    sbEmployeesToal.AppendFormat("select ProductId,ProductCategoryId,DepartId,StoreId,Path,sum(RealWage) as  RealWage from " +
        //                                 "(select  b.ProductId, d.ProductCategoryId, b.DepartId, "+
        //                                 "b.StoreId,g.Path, SUM(a.RealWage) as RealWage from OrderWages as a " +
        //                                 "left join [Order] as b on a.BillNo = b.BillNo "+
        //                                 "Left join Product D on b.ProductId = D.Id "+
        //                                 "left join Department G on G.Id = b.DepartId "+
        //                                 "where (b.OrderState = 90 or b.OrderState = 80) and G.id is not null and b.ProductId is not null and b.DepartId is not null and b.StoreId is not null {0} " +
        //                                 "group by b.BillNo, b.ProductId, b.DepartId, b.StoreId, d.ProductCategoryId,g.Path) as dt " +
        //                                 "group by  ProductId, ProductCategoryId, DepartId, StoreId,Path", filterEmployeesToal);
        //    string sqlEmployeesToal = sbEmployeesToal.ToString();
        //    DataTable dtEmployeesToal = SqlQueryForDataTatable(sqlEmployeesToal, paramListEmployeesToal);
        //    //处理合并逻辑
        //    List<FinancialStatisticalViewModel> FinancialStatisticals = new List<FinancialStatisticalViewModel>();
        //    for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
        //    {
        //        FinancialStatisticalViewModel FinancialStatistical = new FinancialStatisticalViewModel();
        //        FinancialStatistical.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
        //        FinancialStatistical.DepartmentId = int.Parse(dtCompanyEarnings.Rows[i]["DepartmentId"].ToString());
        //        FinancialStatistical.ProductCategoryId = int.Parse(dtCompanyEarnings.Rows[i]["ProductCategoryId"].ToString());
        //        FinancialStatistical.DepartmentName = dtCompanyEarnings.Rows[i]["Name"].ToString();
        //        FinancialStatistical.ProductName = dtCompanyEarnings.Rows[i]["ProductName"].ToString();
        //        FinancialStatistical.OrderAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["RealTotalAmount"].ToString());
        //        FinancialStatistical.StoreId = int.Parse(dtCompanyEarnings.Rows[i]["StoreId"].ToString());
        //        FinancialStatistical.ProductId= int.Parse(dtCompanyEarnings.Rows[i]["Id"].ToString());
        //        FinancialStatisticals.Add(FinancialStatistical);
        //    }
        //    for (int i = 0; i < dtEmployeesEarnings.Rows.Count; i++)
        //    {
        //        var Finan = FinancialStatisticals.Where(j => j.DepartmentId == int.Parse(dtEmployeesEarnings.Rows[i]["Id"].ToString()) && j.ProductId == int.Parse(dtEmployeesEarnings.Rows[i]["ProductId"].ToString())).FirstOrDefault();
        //        if (Finan != null)
        //        {
        //            if (Finan.DepartmentId == int.Parse(dtEmployeesEarnings.Rows[i]["Id"].ToString()) && Finan.ProductId == int.Parse(dtEmployeesEarnings.Rows[i]["ProductId"].ToString()))
        //            {
        //                Finan.EmployeeAmount = (decimal)dtEmployeesEarnings.Rows[i]["EmployeeAmount"];
        //                for (int j = 0; j < dtEmployeesToal.Rows.Count; j++)
        //                {
        //                    if (Finan.DepartmentId == int.Parse(dtEmployeesToal.Rows[j]["DepartId"].ToString())
        //                        && Finan.ProductCategoryId == int.Parse(dtEmployeesToal.Rows[j]["ProductCategoryId"].ToString())
        //                       && Finan.ProductId == int.Parse(dtEmployeesToal.Rows[j]["ProductId"].ToString())
        //                       && Finan.StoreId == int.Parse(dtEmployeesToal.Rows[j]["StoreId"].ToString()))
        //                     { Finan.StoreAmount = Finan.OrderAmount - decimal.Parse(dtEmployeesToal.Rows[j]["RealWage"].ToString()); }
        //                }
        //            }
        //        }
        //        else {
        //            FinancialStatisticalViewModel FinancialStatistical = new FinancialStatisticalViewModel();
        //            FinancialStatistical.StoreName = dtEmployeesEarnings.Rows[i]["StoreName"].ToString();
        //            FinancialStatistical.DepartmentId = int.Parse(dtEmployeesEarnings.Rows[i]["Id"].ToString());
        //            FinancialStatistical.ProductCategoryId = int.Parse(dtEmployeesEarnings.Rows[i]["ProductId"].ToString());
        //            FinancialStatistical.DepartmentName = dtEmployeesEarnings.Rows[i]["Name"].ToString();
        //            FinancialStatistical.ProductName = dtEmployeesEarnings.Rows[i]["ProductName"].ToString();
        //            FinancialStatistical.OrderAmount = 0;
        //            FinancialStatistical.EmployeeAmount = (decimal)dtEmployeesEarnings.Rows[i]["EmployeeAmount"];
        //            FinancialStatistical.StoreAmount = 0;
        //            FinancialStatistical.StoreId = int.Parse(dtEmployeesEarnings.Rows[i]["StoreId"].ToString());
        //            FinancialStatistical.ProductId = int.Parse(dtEmployeesEarnings.Rows[i]["ProductId"].ToString());
        //            FinancialStatisticals.Add(FinancialStatistical);
        //        }
        //    }
        //    return FinancialStatisticals;
        //}

        /// <summary>
        /// 财务明细报表
        /// </summary>
        /// <param name="filterCompanyEarnings"></param>
        /// <param name="paramListCompanyEarnings"></param>
        /// <returns></returns>
        public List<FinancialStatisticalDetailViewModels> GetFinancialStatisticalDetail(string filterCompanyEarnings, string filterCompanyWai, List<SqlParameter> paramListCompanyEarnings)
        {
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select st.StoreName,pd.ProductCategoryId,od.ProductName,od.BillNo," +
                                           "dt.Name,od.RealTotalAmount,SUM(ow.RealWage) as RealWage,dt.Id,od.BillNo from OrderWages as ow " +
                                           "left join[Order] as od on ow.BillNo = od.BillNo left join Employee as emp on emp.No = ow.No " +
                                           "left join Department as dt on dt.Id = emp.DepartId " +
                                           "left join Store as st on st.Id = od.StoreId " +
                                           "left join Product pd on pd.Id = od.ProductId " +
                                           "where 1 = 1  and od.BillNo in(select od.BillNo from OrderWages as ow " +
                                           "left join [Order] as od on ow.BillNo = od.BillNo left join Employee as emp on emp.No = ow.No " +
                                           "left join Department as dt on dt.Id = emp.DepartId " +
                                           "left join Store as st on st.Id = od.StoreId " +
                                           "left join Product pd on pd.Id = od.ProductId " +
                                           "where 1 = 1  {0}) {1} " +
                                           "group by st.StoreName, pd.ProductCategoryId, od.ProductName,od.BillNo, dt.Name, od.RealTotalAmount, od.BillNo, dt.Id  order by st.StoreName,od.BillNo Desc", filterCompanyEarnings, filterCompanyWai);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //处理逻辑
            List<FinancialStatisticalDetailViewModels> FinancialStatisticals = new List<FinancialStatisticalDetailViewModels>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                FinancialStatisticalDetailViewModels FinancialStatistical = new FinancialStatisticalDetailViewModels();
                FinancialStatistical.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
                FinancialStatistical.DepartmentName = dtCompanyEarnings.Rows[i]["Name"].ToString();
                FinancialStatistical.ProductName = dtCompanyEarnings.Rows[i]["ProductName"].ToString();
                FinancialStatistical.OrderBillNo = dtCompanyEarnings.Rows[i]["BillNo"].ToString();
                FinancialStatistical.OrderAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["RealTotalAmount"].ToString());
                FinancialStatistical.EmployeeAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["RealWage"].ToString());
                FinancialStatisticals.Add(FinancialStatistical);
            }
            return FinancialStatisticals;
        }
        /// <summary>
        /// 财务总表
        /// </summary>
        /// <param name="filterCompanyEarnings"></param>
        /// <param name="filterEmployeesEarnings"></param>
        /// <param name="filterEmployeesToal"></param>
        /// <param name="paramListCompanyEarnings"></param>
        /// <param name="paramListEmployeesEarnings"></param>
        /// <param name="paramListEmployeesToal"></param>
        /// <returns></returns>
        public List<FinancialStatisticalViewModel> GetFinancialTotal(string filterCompanyEarnings, string filterEmployeesEarnings, string filterEmployeesToal, List<SqlParameter> paramListCompanyEarnings, List<SqlParameter> paramListEmployeesEarnings, List<SqlParameter> paramListEmployeesToal)
        {
            //查询同部门同产品的统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select  E.StoreName, A.StoreId,G.Id as DepartmentId,G.Path,G.Name ," +
                "D.ProductCategoryId,D.Id,D.Name as ProductName," +
                "Sum(B.RealTotalAmount) as RealTotalAmount " +
                "from[Order] A " +
                "Left join OrderSub B on A.BillNO = B.BillNo " +
                "Left join Product D on A.ProductId = D.Id " +
                "Left join Store E on A.StoreId = E.ID " +
                "Left join Department G on G.Id = A.DepartId " +
                "where  A.IsGroup=0  and    (A.OrderState = 90 or A.OrderState = 80) and G.id is not null  {0} " +
                "group by E.StoreName, A.StoreId, G.Id, G.Path, G.Name, D.ProductCategoryId, D.Id, D.Name order by e.StoreName,g.Id,d.Id desc", filterCompanyEarnings);



            string sqlCompanyEarnings = sbCompanyEarnings.ToString();


            NLogger.Fatal(sqlCompanyEarnings);
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //处理合并逻辑
            List<FinancialStatisticalViewModel> FinancialStatisticals = new List<FinancialStatisticalViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                FinancialStatisticalViewModel FinancialStatistical = new FinancialStatisticalViewModel();
                FinancialStatistical.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
                FinancialStatistical.DepartmentId = int.Parse(dtCompanyEarnings.Rows[i]["DepartmentId"].ToString());
                FinancialStatistical.ProductCategoryId = int.Parse(dtCompanyEarnings.Rows[i]["ProductCategoryId"].ToString());
                FinancialStatistical.DepartmentName = dtCompanyEarnings.Rows[i]["Name"].ToString();
                FinancialStatistical.ProductName = dtCompanyEarnings.Rows[i]["ProductName"].ToString();
                FinancialStatistical.OrderAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["RealTotalAmount"].ToString());
                FinancialStatistical.StoreId = int.Parse(dtCompanyEarnings.Rows[i]["StoreId"].ToString());
                FinancialStatistical.ProductId = int.Parse(dtCompanyEarnings.Rows[i]["Id"].ToString());
                //查询员工在本部门的统计
                StringBuilder sbEmployeesEarnings = new StringBuilder();
                sbEmployeesEarnings.AppendFormat("select dp.Id,dp.Name, od.ProductId, od.ProductName,E.StoreName" +
                                                 ",stuff((select ',' + convert(varchar(40), od.BillNo) from " +
                                                 " OrderWages as ow left join Employee as emp on ow.No = emp.No " +
                                                 "left join Department as dp on dp.Id = emp.DepartId " +
                                                 "left join[Order] as od on od.BillNo = ow.BillNo " +
                                                 "Left join Product pt on od.ProductId = pt.Id " +
                                                 "Left join Store E on od.StoreId = E.ID " +
                                                 "where(od.OrderState = 90 or od.OrderState = 80) and dp.id is not null and dp.Id is not null " +
                                                 "and od.ProductId is not null  {0} {1} " +
                                                 "and ow.BillNo in (select  a.BillNo from[Order] A Left join OrderSub B on A.BillNO = B.BillNo " +
                                                 "Left join Product D on A.ProductId = D.Id Left join Store E on A.StoreId = E.ID " +
                                                 "Left join Department G on G.Id = A.DepartId where(A.OrderState = 90 or A.OrderState = 80) and G.id is not null " +
                                                 "{2} {3} {4} {5}) " +
                                                 "group by od.BillNo for xml path('')),1,1,'') as BillNos " +
                                                 ",sum(ow.RealWage) as EmployeeAmount " +
                                                 "from OrderWages as ow " +
                                                 "left join Employee as emp on ow.No = emp.No " +
                                                 "left join Department as dp on dp.Id = emp.DepartId " +
                                                 "left join[Order] as od on od.BillNo = ow.BillNo " +
                                                 "Left join Product pt on od.ProductId = pt.Id " +
                                                 "Left join Store E on od.StoreId = E.ID " +
                                                 "where (od.OrderState = 90 or od.OrderState = 80) and " +
                                                 "dp.id is not null and dp.Id is not null and od.ProductId is not null {0} {1} " +
                                                 //"and od.StoreId = '2' and  pt.Id = 30 "+
                                                 //"and od.PaySettlementTime > '2016/9/1 0:00:00' "+
                                                 //"and od.PaySettlementTime < '2016-09-04 10:03:21.123' "+
                                                 "and ow.BillNo in (select  a.BillNo from[Order] A " +
                                                 "Left join OrderSub B on A.BillNO = B.BillNo " +
                                                 "Left join Product D on A.ProductId = D.Id " +
                                                 "Left join Store E on A.StoreId = E.ID " +
                                                 "Left join Department G on G.Id = A.DepartId " +
                                                 "where(A.OrderState = 90 or A.OrderState = 80) and G.id is not null " +
                                                 "{2} {3} {4} {5}) " +
                                                 "group by dp.Id, dp.Name, od.ProductId, od.ProductName,E.StoreName  order by dp.Id,od.ProductId desc", filterEmployeesEarnings, " and pt.Id=" + FinancialStatistical.ProductId + "", filterCompanyEarnings, " and d.Id=" + FinancialStatistical.ProductId + "", " and g.Id=" + FinancialStatistical.DepartmentId + " ", " and E.Id=" + FinancialStatistical.StoreId + " ");
                string sqlEmployeesEarnings = sbEmployeesEarnings.ToString();

                NLogger.Fatal(sqlEmployeesEarnings);

                DataTable dtEmployeesEarnings = SqlQueryForDataTatable(sqlEmployeesEarnings, paramListEmployeesEarnings);
                FinancialStatistical.FinancialStatisticalDetailViewModel = new List<FinancialStatisticalDetailViewModel>();
                decimal EmployeeAmount = 0;
                for (int j = 0; j < dtEmployeesEarnings.Rows.Count; j++)
                {
                    FinancialStatisticalDetailViewModel Detail = new FinancialStatisticalDetailViewModel();
                    Detail.DepartmentId = (int)dtEmployeesEarnings.Rows[j]["Id"];
                    Detail.DepartmentName = dtEmployeesEarnings.Rows[j]["Name"].ToString();
                    Detail.ProcuctName = dtEmployeesEarnings.Rows[j]["ProductName"].ToString();
                    Detail.StoreName = dtEmployeesEarnings.Rows[j]["StoreName"].ToString();
                    Detail.EmployeeAmount = decimal.Parse(dtEmployeesEarnings.Rows[j]["EmployeeAmount"].ToString());
                    Detail.BillNos = dtEmployeesEarnings.Rows[j]["BillNos"].ToString();
                    EmployeeAmount += Detail.EmployeeAmount;
                    FinancialStatistical.FinancialStatisticalDetailViewModel.Add(Detail);
                }

                NLogger.Fatal(EmployeeAmount.ToString());

                FinancialStatistical.StoreAmount = FinancialStatistical.OrderAmount - EmployeeAmount;
                FinancialStatisticals.Add(FinancialStatistical);
            }
            return FinancialStatisticals;
        }
        /// <summary>
        /// 业务来源表
        /// </summary>
        public List<SourcesOfBusinessStatisticsViewModel> GetBusinessSource(string filterCompanyEarnings, string filterEmployeesEarnings, List<SqlParameter> paramListCompanyEarnings, List<SqlParameter> paramListEmployeesEarnings)
        {
            //查询业务来源统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select pd.Name,st.StoreName,od.StoreId,pd.ProductCategoryId,pd.Id as ProductId," +
                                            "dp.Name  as departName, dp.Id as departId,dp.Path,od.BuChannel,SUM(od.RealTotalAmount) as TotalAmount " +
                                            "from [Order] as od " +
                                            "left join Store as st on od.StoreId = st.Id " +
                                            "left join Product as pd on od.ProductId = pd.Id " +
                                            "left join Department as dp on od.DepartId = dp.Id " +
                                            "where(od.OrderState = 80 or od.OrderState = 90) and dp.Id is not null {0} " +
                                            "group by pd.Name, st.StoreName, od.StoreId, pd.ProductCategoryId, pd.Id, dp.Name," +
                                            "dp.Id, dp.Path, od.BuChannel order by od.StoreId,dp.Id Desc", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //查询业务来源条数
            StringBuilder sbEmployeesEarnings = new StringBuilder();
            sbEmployeesEarnings.AppendFormat(" select od.StoreId,ProductId,dp.Id,pd.ProductCategoryId,BuChannel,dp.path," +
                                            "COUNT(*) as counts from [Order]   as od " +
                                            "left join Product as pd on od.ProductId = pd.Id " +
                                            "left join Department as dp on od.DepartId = dp.Id " +
                                            "where(OrderState = 80 or OrderState = 90)  and dp.Id is not null {0} " +
                                            "group by od.StoreId, ProductId, dp.Id, pd.ProductCategoryId, BuChannel," +
                                            "dp.path order by od.StoreId,dp.Id Desc", filterEmployeesEarnings);
            string sqlEmployeesEarnings = sbEmployeesEarnings.ToString();
            DataTable dtEmployeesEarnings = SqlQueryForDataTatable(sqlEmployeesEarnings, paramListEmployeesEarnings);
            //处理合并逻辑
            List<SourcesOfBusinessStatisticsViewModel> sourcesOfBusinessStatisticss = new List<SourcesOfBusinessStatisticsViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                //  DepartmentName = p_sm.Key.DepartmentName,
                //                       StoreName = p_sm.Key.StoreName,
                //                       ProductName = p_sm.Key.ProductName,
                //                       BuChannel = p_sm.Key.BuChannel,
                //                       Orders = p_sm.Count(),
                //                       OrderAmount = p_sm.Sum(o => o.OrderAmount)
                SourcesOfBusinessStatisticsViewModel sourcesOfBusinessStatistics = new SourcesOfBusinessStatisticsViewModel();
                sourcesOfBusinessStatistics.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
                sourcesOfBusinessStatistics.DepartmentId = int.Parse(dtCompanyEarnings.Rows[i]["departId"].ToString());
                sourcesOfBusinessStatistics.ProductCategoryId = int.Parse(dtCompanyEarnings.Rows[i]["ProductCategoryId"].ToString());
                sourcesOfBusinessStatistics.DepartmentName = dtCompanyEarnings.Rows[i]["departName"].ToString();
                sourcesOfBusinessStatistics.ProductName = dtCompanyEarnings.Rows[i]["Name"].ToString();
                sourcesOfBusinessStatistics.OrderAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["TotalAmount"].ToString());
                sourcesOfBusinessStatistics.StoreId = int.Parse(dtCompanyEarnings.Rows[i]["StoreId"].ToString());
                sourcesOfBusinessStatistics.ProductId = int.Parse(dtCompanyEarnings.Rows[i]["ProductId"].ToString());
                sourcesOfBusinessStatistics.BuChannel = (BusinessChannel)(int.Parse(dtCompanyEarnings.Rows[i]["BuChannel"].ToString()));
                sourcesOfBusinessStatisticss.Add(sourcesOfBusinessStatistics);
            }
            for (int i = 0; i < dtEmployeesEarnings.Rows.Count; i++)
            {
                var Finan = sourcesOfBusinessStatisticss.Where(j => j.DepartmentId == int.Parse(dtEmployeesEarnings.Rows[i]["Id"].ToString()) && j.ProductId == int.Parse(dtEmployeesEarnings.Rows[i]["ProductId"].ToString()) && j.StoreId == int.Parse(dtEmployeesEarnings.Rows[i]["StoreId"].ToString()) && j.ProductCategoryId == int.Parse(dtEmployeesEarnings.Rows[i]["ProductCategoryId"].ToString()) && j.BuChannel == (BusinessChannel)(int.Parse(dtEmployeesEarnings.Rows[i]["BuChannel"].ToString()))).FirstOrDefault();
                if (Finan != null)
                {
                    Finan.Orders = int.Parse(dtEmployeesEarnings.Rows[i]["counts"].ToString());
                }
            }
            return sourcesOfBusinessStatisticss;
        }
        /// <summary>
        /// 业务统计报表
        /// </summary>
        public List<BusinessStatisticalViewModel> GetBusinessStatisticalReport(string filterCompanyEarnings, string filterEmployeesEarnings, List<SqlParameter> paramListCompanyEarnings, List<SqlParameter> paramListEmployeesEarnings)
        {
            //查询业务来源统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select pd.Name,st.StoreName,od.StoreId,pd.ProductCategoryId,pd.Id as ProductId," +
                                           "dp.Name as departName, dp.Id as departId,dp.Path,ca.Name as AreaName,ca.Id as CityAreaId," +
                                           "ca.CityId as CityId,SUM(od.RealTotalAmount) as TotalAmount from[Order] as od " +
                                           "left join Store as st on od.StoreId = st.Id " +
                                           "left join Product as pd on od.ProductId = pd.Id " +
                                           "left join Department as dp on od.DepartId = dp.Id " +
                                           "left join OrderAddr as oa on od.BillNo = oa.BillNo " +
                                           "left join CityArea as ca on oa.AreaId = ca.Id " +
                                           "left join orderExt as ode on ode.BillNo=od.BillNo " +
                                           "where(od.OrderState = 80 or od.OrderState = 90) and dp.Id is not null  and ca.Id is not null and  od.PaySettlement=2  and  od.IsPayoff=1  and   od.IsGroup=0  {0} " +
                                           "group by pd.Name, st.StoreName, od.StoreId, pd.ProductCategoryId, pd.Id," +
                                           "dp.Name, dp.Id, dp.Path, ca.Name, ca.Id, ca.CityId order by od.StoreId,pd.Id,dp.Id Desc", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //查询业务来源条数
            StringBuilder sbEmployeesEarnings = new StringBuilder();
            sbEmployeesEarnings.AppendFormat(" select od.StoreId,ProductId,dp.Id,pd.ProductCategoryId,ca.Name as AreaName," +
                                            "ca.Id as CityAreaId,ca.CityId as CityId,dp.path,COUNT(*) as counts from [Order] as od " +
                                            "left join Product as pd on od.ProductId = pd.Id " +
                                            "left join Department as dp on od.DepartId = dp.Id " +
                                            "left join OrderAddr as oa on od.BillNo = oa.BillNo " +
                                            "left join CityArea as ca on oa.AreaId = ca.Id " +
                                            "left join orderExt as ode on ode.BillNo=od.BillNo " +
                                            "where(OrderState = 80 or OrderState = 90)  and dp.Id is not null and ca.Id is not null and  od.PaySettlement=2  and  od.IsPayoff=1  and   od.IsGroup=0  {0} " +
                                            "group by od.StoreId, ProductId, dp.Id, pd.ProductCategoryId, dp.path," +
                                            "ca.Name, ca.Id, ca.CityId order by od.StoreId,ProductId,dp.Id Desc", filterEmployeesEarnings);
            string sqlEmployeesEarnings = sbEmployeesEarnings.ToString();
            DataTable dtEmployeesEarnings = SqlQueryForDataTatable(sqlEmployeesEarnings, paramListEmployeesEarnings);
            //处理合并逻辑
            List<BusinessStatisticalViewModel> businessStatisticals = new List<BusinessStatisticalViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                BusinessStatisticalViewModel businessStatistical = new BusinessStatisticalViewModel();
                businessStatistical.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
                businessStatistical.DepartmentId = int.Parse(dtCompanyEarnings.Rows[i]["departId"].ToString());
                businessStatistical.ProductCategoryId = int.Parse(dtCompanyEarnings.Rows[i]["ProductCategoryId"].ToString());
                businessStatistical.DepartmentName = dtCompanyEarnings.Rows[i]["departName"].ToString();
                businessStatistical.ProductName = dtCompanyEarnings.Rows[i]["Name"].ToString();
                businessStatistical.OrderAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["TotalAmount"].ToString());
                businessStatistical.StoreId = int.Parse(dtCompanyEarnings.Rows[i]["StoreId"].ToString());
                businessStatistical.ProductId = int.Parse(dtCompanyEarnings.Rows[i]["ProductId"].ToString());
                businessStatistical.AreaName = dtCompanyEarnings.Rows[i]["AreaName"].ToString();
                businessStatistical.CityAreaId = int.Parse(dtCompanyEarnings.Rows[i]["CityAreaId"].ToString());
                businessStatistical.CityId = int.Parse(dtCompanyEarnings.Rows[i]["CityId"].ToString());
                businessStatisticals.Add(businessStatistical);
            }
            for (int i = 0; i < dtEmployeesEarnings.Rows.Count; i++)
            {
                var Finan = businessStatisticals.Where(j => j.DepartmentId == int.Parse(dtEmployeesEarnings.Rows[i]["Id"].ToString()) && j.ProductId == int.Parse(dtEmployeesEarnings.Rows[i]["ProductId"].ToString()) && j.StoreId == int.Parse(dtEmployeesEarnings.Rows[i]["StoreId"].ToString()) && j.ProductCategoryId == int.Parse(dtEmployeesEarnings.Rows[i]["ProductCategoryId"].ToString()) && j.CityId == int.Parse(dtEmployeesEarnings.Rows[i]["CityId"].ToString()) && j.CityAreaId == int.Parse(dtEmployeesEarnings.Rows[i]["CityAreaId"].ToString())).FirstOrDefault();
                if (Finan != null)
                {
                    Finan.Orders = int.Parse(dtEmployeesEarnings.Rows[i]["counts"].ToString());
                }
            }
            return businessStatisticals;
        }
        /// <summary>
        /// 员工业绩明细报表
        /// </summary>
        public List<EmployeeAchievementDetailViewModel> GetEmployeeAchievementDetailReport(string filterCompanyEarnings, List<SqlParameter> paramListCompanyEarnings)
        {
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select ow.BillNo,ow.No,pt.Name,sum(ow.RealWage) as EmployeeAmount," +
                                           "od.[StartTime] as Singletime  from OrderWages as ow " +
                                           "left join[Order] as od on od.BillNo = ow.BillNo " +
                                           "Left join Product pt on od.ProductId = pt.Id " +
                                           "where (ow.WaiterType = 1 or ow.WaiterType = 3) and (od.OrderState = 90 or od.OrderState = 80) " +
                                           "and pt.ServiceOption = 1  and ow.No is not null {0} " +
                                           "group by  ow.BillNo, ow.No, od.ProductId, od.ProductName," +
                                           "od.[StartTime], pt.Name order by od.ProductId,ow.BillNo Desc", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //处理合并逻辑
            List<EmployeeAchievementDetailViewModel> EmployeeAchievementDetails = new List<EmployeeAchievementDetailViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                EmployeeAchievementDetailViewModel EmployeeAchievementDetail = new EmployeeAchievementDetailViewModel();
                EmployeeAchievementDetail.BillNo = dtCompanyEarnings.Rows[i]["BillNo"].ToString();
                EmployeeAchievementDetail.EmployeeNo = dtCompanyEarnings.Rows[i]["No"].ToString();
                EmployeeAchievementDetail.ProductName = dtCompanyEarnings.Rows[i]["Name"].ToString();
                EmployeeAchievementDetail.RealStartTime = DateTime.Parse(dtCompanyEarnings.Rows[i]["Singletime"].ToString());
                EmployeeAchievementDetail.Amount = decimal.Parse(dtCompanyEarnings.Rows[i]["EmployeeAmount"].ToString());
                EmployeeAchievementDetails.Add(EmployeeAchievementDetail);
            }
            return EmployeeAchievementDetails;
        }
        /// <summary>
        /// 车辆业绩明细报表
        /// </summary>
        public List<VehicleAchievementDetailViewModel> GetVehicleAchievementDetailReport(string filterCompanyEarnings, List<SqlParameter> paramListCompanyEarnings)
        {
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select ow.BillNo,ow.No,ca.CarNumber,sum(ow.[GetWage]) as EmployeeAmount,od.[StartTime] as SettlementTime " +
                                            "from OrderWages as ow " +
                                            "left join[Order] as od on od.BillNo = ow.BillNo " +
                                            "Left join Product pt on od.ProductId = pt.Id " +
                                            "left join Car as ca on ca.CarNumber = ow.ServiceNo " +
                                            "where ow.WaiterType in (2,3) and (od.OrderState = 90 or od.OrderState = 80) and ow.No is not null {0} " +
                                            "group by  ow.BillNo, ow.No, od.ProductId, od.ProductName, od.StartTime," +
                                            "pt.Name, ca.CarNumber order by od.ProductId,ow.BillNo Desc", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //处理合并逻辑
            List<VehicleAchievementDetailViewModel> vehicleAchievementDetails = new List<VehicleAchievementDetailViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                VehicleAchievementDetailViewModel vehicleAchievementDetail = new VehicleAchievementDetailViewModel();
                vehicleAchievementDetail.BillNo = dtCompanyEarnings.Rows[i]["BillNo"].ToString();
                vehicleAchievementDetail.EmployeeNo = dtCompanyEarnings.Rows[i]["No"].ToString();
                vehicleAchievementDetail.VehicleNo = dtCompanyEarnings.Rows[i]["CarNumber"].ToString();
                vehicleAchievementDetail.RealStartTime = DateTime.Parse(dtCompanyEarnings.Rows[i]["SettlementTime"].ToString());
                vehicleAchievementDetail.Amount = decimal.Parse(dtCompanyEarnings.Rows[i]["EmployeeAmount"].ToString());
                vehicleAchievementDetails.Add(vehicleAchievementDetail);
            }
            return vehicleAchievementDetails;
        }
        /// <summary>
        /// 车辆业绩报表
        /// </summary>
        public List<VehicleAchievementViewModel> GetVehicleAchievementReport(string filterCompanyEarnings, List<SqlParameter> paramListCompanyEarnings)
        {
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select st.StoreName,ca.CarNumber,ca.CarCode,SUM(ow.RealWage) " +
                                           "as RealWage from OrderWages as ow " +
                                           "left join  dbo.[Order] as od  on ow.BillNo = od.BillNo " +
                                           "left join Store as st on od.StoreId = st.Id " +
                                           "left join Car as ca on ca.CarNumber = ow.ServiceNo " +
                                           "where SettlementTime is not null and ow.WaiterType = 2 {0} " +
                                           "group by st.StoreName, ca.CarNumber, ca.CarCode order by st.StoreName,ca.CarCode Desc", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //处理合并逻辑
            List<VehicleAchievementViewModel> vehicleAchievements = new List<VehicleAchievementViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                VehicleAchievementViewModel vehicleAchievement = new VehicleAchievementViewModel();
                vehicleAchievement.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
                vehicleAchievement.VehicleNumber = dtCompanyEarnings.Rows[i]["CarCode"].ToString();
                vehicleAchievement.VehicleNo = dtCompanyEarnings.Rows[i]["CarNumber"].ToString();
                vehicleAchievement.Amount = decimal.Parse(dtCompanyEarnings.Rows[i]["RealWage"].ToString());
                vehicleAchievements.Add(vehicleAchievement);
            }
            return vehicleAchievements;
        }

        /// <summary>
        /// 人员业绩报表
        /// </summary>
        public List<EmployeeAchievementViewModel> GetEmployeeAchievementReport(string filterCompanyEarnings, List<SqlParameter> paramListCompanyEarnings)
        {
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat(" select st.StoreName,dp.Name,emp.RealName,emp.No,empinfo.BankCards," +
                                           "SUM(ow.RealWage) as Amount from OrderWages as ow " +
                                           "left join  Employee as emp on  ow.ServiceNo = emp.No " +
                                           "left join EmployeeInfo as empinfo on emp.Id = empinfo.EmployeeId " +
                                           "left join  Department as dp on emp.DepartId = dp.Id " +
                                           "left join[Order] as od on ow.BillNo = od.BillNo " +
                                           "left join Store as st  on od.StoreId = st.Id " +
                                           "where(od.OrderState = 80 or od.OrderState = 90) " +
                                           "and(ow.WaiterType = 1 or ow.WaiterType = 3) and emp.No is not null and ow.RealWage is not null {0}" +
                                           "group by st.StoreName, dp.Name, emp.RealName, emp.No,empinfo.BankCards order by st.StoreName,dp.Name Desc", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();

            NLogger.Warn(sqlCompanyEarnings);

            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //处理合并逻辑
            List<EmployeeAchievementViewModel> vehicleAchievements = new List<EmployeeAchievementViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                EmployeeAchievementViewModel vehicleAchievement = new EmployeeAchievementViewModel();
                vehicleAchievement.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
                vehicleAchievement.DepartmentName = dtCompanyEarnings.Rows[i]["Name"].ToString();
                vehicleAchievement.Name = dtCompanyEarnings.Rows[i]["RealName"].ToString();
                vehicleAchievement.BankCards = dtCompanyEarnings.Rows[i]["BankCards"].ToString();
                vehicleAchievement.No = dtCompanyEarnings.Rows[i]["No"].ToString();
                vehicleAchievement.Amount = decimal.Parse(dtCompanyEarnings.Rows[i]["Amount"].ToString());
                vehicleAchievements.Add(vehicleAchievement);
            }
            return vehicleAchievements;
        }
        /// <summary>
        /// 财务订单收入报表
        /// </summary>
        public List<FinancialOrderDetailsViewModel> GetFinancialOrderDetailsReport(string filterCompanyEarnings, string filterEmployeesEarnings, List<SqlParameter> paramListCompanyEarnings, List<SqlParameter> paramListEmployeesEarnings)
        {
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select pd.Name,st.StoreName,od.StoreId,pd.ProductCategoryId,pd.Id as ProductId," +
                                           "dp.Name as departName, dp.Id as departId,dp.Path,SUM(od.RealTotalAmount) as TotalAmount " +
                                           "from[Order] as od " +
                                           "left join Store as st on od.StoreId = st.Id " +
                                           "left join Product as pd on od.ProductId = pd.Id " +
                                           "left join Department as dp on od.DepartId = dp.Id " +
                                           "where(od.OrderState = 80 or od.OrderState = 90) and dp.Id is not null {0} " +
                                           "group by pd.Name, st.StoreName, od.StoreId, pd.ProductCategoryId, pd.Id," +
                                           "dp.Name, dp.Id, dp.Path order by od.StoreId,pd.Id,dp.Id Desc", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //查询条数
            StringBuilder sbEmployeesEarnings = new StringBuilder();
            sbEmployeesEarnings.AppendFormat("select od.StoreId,ProductId,dp.Id,pd.ProductCategoryId," +
                                             "dp.path,COUNT(*) as counts from [Order]   as od " +
                                             "left join Product as pd on od.ProductId = pd.Id " +
                                             "left join Department as dp on od.DepartId = dp.Id " +
                                             "where(OrderState = 80 or OrderState = 90)  and dp.Id is not null {0} " +
                                             "group by od.StoreId, ProductId, dp.Id, pd.ProductCategoryId, dp.path order by od.StoreId,ProductId,dp.Id Desc", filterEmployeesEarnings);
            string sqlEmployeesEarnings = sbEmployeesEarnings.ToString();
            DataTable dtEmployeesEarnings = SqlQueryForDataTatable(sqlEmployeesEarnings, paramListEmployeesEarnings);
            //处理合并逻辑
            List<FinancialOrderDetailsViewModel> financialOrderDetails = new List<FinancialOrderDetailsViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                FinancialOrderDetailsViewModel financialOrderDetail = new FinancialOrderDetailsViewModel();
                financialOrderDetail.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
                financialOrderDetail.DepartmentName = dtCompanyEarnings.Rows[i]["departName"].ToString();
                financialOrderDetail.ProductName = dtCompanyEarnings.Rows[i]["Name"].ToString();
                financialOrderDetail.OrderAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["TotalAmount"].ToString());
                financialOrderDetail.DepartmentId = int.Parse(dtCompanyEarnings.Rows[i]["departId"].ToString());
                financialOrderDetail.ProductCategoryId = int.Parse(dtCompanyEarnings.Rows[i]["ProductCategoryId"].ToString());
                financialOrderDetail.StoreId = int.Parse(dtCompanyEarnings.Rows[i]["StoreId"].ToString());
                financialOrderDetail.ProductId = int.Parse(dtCompanyEarnings.Rows[i]["ProductId"].ToString());
                financialOrderDetails.Add(financialOrderDetail);
            }
            for (int i = 0; i < dtEmployeesEarnings.Rows.Count; i++)
            {
                var Finan = financialOrderDetails.Where(j => j.DepartmentId == int.Parse(dtEmployeesEarnings.Rows[i]["Id"].ToString()) && j.ProductId == int.Parse(dtEmployeesEarnings.Rows[i]["ProductId"].ToString()) && j.StoreId == int.Parse(dtEmployeesEarnings.Rows[i]["StoreId"].ToString()) && j.ProductCategoryId == int.Parse(dtEmployeesEarnings.Rows[i]["ProductCategoryId"].ToString())).FirstOrDefault();
                if (Finan != null)
                {
                    Finan.OrderToal = int.Parse(dtEmployeesEarnings.Rows[i]["counts"].ToString());
                }
            }
            return financialOrderDetails;
        }
        /// <summary>
        /// 派单超时报表
        /// </summary>
        public List<TimeoutSendOrderViewModel> GetTimeoutSendOrderReport(string filterCompanyEarnings, List<SqlParameter> paramListCompanyEarnings)
        {
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select od.BillNo,st.StoreName,od.StoreId,od.Singlemember," +
                                          "pd.ProductCategoryId,pd.Id as ProductId,dp.Name,dp.Id,dp.Path,od.ProductName," +
                                          "emp.no,od.Singletime,od.StartTime," +
                                          "datediff( minute, od.StartTime, od.Singletime) as time from[Order] as od " +
                                          "left join Store as st  on od.StoreId = st.Id " +
                                          "left join Product as pd  on od.ProductId = pd.Id " +
                                          "left join Department as dp   on od.DepartId = dp.Id " +
                                          "left join Employee as emp on emp.Id = od.Singlemember " +
                                          "where  od.StartTime is not null and od.Singletime is not null and " +
                                          "datediff(minute, od.StartTime, od.Singletime) > 10 {0} order by od.StoreId,od.BillNo Desc", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            List<TimeoutSendOrderViewModel> TimeoutSendOrders = new List<TimeoutSendOrderViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                TimeoutSendOrderViewModel TimeoutSendOrder = new TimeoutSendOrderViewModel();
                TimeoutSendOrder.StoreName = dtCompanyEarnings.Rows[i]["StoreName"].ToString();
                TimeoutSendOrder.DepartmentName = dtCompanyEarnings.Rows[i]["Name"].ToString();
                TimeoutSendOrder.ProductName = dtCompanyEarnings.Rows[i]["ProductName"].ToString();
                TimeoutSendOrder.StoreId = int.Parse(dtCompanyEarnings.Rows[i]["StoreId"].ToString());
                TimeoutSendOrder.ProductId = int.Parse(dtCompanyEarnings.Rows[i]["ProductId"].ToString());
                TimeoutSendOrder.SendOrderMember = dtCompanyEarnings.Rows[i]["no"].ToString();
                TimeoutSendOrder.BillNo = dtCompanyEarnings.Rows[i]["BillNo"].ToString();
                TimeoutSendOrder.AppointmentTime = (DateTime)(dtCompanyEarnings.Rows[i]["StartTime"]);
                TimeoutSendOrder.SendOrderTime = (DateTime)(dtCompanyEarnings.Rows[i]["Singletime"]);
                TimeoutSendOrder.Timeout = double.Parse(dtCompanyEarnings.Rows[i]["time"].ToString());
                TimeoutSendOrders.Add(TimeoutSendOrder);
            }
            return TimeoutSendOrders;
        }
        /// <summary>
        /// 后台充送统计
        /// </summary>
        public List<RechargeViewModel> GetRechargeReport(string filterCompanyEarnings, List<SqlParameter> paramListCompanyEarnings, out decimal TotalAmount, out decimal TotalGivingAmount)
        {
            TotalAmount = 0;
            TotalGivingAmount = 0;
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select mb.Account,pm.PaymentChannel,pm.Amount,pm.GivingAmount," +
                                           "pm.CreateTime,el.No,pm.Id from Payment as pm " +
                                           "left join Member as mb on pm.MemberId = mb.Id " +
                                           "left join Employee as el on el.Id = pm.CreEid " +
                                           "where PaymentStatus = 2 and GivingAmount > 0 {0}", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //处理逻辑
            List<RechargeViewModel> vehicleAchievements = new List<RechargeViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                RechargeViewModel vehicleAchievement = new RechargeViewModel();
                vehicleAchievement.Account = dtCompanyEarnings.Rows[i]["Account"].ToString();
                vehicleAchievement.MethodPayment = (MethodPaymentEnum)((int)dtCompanyEarnings.Rows[i]["PaymentChannel"]);
                vehicleAchievement.Amount = decimal.Parse(dtCompanyEarnings.Rows[i]["Amount"].ToString());
                vehicleAchievement.GivingAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["GivingAmount"].ToString());
                vehicleAchievement.RechargeTime = DateTime.Parse(dtCompanyEarnings.Rows[i]["CreateTime"].ToString());
                vehicleAchievement.RechargePeople = dtCompanyEarnings.Rows[i]["No"].ToString();
                vehicleAchievement.PaymentId = (int)dtCompanyEarnings.Rows[i]["Id"];
                TotalAmount += vehicleAchievement.Amount;
                TotalGivingAmount += vehicleAchievement.GivingAmount;
                vehicleAchievements.Add(vehicleAchievement);
            }
            return vehicleAchievements;
        }
        #endregion

        #region 订单改价 new
        /// <summary>
        /// 订单改价  new 
        /// </summary>
        /// <param name="BillNo"></param>
        public void UpdatePricenew(string BillNo, UserLogInfo uinfo)
        {
            string log = "";
            IRepository<Order> repositoryOrders = DalContext.Repository<Order>();
            Order Orderc = OrderBLL.GetInstance().Table(repositoryOrders).Where(o => o.BillNo == BillNo).FirstOrDefault();
            Orderc.QAmount = 0;
            OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
            if (Orderc.RealTotalAmount < Orderc.Amount)
            {
                var OrderPaylist = OrderPayBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo).ToList();
                decimal sf = OrderPaylist.Where(o => o.TransactionType == Transaction.消费 && o.PayType == PayTypes.账户余额).Select(o => o.PayValue).Sum();
                decimal tk = OrderPaylist.Where(o => o.TransactionType == Transaction.退款).Select(o => o.PayValue).Sum();
                decimal Amount = sf - tk;
                if (Orderc.IsDao == true)
                {
                    if (Orderc.SYHQAmount.HasValue && Orderc.SYHQAmount.Value > 0)
                    {
                        Amount = Orderc.Amount - Orderc.SYHQAmount.Value;
                    }
                    else
                    {
                        Amount = Orderc.Amount;
                    }
                }

                if ((Orderc.Amount - Orderc.RealTotalAmount) <= Amount)
                {
                    IRepository<OrderPay> repositoryOrderPay = DalContext.Repository<OrderPay>();
                    var OrderPayc = OrderPayBLL.GetInstance().Table(repositoryOrderPay).Where(o => o.BillNo == BillNo && o.PayType == PayTypes.优惠券).FirstOrDefault();
                    if (OrderPayc != null)
                    {
                        decimal t1 = 0;
                        decimal t2 = 0;

                        log += "优惠券抵扣面值:";
                        log += "￥" + OrderPayc.PayValue + "改成￥";
                        t1 = OrderPayc.PayValue;
                        if (Orderc.RealTotalAmount <= OrderPayc.FaceValue)
                        {
                            OrderPayc.PayValue = Orderc.RealTotalAmount;
                            Orderc.QAmount = Amount;
                            Orderc.Amount = Amount + Orderc.RealTotalAmount;
                        }
                        else
                        {
                            OrderPayc.PayValue = ZConvert.StrToDecimal(OrderPayc.FaceValue);
                            Orderc.QAmount = Orderc.Amount - Orderc.RealTotalAmount;
                            Orderc.Amount = ZConvert.StrToDecimal(Orderc.QAmount) + Orderc.RealTotalAmount;
                        }

                        log += OrderPayc.PayValue;
                        t2 = OrderPayc.PayValue;
                        if (t1 == t2)
                        {
                            log = "";
                        }
                        OrderPayBLL.GetInstance().Update(OrderPayc, repositoryOrderPay);

                        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                    }
                    else
                    {
                        Orderc.QAmount = (Orderc.Amount - Orderc.RealTotalAmount);
                        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                    }




                }
                else
                {
                    IRepository<OrderPay> repositoryOrderPay = DalContext.Repository<OrderPay>();
                    var OrderPayc = OrderPayBLL.GetInstance().Table(repositoryOrderPay).Where(o => o.BillNo == BillNo && o.PayType == PayTypes.优惠券).FirstOrDefault();
                    if (OrderPayc != null)
                    {
                        decimal t1 = 0;
                        decimal t2 = 0;

                        log += "优惠券抵扣面值:";
                        log += "￥" + OrderPayc.PayValue + "改成￥";
                        t1 = OrderPayc.PayValue;
                        OrderPayc.PayValue = OrderPayc.PayValue - ((Orderc.Amount - Orderc.RealTotalAmount) - Amount);
                        log += OrderPayc.PayValue;
                        t2 = OrderPayc.PayValue;
                        if (t1 == t2)
                        {
                            log = "";
                        }
                        OrderPayBLL.GetInstance().Update(OrderPayc, repositoryOrderPay);
                    }


                    if (Orderc.IsDao == true)
                    {
                        if (Orderc.SYHQAmount.HasValue && Orderc.SYHQAmount.Value > 0)
                        {
                            Orderc.SYHQAmount = Orderc.SYHQAmount - ((Orderc.Amount - Orderc.RealTotalAmount) - Amount);
                            if (Orderc.SYHQAmount < 0)
                            {
                                Orderc.SYHQAmount = 0;
                            }
                        }
                    }



                    Orderc.Amount = Orderc.Amount - ((Orderc.Amount - Orderc.RealTotalAmount) - Amount);
                    Orderc.QAmount = Amount;






                    OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                }
            }
            else if (Orderc.RealTotalAmount > Orderc.Amount)
            {
                IRepository<OrderPay> repositoryOrderPay = DalContext.Repository<OrderPay>();
                var OrderPayc = OrderPayBLL.GetInstance().Table(repositoryOrderPay).Where(o => o.BillNo == BillNo && o.PayType == PayTypes.优惠券).FirstOrDefault();
                if (OrderPayc != null)
                {
                    if ((Orderc.RealTotalAmount - Orderc.Amount) <= (ZConvert.StrToDecimal(OrderPayc.FaceValue) - OrderPayc.PayValue))
                    {
                        decimal t1 = 0;
                        decimal t2 = 0;
                        log += "优惠券抵扣面值:";
                        log += "￥" + OrderPayc.PayValue + "改成￥";
                        t1 = OrderPayc.PayValue;
                        OrderPayc.PayValue = OrderPayc.PayValue + (Orderc.RealTotalAmount - Orderc.Amount);
                        log += OrderPayc.PayValue;
                        t2 = OrderPayc.PayValue;
                        if (t1 == t2)
                        {
                            log = "";
                        }
                        OrderPayBLL.GetInstance().Update(OrderPayc, repositoryOrderPay);
                        Orderc.Amount = Orderc.Amount + (Orderc.RealTotalAmount - Orderc.Amount);
                        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                    }
                    else
                    {
                        Orderc.Amount = Orderc.Amount + (ZConvert.StrToDecimal(OrderPayc.FaceValue) - OrderPayc.PayValue);
                        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                        decimal t1 = 0;
                        decimal t2 = 0;
                        log += "优惠券抵扣面值:";
                        log += "￥" + OrderPayc.PayValue + "改成￥";
                        t1 = OrderPayc.PayValue;
                        OrderPayc.PayValue = ZConvert.StrToDecimal(OrderPayc.FaceValue);
                        log += OrderPayc.PayValue;
                        t2 = OrderPayc.PayValue;
                        if (t1 == t2)
                        {
                            log = "";
                        }
                        OrderPayBLL.GetInstance().Update(OrderPayc, repositoryOrderPay);
                    }
                }
            }
            if (!string.IsNullOrEmpty(log))
            {
                OrderOperationLogBLL.GetInstance().CustomLog(uinfo, BillNo, "修改订单", log);
            }


            //if (Orderc.IsDao == true)
            //{
            //    if (Orderc.SYHQAmount.HasValue && Orderc.SYHQAmount.Value > 0)
            //    {
            //        Amount = Orderc.Amount - Orderc.SYHQAmount.Value;
            //        Orderc.SYHQAmount = Orderc.Amount + Orderc.QAmount;
            //        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);

            //    }

            //}

            UpdateSYHQAmount(BillNo);



        }


        public void UpdatePricenewbak(string BillNo, UserLogInfo uinfo)
        {
            string log = "";
            IRepository<Order> repositoryOrders = DalContext.Repository<Order>();
            Order Orderc = OrderBLL.GetInstance().Table(repositoryOrders).Where(o => o.BillNo == BillNo).FirstOrDefault();
            Orderc.QAmount = 0;
            OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
            if (Orderc.RealTotalAmount < Orderc.Amount)
            {
                var OrderPaylist = OrderPayBLL.GetInstance().TableNoTracking().Where(o => o.BillNo == BillNo).ToList();
                decimal sf = OrderPaylist.Where(o => o.TransactionType == Transaction.消费 && o.PayType == PayTypes.账户余额).Select(o => o.PayValue).Sum();
                decimal tk = OrderPaylist.Where(o => o.TransactionType == Transaction.退款).Select(o => o.PayValue).Sum();
                decimal Amount = sf - tk;
                if ((Orderc.Amount - Orderc.RealTotalAmount) <= Amount)
                {
                    IRepository<OrderPay> repositoryOrderPay = DalContext.Repository<OrderPay>();
                    var OrderPayc = OrderPayBLL.GetInstance().Table(repositoryOrderPay).Where(o => o.BillNo == BillNo && o.PayType == PayTypes.优惠券).FirstOrDefault();
                    if (OrderPayc != null)
                    {
                        decimal t1 = 0;
                        decimal t2 = 0;

                        log += "优惠券抵扣面值:";
                        log += "￥" + OrderPayc.PayValue + "改成￥";
                        t1 = OrderPayc.PayValue;
                        if (Orderc.RealTotalAmount <= OrderPayc.FaceValue)
                        {
                            OrderPayc.PayValue = Orderc.RealTotalAmount;
                            Orderc.QAmount = Amount;
                            Orderc.Amount = Amount + Orderc.RealTotalAmount;
                        }
                        else
                        {
                            OrderPayc.PayValue = ZConvert.StrToDecimal(OrderPayc.FaceValue);
                            Orderc.QAmount = Orderc.Amount - Orderc.RealTotalAmount;
                            Orderc.Amount = ZConvert.StrToDecimal(Orderc.QAmount) + Orderc.RealTotalAmount;
                        }

                        log += OrderPayc.PayValue;
                        t2 = OrderPayc.PayValue;
                        if (t1 == t2)
                        {
                            log = "";
                        }
                        OrderPayBLL.GetInstance().Update(OrderPayc, repositoryOrderPay);
                        //Orderc.QAmount = Amount  (Orderc.Amount - Orderc.RealTotalAmount) - OrderPayc.PayValue;

                        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                    }
                    else
                    {
                        Orderc.QAmount = (Orderc.Amount - Orderc.RealTotalAmount);
                        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                    }




                }
                else
                {
                    IRepository<OrderPay> repositoryOrderPay = DalContext.Repository<OrderPay>();
                    var OrderPayc = OrderPayBLL.GetInstance().Table(repositoryOrderPay).Where(o => o.BillNo == BillNo && o.PayType == PayTypes.优惠券).FirstOrDefault();
                    if (OrderPayc != null)
                    {
                        decimal t1 = 0;
                        decimal t2 = 0;

                        log += "优惠券抵扣面值:";
                        log += "￥" + OrderPayc.PayValue + "改成￥";
                        t1 = OrderPayc.PayValue;
                        OrderPayc.PayValue = OrderPayc.PayValue - ((Orderc.Amount - Orderc.RealTotalAmount) - Amount);
                        log += OrderPayc.PayValue;
                        t2 = OrderPayc.PayValue;
                        if (t1 == t2)
                        {
                            log = "";
                        }
                        OrderPayBLL.GetInstance().Update(OrderPayc, repositoryOrderPay);
                    }
                    Orderc.Amount = Orderc.Amount - ((Orderc.Amount - Orderc.RealTotalAmount) - Amount);
                    Orderc.QAmount = Amount;
                    OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                }
            }
            else if (Orderc.RealTotalAmount > Orderc.Amount)
            {
                IRepository<OrderPay> repositoryOrderPay = DalContext.Repository<OrderPay>();
                var OrderPayc = OrderPayBLL.GetInstance().Table(repositoryOrderPay).Where(o => o.BillNo == BillNo && o.PayType == PayTypes.优惠券).FirstOrDefault();
                if (OrderPayc != null)
                {
                    if ((Orderc.RealTotalAmount - Orderc.Amount) <= (ZConvert.StrToDecimal(OrderPayc.FaceValue) - OrderPayc.PayValue))
                    {
                        decimal t1 = 0;
                        decimal t2 = 0;
                        log += "优惠券抵扣面值:";
                        log += "￥" + OrderPayc.PayValue + "改成￥";
                        t1 = OrderPayc.PayValue;
                        OrderPayc.PayValue = OrderPayc.PayValue + (Orderc.RealTotalAmount - Orderc.Amount);
                        log += OrderPayc.PayValue;
                        t2 = OrderPayc.PayValue;
                        if (t1 == t2)
                        {
                            log = "";
                        }
                        OrderPayBLL.GetInstance().Update(OrderPayc, repositoryOrderPay);
                        Orderc.Amount = Orderc.Amount + (Orderc.RealTotalAmount - Orderc.Amount);
                        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                    }
                    else
                    {
                        Orderc.Amount = Orderc.Amount + (ZConvert.StrToDecimal(OrderPayc.FaceValue) - OrderPayc.PayValue);
                        OrderBLL.GetInstance().Update(Orderc, repositoryOrders);
                        decimal t1 = 0;
                        decimal t2 = 0;
                        log += "优惠券抵扣面值:";
                        log += "￥" + OrderPayc.PayValue + "改成￥";
                        t1 = OrderPayc.PayValue;
                        OrderPayc.PayValue = ZConvert.StrToDecimal(OrderPayc.FaceValue);
                        log += OrderPayc.PayValue;
                        t2 = OrderPayc.PayValue;
                        if (t1 == t2)
                        {
                            log = "";
                        }
                        OrderPayBLL.GetInstance().Update(OrderPayc, repositoryOrderPay);
                    }
                }
            }
            if (!string.IsNullOrEmpty(log))
            {
                OrderOperationLogBLL.GetInstance().CustomLog(uinfo, BillNo, "修改订单", log);
            }




        }
        #endregion

        #region 取消订单
        /// <summary>
        /// 取消订单
        /// </summary>
        public List<OrderCancelViewModel> GetOrderCancelReport(string filterCompanyEarnings)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select st.StoreName,st.Id as StoreId,pd.ProductCategoryId," +
                                           "pd.Id as ProductId,pd.Name,orc.Promoter,COUNT(*) as num from [Order] as od " +
                                           "left join OrderRejectCancel orc on orc.BillNo = od.BillNo " +
                                           "left join Store as st  on od.StoreId = st.Id " +
                                           "left join Product as pd on od.ProductId = pd.Id " +
                                           "where orc.OrderState = 99  and od.OrderState = 99 {0} " +
                                           "group by  od.ProductId, orc.Promoter, st.StoreName, st.Id," +
                                           "pd.ProductCategoryId, pd.Id, pd.Name ", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable OrderCanceltb = SqlQueryForDataTatable(sqlCompanyEarnings, paramList);
            List<OrderCancelViewModel> OrderCancels = new List<OrderCancelViewModel>();
            for (int i = 0; i < OrderCanceltb.Rows.Count; i++)
            {
                OrderCancelViewModel OrderCancel = new OrderCancelViewModel();
                OrderCancel.ProductId = int.Parse(OrderCanceltb.Rows[i]["ProductId"].ToString());
                OrderCancel.ProductCateogryId = int.Parse(OrderCanceltb.Rows[i]["ProductCategoryId"].ToString());
                OrderCancel.StoreId = int.Parse(OrderCanceltb.Rows[i]["StoreId"].ToString());
                OrderCancel.StoreName = OrderCanceltb.Rows[i]["StoreName"].ToString();
                OrderCancel.ProductName = OrderCanceltb.Rows[i]["Name"].ToString();
                OrderCancel.why = (OrdechangeEnum)(int.Parse((OrderCanceltb.Rows[i]["Promoter"].ToString())));
                OrderCancel.Number = int.Parse(OrderCanceltb.Rows[i]["num"].ToString());
                OrderCancels.Add(OrderCancel);
            }
            return OrderCancels;
        }
        #endregion

        #region 取消订单明细
        /// <summary>
        /// 取消订单明细
        /// </summary>
        public List<OrderCancelDetailViewModel> GetOrderCancelDetailReport(string filterCompanyEarnings, List<SqlParameter> paramListCompanyEarnings)
        {
            //查询统计
            StringBuilder sbCompanyEarnings = new StringBuilder();
            sbCompanyEarnings.AppendFormat("select st.StoreName,st.Id as storeid,od.StartTime as fwtime," +
                                           "od.ProductId,od.IsGroup,od.ProductName,od.BillNo,orc.CreateTime,orc.Remark," +
                                           "orc.OpId,orc.OpType,orc.Promoter,od.RealTotalAmount,orc.Amount," +
                                           "stuff((select ','+convert(varchar(10),ServiceNo) from OrderCacelItem" +
                                           " where BillNo = od.BillNo " +
                                           "for xml path('')),1,1,'') as Emploes " +
                                           "from[Order] as od " +
                                           "left join Store as st  on od.StoreId = st.Id " +
                                           "left join OrderRejectCancel as orc on orc.BillNo = od.BillNo " +
                                           "where od.OrderState = 99 and orc.OrderState = 99 {0} " +
                                           "group by st.StoreName,od.IsGroup,st.Id,od.ProductId,od.ProductName," +
                                           "od.BillNo,orc.CreateTime,orc.Remark,orc.OpId,orc.OpType," +
                                           "od.StartTime,orc.Promoter,od.RealTotalAmount,orc.Amount", filterCompanyEarnings);
            string sqlCompanyEarnings = sbCompanyEarnings.ToString();
            DataTable dtCompanyEarnings = SqlQueryForDataTatable(sqlCompanyEarnings, paramListCompanyEarnings);
            //模型赋值
            List<OrderCancelDetailViewModel> OrderCancelDetails = new List<OrderCancelDetailViewModel>();
            for (int i = 0; i < dtCompanyEarnings.Rows.Count; i++)
            {
                OrderCancelDetailViewModel OrderCancelDetail = new OrderCancelDetailViewModel();
                OrderCancelDetail.BillNo = dtCompanyEarnings.Rows[i]["BillNo"].ToString();
                OrderCancelDetail.CancelPeople = dtCompanyEarnings.Rows[i]["OpId"].ToString();
                OrderCancelDetail.CancelTime = DateTime.Parse(dtCompanyEarnings.Rows[i]["CreateTime"].ToString());
                OrderCancelDetail.ServiceTime = DateTime.Parse(dtCompanyEarnings.Rows[i]["fwtime"].ToString());
                OrderCancelDetail.ServiceEmployees = dtCompanyEarnings.Rows[i]["Emploes"].ToString();
                OrderCancelDetail.Remarks = dtCompanyEarnings.Rows[i]["Remark"].ToString();
                OrderCancelDetail.OrderAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["RealTotalAmount"].ToString());
                OrderCancelDetail.DeductionsAmount = decimal.Parse(dtCompanyEarnings.Rows[i]["Amount"].ToString());
                OrderCancelDetail.OpType = dtCompanyEarnings.Rows[i]["OpType"].ToString();
                OrderCancelDetail.IsGroup = (bool)(dtCompanyEarnings.Rows[i]["IsGroup"]);
                OrderCancelDetails.Add(OrderCancelDetail);
            }
            return OrderCancelDetails;
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <returns></returns>
        public static List<string> GetEmployeeNo(string OrderNo)
        {
            List<string> ecodes = new List<string>();

            ReadOnlyRepository onlyRead = new ReadOnlyRepository();
            var scs = onlyRead.Fetch<dynamic>("select ServiceNo,CarCode from OrderWaiter where BillNo=@0 and IsFlag=1", OrderNo);
            foreach (var ow in scs)
            {
                if (string.IsNullOrWhiteSpace(ow.CarCode))
                    ecodes.Add(ow.ServiceNo);
                else
                    ecodes.Add(ow.CarCode);
            }
            ecodes = ecodes.Distinct().ToList();

            return ecodes;
        }

        public static void CancelOrderWxMsg(string OrderNo, DateTime? sdt,List<string> eNOs)
        {
            ReadOnlyRepository onlyRead = new ReadOnlyRepository();

            if (eNOs.Count == 0)
            {
                NLogger.Error($"{OrderNo} 员工为空", "CancelOrder");
                return;
            }

            //获取员工微信企业帐号
            List<string> wxuids = onlyRead.Fetch<string>("select UserId from EmployeeBind eb join Employee e on eb.EmployeeId=e.Id where [NO] in (@0)", eNOs);
            if (wxuids.Count == 0)
            {
                NLogger.Error($"{OrderNo} 员工绑定微信为空", "CancelOrder");
                return;
            }

            var oa = onlyRead.FirstOrDefault<dynamic>("select CityId,AreaId,Street from OrderAddr where BillNo=@0", OrderNo);
            List<int> cids = new List<int>();
            cids.Add(oa.CityId);
            cids.Add(oa.AreaId);
            var cns = onlyRead.Fetch<dynamic>("select Id,Name from CityArea where Id in (@0)", cids);
            string cn = cns.FirstOrDefault(o => o.Id == oa.CityId)?.Name;
            string an = cns.FirstOrDefault(o => o.Id == oa.AreaId)?.Name;

            if (!sdt.HasValue)
                sdt = onlyRead.FirstOrDefault<dynamic>("select StartTime from [Order] where BillNo=@0", OrderNo)?.StartTime;

            MessageInterface.CancelOrderWxMsg(wxuids, OrderNo, sdt.Value.ToString("yyyy/MM/dd HH:mm"), $" {cn} {an} {oa.Street} ");
        }


        public static void DispatchWxMsg(string OrderNo, DateTime? sdt)
        {

            List<string> ecodes = new List<string>();

            ReadOnlyRepository onlyRead = new ReadOnlyRepository();
            var scs = onlyRead.Fetch<dynamic>("select ServiceNo,CarCode from OrderWaiter where BillNo=@0 and IsFlag=1", OrderNo);
            foreach (var ow in scs)
            {
                if (string.IsNullOrWhiteSpace(ow.CarCode))
                    ecodes.Add(ow.ServiceNo);
                else
                    ecodes.Add(ow.CarCode);
            }
            ecodes = ecodes.Distinct().ToList();
            if (ecodes.Count == 0)
            {
                NLogger.Error($"{OrderNo} 员工为空", "Dispatch");
                return;
            }

            //获取员工微信企业帐号
            List<string> wxuids = onlyRead.Fetch<string>("select UserId from EmployeeBind eb join Employee e on eb.EmployeeId=e.Id where [NO] in (@0)", ecodes);
            if (wxuids.Count == 0)
            {
                NLogger.Error($"{OrderNo} 员工绑定微信为空", "Dispatch");
                return;
            }

            var oa = onlyRead.FirstOrDefault<dynamic>("select CityId,AreaId,Street from OrderAddr where BillNo=@0", OrderNo);
            List<int> cids = new List<int>();
            cids.Add(oa.CityId);
            cids.Add(oa.AreaId);
            var cns = onlyRead.Fetch<dynamic>("select Id,Name from CityArea where Id in (@0)", cids);
            string cn = cns.FirstOrDefault(o => o.Id == oa.CityId)?.Name;
            string an = cns.FirstOrDefault(o => o.Id == oa.AreaId)?.Name;

            if (!sdt.HasValue)
                sdt = onlyRead.FirstOrDefault<dynamic>("select StartTime from [Order] where BillNo=@0", OrderNo)?.StartTime;

            MessageInterface.DispatchWxMsg(wxuids, OrderNo, sdt.Value.ToString("yyyy/MM/dd HH:mm"), $" {cn} {an} {oa.Street} ");

        }
    }
}