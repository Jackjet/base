using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.BLL
{
    public   class SkuUnitBll : BaseBll<SkuUnit>
    {
        #region 构造函数
        private static SkuUnitBll instance;
        public static SkuUnitBll GetInstance()
        {
            if (instance == null)
            {
                instance = new SkuUnitBll();
            }
            return instance;
        }
        #endregion




    }
}
