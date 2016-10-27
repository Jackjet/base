/****************************************************** 

    文件名称：
    功能描述：库存设置
    作    者：coanan
    日    期：2016.06.02
    修改记录：

*******************************************************/
using Conan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Conan.Core;
using Conan.Utils;
using Conan.Model.Enum;

namespace Conan.BLL
{
    /// <summary>
    /// 库存设置
    /// </summary>
    public class InventoryOverBLL : BaseBll<InventoryOver>
    {
        #region 构造函数
        private static InventoryOverBLL instance;
        public static InventoryOverBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new InventoryOverBLL();
            }
            return instance;
        }
        #endregion

        #region 添加溢出值
        /// <summary>
        /// 添加溢出值
        /// </summary>
        public void AddInventoryOver()
        {
            int Stockdate = ZConvert.StrToInt(ZConfig.GetConfigString("Stockdate"));


            DateTime Time = DateTime.Now;
            for (int z = 0; z < Stockdate; z++)
            {
                int t = z == 0 ? 0 : 1;
                Time = Time.AddDays(t);
                var InventoryHistory = InventoryOverHistoryBLL.GetInstance().TableNoTracking().Where(o => o.CreTime == Time.Date).FirstOrDefault();
                if (InventoryHistory == null)
                {
                    // 添加记录
                    InventoryOverHistory obj = new InventoryOverHistory();
                    obj.CreTime = Time.Date;
                    InventoryOverHistoryBLL.GetInstance().Add(obj);
                    var store = StoreBll.GetInstance().TableNoTracking().Where(o => o.State == (int)StoreState.上线中).ToList();
                    var ProductCategory = ProductCategoryBll.GetInstance().TableNoTracking().ToList();
                    var ProductCategoryidlist = ProductCategory.Select(o => o.Id).ToList();
                    ProductCategoryidlist.Add(0);

                    var Productlist = ProductBll.GetInstance().TableNoTracking().Where(o => ProductCategoryidlist.Contains(o.ProductCategoryId) && o.State == ProductStateEnum.上架).ToList();
                    var Productidlist = Productlist.Select(o => o.Id).ToList();
                    Productidlist.Add(0);
                    var StockSettinglist = StockSettingBLL.GetInstance().TableNoTracking().Where(o => Productidlist.Contains(o.ProductId)).ToList();

                    if (store != null && store.Count > 0)
                    {
                        foreach (var itemstore in store)
                        {
                            if (ProductCategory != null && ProductCategory.Count > 0)
                            {
                                foreach (var itemProductCategory in ProductCategory)
                                {
                                    #region MyRegion
                                    ////    //店铺   分类下  当天的总库存
                                    List<StockOutInView> StockOutInViewlist = InventoryBLL.GetInstance().GetStockTotal(itemstore.Id, itemProductCategory.Id, Time);

                                    List<Product> ProductList = Productlist.Where(o => o.ProductCategoryId == itemProductCategory.Id).ToList();
                                    if (ProductList != null)
                                    {
                                        foreach (var item in ProductList)
                                        {
                                            string sql = "  INSERT INTO [InventoryOver]  ([StoreId]   ,[ProductId]    ,[CreTime]   ";
                                            sql += "      ,[Time1] ,[Time2]  ,[Time3]  ,[Time4]  ,[Time5]   ,[Time6]   ,[Time7]  ,[Time8]  ,[Time9]  ,[Time10]  ,[Time11] ,[Time12]  ,[Time13]  ,[Time14] ,[Time15]  ";
                                            sql += "       ,[Time16]   ,[Time17]   ,[Time18]   ,[Time19]   ,[Time20]   ,[Time21]    ,[Time22]    ,[Time23]  ";
                                            sql += "       ,[Time24]  ,[Time25]   ,[Time26]  ,[Time27]   ,[Time28] ,[Time29] ,[Time30]  ,[Time31]    ,[Time32]  ,[Time33]  ";
                                            sql += "        ,[Time34]  ,[Time35]  ,[Time36]  ,[Time37]    ,[Time38]   ,[Time39]    ,[Time40]  ,[Time41]  ,[Time42] ,[Time43]   ,[Time44] ,[Time45]  ,[Time46]  ,[Time47] ,[Time48]  ";
                                            sql += "        )  ";
                                            sql += "      VALUES  ";
                                            sql += "         (" + itemstore.Id + "," + item.Id + ",'" + Time.Date + "'  ";
                                            int i = 1;
                                            #region 循环

                                            while (i < 49)
                                            {

                                                //分类下
                                                var EmployeeProductViewModellistitem = new List<StockOutInView>();


                                                #region MyRegion
                                                if (i == 1)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time1 != null).ToList();

                                                }
                                                else
                                                   if (i == 2)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time2 != null).ToList();

                                                }
                                                else
                                                   if (i == 3)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time3 != null).ToList();

                                                }

                                                else
                                                   if (i == 4)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time4 != null).ToList();

                                                }

                                                else
                                                   if (i == 5)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time5 != null).ToList();

                                                }

                                                else
                                                   if (i == 6)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time6 != null).ToList();

                                                }
                                                else
                                                   if (i == 7)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time7 != null).ToList();

                                                }
                                                else
                                                   if (i == 8)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time8 != null).ToList();

                                                }


                                                else
                                                   if (i == 9)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time9 != null).ToList();

                                                }


                                                else
                                                   if (i == 10)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time10 != null).ToList();

                                                }


                                                else
                                                   if (i == 11)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time11 != null).ToList();

                                                }

                                                else
                                                   if (i == 12)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time12 != null).ToList();

                                                }


                                                else
                                                   if (i == 13)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time13 != null).ToList();

                                                }



                                                else
                                                   if (i == 14)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time14 != null).ToList();

                                                }


                                                else
                                                   if (i == 15)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time15 != null).ToList();

                                                }


                                                else
                                                   if (i == 16)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time16 != null).ToList();

                                                }

                                                else
                                                   if (i == 17)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time17 != null).ToList();

                                                }

                                                else
                                                   if (i == 18)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time18 != null).ToList();

                                                }

                                                else
                                                   if (i == 19)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time19 != null).ToList();

                                                }

                                                else
                                                   if (i == 20)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time20 != null).ToList();

                                                }

                                                else
                                                   if (i == 21)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time21 != null).ToList();

                                                }


                                                else
                                                   if (i == 22)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time22 != null).ToList();

                                                }


                                                else
                                                   if (i == 23)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time23 != null).ToList();

                                                }

                                                else
                                                   if (i == 24)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time24 != null).ToList();

                                                }


                                                else
                                                   if (i == 25)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time25 != null).ToList();

                                                }


                                                else
                                                   if (i == 26)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time26 != null).ToList();

                                                }

                                                else
                                                   if (i == 27)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time27 != null).ToList();

                                                }



                                                else
                                                   if (i == 28)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time28 != null).ToList();

                                                }


                                                else
                                                   if (i == 29)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time29 != null).ToList();

                                                }

                                                else
                                                   if (i == 30)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time30 != null).ToList();

                                                }


                                                else
                                                   if (i == 31)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time31 != null).ToList();

                                                }



                                                else
                                                   if (i == 32)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time32 != null).ToList();

                                                }


                                                else
                                                   if (i == 33)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time33 != null).ToList();

                                                }

                                                else
                                                   if (i == 34)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time34 != null).ToList();

                                                }

                                                else
                                                   if (i == 35)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time35 != null).ToList();

                                                }

                                                else
                                                   if (i == 36)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time36 != null).ToList();

                                                }


                                                else
                                                   if (i == 37)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time37 != null).ToList();

                                                }
                                                else
                                                   if (i == 38)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time38 != null).ToList();

                                                }
                                                else
                                                   if (i == 39)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time39 != null).ToList();

                                                }
                                                else
                                                   if (i == 40)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time40 != null).ToList();

                                                }

                                                else
                                                   if (i == 41)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time41 != null).ToList();

                                                }

                                                else
                                                   if (i == 42)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time42 != null).ToList();

                                                }
                                                else
                                                   if (i == 43)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time43 != null).ToList();

                                                }
                                                else
                                                   if (i == 44)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time44 != null).ToList();

                                                }

                                                else
                                                   if (i == 45)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time45 != null).ToList();

                                                }


                                                else
                                                   if (i == 46)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time46 != null).ToList();

                                                }

                                                else
                                                   if (i == 47)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time47 != null).ToList();

                                                }

                                                else
                                                   if (i == 48)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time48 != null).ToList();

                                                }





                                                #endregion


                                                //产品下的总库存
                                                int TotalInventory = EmployeeProductViewModellistitem.Select(o => o.EmployeeId).Distinct().Count();


                                                //百分比计算

                                                var StockSetting = StockSettinglist.Where(o => o.ProductId == item.Id).FirstOrDefault();
                                                if (StockSetting != null)
                                                {


                                                    TotalInventory = ZConvert.StrToInt(TotalInventory * ((StockSetting.OverflowValue - 100) / 100));
                                                }
                                                else
                                                {
                                                    TotalInventory = 0;
                                                }









                                                sql += "  ," + TotalInventory + " ";




                                                i++;
                                            }
                                            #endregion

                                            sql += "   )";

                                            ExecuteSqlCommand(sql, null);



                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region 添加溢出值  后台修改 比例
        /// <summary>
        /// 添加溢出值   后台修改 比例
        /// </summary>
        /// <param name="ProductId"></param>
        public void UpdateInventoryOver(object oid)
        {

            int ProductId = (int)oid;
            DateTime dt = DateTime.Now.Date;
            var InventoryHistory = InventoryOverHistoryBLL.GetInstance().TableNoTracking().Where(o => o.CreTime >= dt).ToList();
            var store = StoreBll.GetInstance().TableNoTracking().Where(o => o.State == (int)StoreState.上线中).ToList();
            var ProductCategory = ProductCategoryBll.GetInstance().TableNoTracking().ToList();
            var ProductCategoryidlist = ProductCategory.Select(o => o.Id).ToList();
            ProductCategoryidlist.Add(0);
            var Productlist = ProductBll.GetInstance().TableNoTracking().Where(o => o.Id == ProductId && o.State == ProductStateEnum.上架).ToList();
            var Productidlist = Productlist.Select(o => o.Id).ToList();
            Productidlist.Add(0);
            var StockSettinglist = StockSettingBLL.GetInstance().TableNoTracking().Where(o => Productidlist.Contains(o.ProductId)).ToList();
            if (store != null && store.Count > 0)
            {
                foreach (var itemstore in store)
                {
                    if (ProductCategory != null && ProductCategory.Count > 0)
                    {
                        foreach (var itemProductCategory in ProductCategory)
                        {
                            if (InventoryHistory != null && InventoryHistory.Count > 0)
                            {
                                foreach (var objInventoryHistory in InventoryHistory)
                                {
                                    ////    //店铺   分类下  当天的总库存
                                    List<StockOutInView> StockOutInViewlist = InventoryBLL.GetInstance().GetStockTotal(itemstore.Id, itemProductCategory.Id, objInventoryHistory.CreTime);
                                    List<Product> ProductList = Productlist.Where(o => o.ProductCategoryId == itemProductCategory.Id).ToList();
                                    #region MyRegion
                                    if (ProductList != null)
                                    {
                                        foreach (var item in ProductList)
                                        {
                                            string sql = " update  [InventoryOver] set     ";
                                            int i = 1;
                                            #region 循环
                                            string tstr = "";
                                            while (i < 49)
                                            {
                                                //分类下
                                                var EmployeeProductViewModellistitem = new List<StockOutInView>();
                                                #region MyRegion
                                                if (i == 1)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time1 != null).ToList();

                                                }
                                                else
                                                   if (i == 2)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time2 != null).ToList();

                                                }
                                                else
                                                   if (i == 3)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time3 != null).ToList();

                                                }

                                                else
                                                   if (i == 4)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time4 != null).ToList();

                                                }

                                                else
                                                   if (i == 5)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time5 != null).ToList();

                                                }

                                                else
                                                   if (i == 6)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time6 != null).ToList();

                                                }
                                                else
                                                   if (i == 7)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time7 != null).ToList();

                                                }
                                                else
                                                   if (i == 8)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time8 != null).ToList();

                                                }


                                                else
                                                   if (i == 9)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time9 != null).ToList();

                                                }


                                                else
                                                   if (i == 10)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time10 != null).ToList();

                                                }


                                                else
                                                   if (i == 11)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time11 != null).ToList();

                                                }

                                                else
                                                   if (i == 12)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time12 != null).ToList();

                                                }


                                                else
                                                   if (i == 13)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time13 != null).ToList();

                                                }



                                                else
                                                   if (i == 14)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time14 != null).ToList();

                                                }


                                                else
                                                   if (i == 15)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time15 != null).ToList();

                                                }


                                                else
                                                   if (i == 16)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time16 != null).ToList();

                                                }

                                                else
                                                   if (i == 17)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time17 != null).ToList();

                                                }

                                                else
                                                   if (i == 18)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time18 != null).ToList();

                                                }

                                                else
                                                   if (i == 19)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time19 != null).ToList();

                                                }

                                                else
                                                   if (i == 20)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time20 != null).ToList();

                                                }

                                                else
                                                   if (i == 21)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time21 != null).ToList();

                                                }


                                                else
                                                   if (i == 22)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time22 != null).ToList();

                                                }


                                                else
                                                   if (i == 23)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time23 != null).ToList();

                                                }

                                                else
                                                   if (i == 24)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time24 != null).ToList();

                                                }


                                                else
                                                   if (i == 25)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time25 != null).ToList();

                                                }


                                                else
                                                   if (i == 26)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time26 != null).ToList();

                                                }

                                                else
                                                   if (i == 27)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time27 != null).ToList();

                                                }



                                                else
                                                   if (i == 28)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time28 != null).ToList();

                                                }


                                                else
                                                   if (i == 29)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time29 != null).ToList();

                                                }

                                                else
                                                   if (i == 30)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time30 != null).ToList();

                                                }


                                                else
                                                   if (i == 31)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time31 != null).ToList();

                                                }



                                                else
                                                   if (i == 32)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time32 != null).ToList();

                                                }


                                                else
                                                   if (i == 33)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time33 != null).ToList();

                                                }

                                                else
                                                   if (i == 34)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time34 != null).ToList();

                                                }

                                                else
                                                   if (i == 35)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time35 != null).ToList();

                                                }

                                                else
                                                   if (i == 36)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time36 != null).ToList();

                                                }


                                                else
                                                   if (i == 37)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time37 != null).ToList();

                                                }
                                                else
                                                   if (i == 38)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time38 != null).ToList();

                                                }
                                                else
                                                   if (i == 39)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time39 != null).ToList();

                                                }
                                                else
                                                   if (i == 40)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time40 != null).ToList();

                                                }

                                                else
                                                   if (i == 41)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time41 != null).ToList();

                                                }

                                                else
                                                   if (i == 42)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time42 != null).ToList();

                                                }
                                                else
                                                   if (i == 43)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time43 != null).ToList();

                                                }
                                                else
                                                   if (i == 44)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time44 != null).ToList();

                                                }

                                                else
                                                   if (i == 45)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time45 != null).ToList();

                                                }


                                                else
                                                   if (i == 46)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time46 != null).ToList();

                                                }

                                                else
                                                   if (i == 47)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time47 != null).ToList();

                                                }

                                                else
                                                   if (i == 48)
                                                {
                                                    EmployeeProductViewModellistitem = StockOutInViewlist.Where(o => o.PrdouctId == item.Id && o.Time48 != null).ToList();

                                                }
                                                #endregion
                                                //产品下的总库存
                                                int TotalInventory = EmployeeProductViewModellistitem.Select(o => o.EmployeeId).Distinct().Count();
                                                //百分比计算
                                                var StockSetting = StockSettinglist.Where(o => o.ProductId == item.Id).FirstOrDefault();
                                                if (StockSetting != null)
                                                {
                                                    TotalInventory = ZConvert.StrToInt(TotalInventory * ((StockSetting.OverflowValue - 100) / 100));
                                                }
                                                else
                                                {
                                                    TotalInventory = 0;
                                                }

                                                tstr += "    [Time" + i + "]=" + TotalInventory + ",";

                                                i++;
                                            }
                                            #endregion


                                            if (!string.IsNullOrEmpty(tstr))
                                            {
                                                tstr = tstr.Substring(0, tstr.Length - 1);
                                            }
                                            sql += tstr;
                                            sql += "  where  [StoreId]=" + itemstore.Id + " and  [ProductId]=" + item.Id + " and  [CreTime]='" + objInventoryHistory.CreTime.Date + "'";

                                            ExecuteSqlCommand(sql, null);

                                        }
                                    }
                                    #endregion

                                }

                            }
                        }

                    }

                }

            }

        }

        #endregion
    }
}