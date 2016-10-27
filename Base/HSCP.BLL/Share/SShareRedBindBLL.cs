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
    /// 领取红包明细
    /// </summary>
    public class SShareRedBindBLL : BaseBll<ShareRedBind>
    {
        #region 构造函数
        private static SShareRedBindBLL instance;
        public static SShareRedBindBLL GetInstance()
        {
            if (instance == null)
                instance = new SShareRedBindBLL();

            return instance;
        }
        #endregion

      
    }
}
