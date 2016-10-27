using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.BLL
{
    public   class SkuAreaBll : BaseBll<SkuArea>
    {
        #region 构造函数
        private static SkuAreaBll instance;
        public static SkuAreaBll GetInstance()
        {
            if (instance == null)
            {
                instance = new SkuAreaBll();
            }
            return instance;
        }
        #endregion




    }
}
