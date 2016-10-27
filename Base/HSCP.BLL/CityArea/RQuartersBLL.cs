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
    /// 小区
    /// </summary>
    public class RQuartersBLL : BaseBll<RQuarters>
    {
        #region 构造函数
        private static RQuartersBLL instance;
        public static RQuartersBLL GetInstance()
        {
            if (instance == null)
                instance = new RQuartersBLL();

            return instance;
        }
        #endregion

      
    }
}
