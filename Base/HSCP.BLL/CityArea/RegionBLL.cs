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
    /// 大区
    /// </summary>
    public class RegionBLL : BaseBll<Region>
    {
        #region 构造函数
        private static RegionBLL instance;
        public static RegionBLL GetInstance()
        {
            if (instance == null)
                instance = new RegionBLL();

            return instance;
        }
        #endregion

      
    }
}
