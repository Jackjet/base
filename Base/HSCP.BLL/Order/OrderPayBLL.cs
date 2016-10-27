//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单支付
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
    /// 订单支付
    /// </summary>
    public class OrderPayBLL : BaseBll<OrderPay>
    {
        #region 构造函数
        private static OrderPayBLL instance;
        public static OrderPayBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderPayBLL();

            return instance;
        }
        #endregion

      
    }
}
