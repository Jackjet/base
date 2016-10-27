//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：下单指定员工/车辆
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
    /// 下单指定员工/车辆
    /// </summary>
    public class OrderSpecifiedBLL : BaseBll<OrderSpecified>
    {
        #region 构造函数
        private static OrderSpecifiedBLL instance;
        public static OrderSpecifiedBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderSpecifiedBLL();

            return instance;
        }
        #endregion

      
    }
}
