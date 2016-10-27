using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.BLL
{
    public   class SkuPriceBll : BaseBll<SkuPrice>
    {
        #region 构造函数
        private static SkuPriceBll instance;
        public static SkuPriceBll GetInstance()
        {
            if (instance == null)
            {
                instance = new SkuPriceBll();
            }
            return instance;
        }
        #endregion
        //list取值 用sql原生语句直接插入
        //public bool AddSkuPriceList(List<SkuPrice> skuP )
        //{
            
        //}


    }
}
