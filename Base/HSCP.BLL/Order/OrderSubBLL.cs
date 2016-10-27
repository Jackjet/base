//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：子订单
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
#endregion

namespace Conan.BLL
{
    /// <summary>
    /// 子订单
    /// </summary>
    public class OrderSubBLL : BaseBll<OrderSub>
    {
        #region 构造函数
        private static OrderSubBLL instance;
        public static OrderSubBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderSubBLL();

            return instance;
        }
        #endregion

        #region 根据子订单号获取子订单
        /// <summary>
        /// 根据子订单号获取子订单
        /// </summary>
        /// <param name="BillItemNo">子订单号</param>
        /// <returns>子订单对象</returns>
        public OrderSub GetOrderSubByBillItemNo(string BillItemNo)
        {
            return TableNoTracking().Where(o => o.BillItemNo == BillItemNo).FirstOrDefault();

        }
        #endregion

    }
}
