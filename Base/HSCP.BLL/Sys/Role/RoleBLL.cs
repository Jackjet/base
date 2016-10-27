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
    /// 角色
    /// </summary>
    public class RoleBLL : BaseBll<Role>
    {
        #region 构造函数
        private static RoleBLL instance;
        public static RoleBLL GetInstance()
        {
            if (instance == null)
                instance = new RoleBLL();

            return instance;
        }
        #endregion

      
    }
}
