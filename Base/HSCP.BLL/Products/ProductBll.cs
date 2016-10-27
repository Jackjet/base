using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Conan.Model;
using Conan.DAL;


namespace Conan.BLL
{
    public class ProductBll : BaseBll<Product>
    {
        #region 构造函数
        private static ProductBll instance;
        public static ProductBll GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductBll();
            }
            return instance;
        }
        #endregion


        #region 根据 产品id、区域id、时间、sku值 查询产品价格   （务轻易改动）
        /// <summary>
        /// 根据产品id 查询sku服务区域 
        /// </summary>
        /// <param name="pid">产品id</param>
        /// <param name="areaid">区域id</param>
        /// <param name="time">时间</param>
        /// <param name="skuValue">sku值</param>
        /// <param name="memberLevel">会员等级</param>
        /// <returns></returns>
        public static SkuErrorViewModel GetSkuPriceYj(int pid, int areaid, DateTime time, string skuValue, MemberLevel memberLevel = MemberLevel.普通会员)
        {
            //获取时间
            DayOfWeek dayOfWeek = time.DayOfWeek;
            TimeSpan timeSpan = TimeSpan.Parse(time.GetDateTimeFormats('t')[0]);
            //获取价格 并验证是否存在
            var skuPrices = SkuPriceBll.GetInstance().Table().Where(o => o.ProductId == pid).ToList();
            if (skuPrices.Count() == 0)
                return new SkuErrorViewModel { SkuError = SkuErrorEnum.产品的价格不服务 };
            //获取区域 并验证是否存在
            var skuAreas = SkuAreaBll.GetInstance().Table().Where(o => o.ProductId == pid).ToList();
            if (skuAreas.Count() == 0)
                return new SkuErrorViewModel { SkuError = SkuErrorEnum.服务地区不存在 };
            //获取时间 并验证是否存在
            var skuTimes = SkuTimeBll.GetInstance().Table().Where(o => o.ProductId == pid).ToList();
            if (skuTimes.Count() == 0)
                return new SkuErrorViewModel { SkuError = SkuErrorEnum.服务时间不存在 };
            //获取并验证 产品价格 的 区域
            var query = (from s in skuPrices
                         join a in skuAreas on s.SkuAreaId equals a.Id
                         where a.AreaId == areaid
                         select s).OrderBy(o => o.Id).ToList();
            if (query.Count() == 0)
                return new SkuErrorViewModel { SkuError = SkuErrorEnum.服务地区不存在 };
            //获取并验证 产品价格 的 时间
            query = (from s in query
                     join t in skuTimes on s.SkuTimeId equals t.Id
                     where t.Week == dayOfWeek && t.EndTime >= timeSpan && t.StartTime <= timeSpan
                     select s).OrderBy(o => o.Id).ToList();
            if (query.Count() == 0)
                return new SkuErrorViewModel { SkuError = SkuErrorEnum.服务时间不存在 };
            query = query.Where(o => o.SkuValue == skuValue).OrderBy(o => o.Id).ToList();
            if (query.Count() == 0)
                return new SkuErrorViewModel { SkuError = SkuErrorEnum.Sku不存在 };
            if (!query.FirstOrDefault().IsEnable)
                return new SkuErrorViewModel { SkuError = SkuErrorEnum.产品的价格不服务 };
            var data = query.FirstOrDefault();

           string ProductCode=    ProductBll.GetInstance().Get(pid).ProductCode;
            if(ProductCode.Trim()!= "10000")
            {
                #region 查询产品价格模板是否存在价格 （isItem判断是否存在价格）
                //根据产品Id获取价格模板的价格
                var items = PriceTempletItemBll.GetInstance().Table().Where(o => o.ProductId == pid).ToList();
                // 根据已获取的产品价格Id 去获取价格模板的价格
                var priceItem = new List<PriceTempletItem>();
                //判断SkuPriceId
                if (items.Count() > 0)
                    priceItem = items.Where(o => o.SkuPriceId.Contains("," + data.Id.ToString() + ",")).ToList();
                //判断会员
                if (priceItem.Count() > 0)
                    priceItem = priceItem.Where(o => o.MemberLevel.Contains("," + memberLevel + ",")).ToList();
                //判断时间
                if (priceItem.Count() > 0)
                {
                    foreach (var i in priceItem)
                    {
                        var skuTimeIdArray = i.SkuTimeId.Split(',');
                        List<int> skuTimeIds = new List<int>();
                        for (int j = 0; j < skuTimeIdArray.Length; j++)
                        {
                            if (skuTimeIdArray[j] != "")
                                skuTimeIds.Add(int.Parse(skuTimeIdArray[j]));
                        }
                        var priceItemTime = skuTimes.Where(o => skuTimeIds.Contains(o.Id)).ToList();
                        var priceTemplet = PriceTempletBll.GetInstance().Get(i.PriceTempletId);
                        if (priceTemplet != null && priceTemplet.State == PriceTempletStateEnum.启用)
                        {
                            //判断价格模板时间
                            if (time >= priceTemplet.StartTime && time <= priceTemplet.EndTime)
                            {
                                foreach (var t in priceItemTime)
                                {
                                    //判断sku时间
                                    if (dayOfWeek == t.Week && timeSpan >= t.StartTime && timeSpan <= t.EndTime)
                                    {
                                        data.Price = i.Price;
                                        data.AdditionalPrice = i.AdditionalPrice;
                                    }
                                }

                            }
                        }
                    }
                }
                #endregion
            }
            return new SkuErrorViewModel { SkuError = SkuErrorEnum.正常, SkuPriceView = data };
        }
        #endregion




        /// <summary>
        /// 获取价格
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="areaid"></param>
        /// <param name="time"></param>
        /// <param name="skuNames"></param>
        /// <param name="units"></param>
        /// <param name="memberLevel"></param>
        /// <returns></returns>
        public static ProductPriceView GetProductPrice(int productId, int areaid, DateTime time, Dictionary<int, string> skuNames, Dictionary<int, int> units, MemberLevel memberLevel)
        {
            //获取时间
            DayOfWeek dayOfWeek = time.DayOfWeek;
            TimeSpan timeSpan = TimeSpan.Parse(time.GetDateTimeFormats('t')[0]);
            string skun = "," + string.Join(",", skuNames.Select(o => o.Value).ToList()) + ",";
            using (var uk = DalContext.UnitWork())
            {
                var skuPriceRep = uk.Get<SkuPrice>();
                var skuAreaRep = uk.Get<SkuArea>();
                var skuTimeRep = uk.Get<SkuTime>();

                #region 判断
                //判断地区是否服务
                int numArea = skuAreaRep.TableNoTracking.Count(o => o.ProductId == productId && o.AreaId == areaid);
                if (numArea == 0)
                    throw new Exception("产品不在服务地区范围内");
                //判断时间是否服务
                int numTime = skuTimeRep.TableNoTracking.Count(o => o.ProductId == productId && o.Week == dayOfWeek && o.StartTime <= timeSpan && o.EndTime >= timeSpan);
                if (numTime == 0)
                    throw new Exception("产品不在服务时间范围内");
                #endregion

                var priceTempletItemRep = uk.Get<PriceTempletItem>();
                var priceTempletRep = uk.Get<PriceTemplet>();

                var data = (from s in skuPriceRep.TableNoTracking
                            join a in skuAreaRep.TableNoTracking on s.SkuAreaId equals a.Id
                            join t in skuTimeRep.TableNoTracking on s.SkuTimeId equals t.Id
                            where s.ProductId == productId && s.SkuValue == skun && a.AreaId == areaid && t.Week == dayOfWeek && t.StartTime <= timeSpan && t.EndTime >= timeSpan
                            select s).OrderBy(o => o.Id).FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("查找不到价格,当前选择的产品组合不服务");
                }





                #region 查询产品价格模板是否存在价格 （isItem判断是否存在价格）
                //根据已获取的产品价格Id 去获取价格模板的价格
                //根据产品Id获取价格模板的价格
                List<PriceTempletItem> priceItems = priceTempletItemRep.TableNoTracking.Where(o => o.ProductId == productId && o.SkuPriceId.Contains("," + data.Id.ToString() + ",") && o.MemberLevel.Contains("," + memberLevel + ",")).ToList();
                List<int> priceTempletIds = priceItems.Select(o => o.PriceTempletId).ToList();
                var priceTemplets = priceTempletRep.TableNoTracking.Where(o => priceTempletIds.Contains(o.Id));
                foreach (var priceItem in priceItems)
                {
                    List<int> skuTimeIds = priceItem.SkuTimeId.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(o => Convert.ToInt32(o)).ToList();
                    List<SkuTime> priceItemTime = skuTimeRep.TableNoTracking.Where(o => skuTimeIds.Contains(o.Id)).ToList();
                    var priceTemplet = priceTemplets.FirstOrDefault(o => o.Id == priceItem.PriceTempletId);
                    if (priceTemplet != null && priceTemplet.State == PriceTempletStateEnum.启用)
                    {
                        if (time >= priceTemplet.StartTime && time <= priceTemplet.EndTime)
                        {
                            foreach (var t in priceItemTime)
                            {
                                //判断sku时间
                                if (dayOfWeek == t.Week && timeSpan >= t.StartTime && timeSpan <= t.EndTime)
                                {
                                    data.Price = priceItem.Price;
                                    data.AdditionalPrice = priceItem.AdditionalPrice;
                                }
                            }
                        }
                    }
                }

                #endregion
                ProductPriceView dataPrice = new ProductPriceView();
                dataPrice.NowPrice = data.Price;
                int unitsRide = 1;
                foreach (var u in units)
                {
                    unitsRide = unitsRide * u.Value;
                }
                dataPrice.TotalPrice = data.Price * unitsRide + data.AdditionalPrice;
                return dataPrice;
            }
        }

        /// <summary>
        /// 附加村料价格计算
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="mIds"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static List<decimal> GetMaterialPrice(int productId, Dictionary<int, int> materials)
        {
            List<decimal> prices = new List<decimal>();
            if (materials == null)
                return new List<decimal>();

            var repMaterial = DalContext.Repository<Material>();
            List<int> mids = materials.Select(o => o.Key).ToList();
            var materialPrices = repMaterial.TableNoTracking.Where(o => mids.Contains(o.Id)).Select(o => new { o.Id, o.Price }).ToList();
            foreach (var s in materials)
            {
                var m = materialPrices.FirstOrDefault(a => a.Id == s.Key);
                if (m == null)
                    throw new Exception($"Id为{s.Key}没找到价格高");
                prices.Add(m.Price * s.Value);
            }
            return prices;
        }
        #region 获取产品最小价
        /// <summary>
        /// 获取产品最小价
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="mIds"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static ProductPriceView GetProductMinPrice(int id, int city)
        {
            DateTime time = DateTime.Now;
            //获取时间
            using (var uk = DalContext.UnitWork())
            {
                var repSkuPrice = uk.Get<SkuPrice>();
                var repSkuArea = uk.Get<SkuArea>();
                var repPriceTemplet = uk.Get<PriceTemplet>();
                var repPriceItem = uk.Get<PriceTempletItem>();
                var skuAreaId = repSkuArea.TableNoTracking.Where(o => o.ProductId == id && o.CityId == city).Select(o => o.Id).ToList();
                var realPrice = repSkuPrice.TableNoTracking.Where(o => o.ProductId == id && skuAreaId.Contains(o.SkuAreaId)).OrderBy(o => o.Price).Select(o => new { o.Price }).FirstOrDefault();
                var priceItem = (from i in repPriceItem.TableNoTracking
                                 join t in repPriceTemplet.TableNoTracking on i.PriceTempletId equals t.Id
                                 join p in repSkuPrice.TableNoTracking on i.ProductId equals p.ProductId
                                 where i.ProductId == id && t.State == PriceTempletStateEnum.启用 && t.StartTime <= time && t.EndTime >= time && skuAreaId.Contains(i.SkuAreaId)
                                 select new
                                 {
                                     Price = p.Price,
                                     NowPrice = i.Price
                                 }).OrderBy(o => o.Price).FirstOrDefault();
                //获取价格
                ProductPriceView productPrice = new ProductPriceView();
                if (realPrice != null)
                {
                    productPrice.Price = realPrice.Price;
                    productPrice.NowPrice = realPrice.Price;
                }
                if (realPrice != null && priceItem != null)
                {
                    if (realPrice.Price <= priceItem.NowPrice)
                    {
                        productPrice.Price = realPrice.Price;
                        productPrice.NowPrice = realPrice.Price;
                    }
                    if (realPrice.Price > priceItem.NowPrice)
                    {
                        productPrice.Price = priceItem.Price;
                        productPrice.NowPrice = priceItem.NowPrice;
                    }
                }
                return productPrice;
            }
        }
        #endregion
    }
}