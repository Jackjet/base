using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.BLL
{
    public   class SkuBll : BaseBll<Sku>
    {
        #region 构造函数
        private static SkuBll instance;
        public static SkuBll GetInstance()
        {
            if (instance == null)
            {
                instance = new SkuBll();
            }
            return instance;
        }
        #endregion




    }
}
