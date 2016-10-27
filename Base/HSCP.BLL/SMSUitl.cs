using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Core;
using Conan.DAL;
using Conan.Model;

namespace Conan.BLL
{
   public class SMSUitl
    {
        /// <summary>
        ///  执行中 的短信
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="dics"></param>
        /// <returns></returns>
        public bool Doing(string no)
        {
            try
            {
                var order = DalContext.Repository<Order>().TableNoTracking.Where(o => o.BillNo == no).FirstOrDefault();
                if (order.OrderState < OrderStateEnum.执行中 || order.OrderState >= OrderStateEnum.服务结束)
                    return false;

                var orderAddr = DalContext.Repository<OrderAddr>().TableNoTracking.Where(o => o.BillNo == no).FirstOrDefault();
                var orderWaiter = DalContext.Repository<OrderWaiter>().TableNoTracking.Where(o => o.BillNo == no).OrderByDescending(o => o.IsLeader).FirstOrDefault();


                if (IsTel(orderAddr.Tel))
                {
                    Dictionary<string, string> dics = new Dictionary<string, string>();
                    dics.Add("StartTime", no);
                    dics.Add("ProductName", order.ProductName);
                    dics.Add("ServiceNo", orderWaiter.ServiceName);
                    return MessageInterface.SmsSend(orderAddr.Tel, "执行中", dics);
                }
            }
            catch (Exception exc)
            {
                NLogger.Error($"订单{no}'执行中'短信发送失败, {exc.Message}");
            }
            return false;
        }

        /// <summary>
        /// 开始服务
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="dics"></param>
        /// <returns></returns>
        public bool StartServic(string no)
        {
            try
            {
                var order = DalContext.Repository<Order>().TableNoTracking.Where(o => o.BillNo == no).FirstOrDefault();
                var orderAddr = DalContext.Repository<OrderAddr>().TableNoTracking.Where(o => o.BillNo == no).FirstOrDefault();
                if (IsTel(orderAddr.Tel))
                {
                    Dictionary<string, string> dics = new Dictionary<string, string>();
                    dics.Add("ServerItemCode", no);
                    dics.Add("RealStarTime", order.RealStartTime.ToString());
                    return MessageInterface.SmsSend(orderAddr.Tel, "开始服务", dics);
                }
            }
            catch (Exception exc)
            {
                NLogger.Error($"订单{no}'开始服务'短信发送失败, {exc.Message}");
            }
            return false;
        }

        /// <summary>
        /// 结束服务
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="dics"></param>
        /// <returns></returns>
        public bool EndService(string no)
        {
            try
            {
                var order = DalContext.Repository<Order>().TableNoTracking.Where(o => o.BillNo == no).FirstOrDefault();
                var orderAddr = DalContext.Repository<OrderAddr>().TableNoTracking.Where(o => o.BillNo == no).FirstOrDefault();

                if (IsTel(orderAddr.Tel))
                {
                    Dictionary<string, string> dics = new Dictionary<string, string>();
                    dics.Add("ServerItemCode", no);
                    dics.Add("RealEndTime", order.RealEndTime.ToString());
                    return MessageInterface.SmsSend(orderAddr.Tel, "服务完成", dics);
                }
            }
            catch (Exception exc)
            {
                NLogger.Error($"订单{no}'结束服务'短信发送失败, {exc.Message}");
            }
            return false;
        }

        private bool IsTel(string tel)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(tel, @"^1\d{10}$");
        }
    }
}
