using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSCP.Model;
using HSCP.Core;

namespace HSCP.BLL
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserBLL : BaseBll<User>
    {
        #region 构造函数
        private static UserBLL instance;
        public static UserBLL GetInstance()
        {
            if (instance == null)
                instance = new UserBLL();

            return instance;
        }
        #endregion

    
    }
}
