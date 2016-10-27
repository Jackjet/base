using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using Conan.Core;
  
namespace Conan.BLL
{
    /// <summary>
    /// 角色用户
    /// </summary>
    public class UserRoleBLL : BaseBll<UserRole>
    {
        #region 构造函数
        private static UserRoleBLL instance;
        public static UserRoleBLL GetInstance()
        {
            if (instance == null)
                instance = new UserRoleBLL();

            return instance;
        }
        #endregion

      
    }
}
