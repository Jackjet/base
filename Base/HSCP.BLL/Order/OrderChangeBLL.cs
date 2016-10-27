//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单改价
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
using HSCP.Model;
using HSCP.Core; 
#endregion

namespace HSCP.BLL
{
    /// <summary>
    /// 订单改价
    /// </summary>
    public class OrderChangeBLL : BaseBll<OrderChange>
    {
        #region 构造函数
        private static OrderChangeBLL instance;
        public static OrderChangeBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderChangeBLL();

            return instance;
        }
        #endregion

      
    }
}
