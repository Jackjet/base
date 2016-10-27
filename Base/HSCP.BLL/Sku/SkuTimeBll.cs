using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.BLL
{
    public   class SkuTimeBll : BaseBll<SkuTime>
    {
        #region 构造函数
        private static SkuTimeBll instance;
        public static SkuTimeBll GetInstance()
        {
            if (instance == null)
            {
                instance = new SkuTimeBll();
            }
            return instance;
        }
        #endregion




    }
}
