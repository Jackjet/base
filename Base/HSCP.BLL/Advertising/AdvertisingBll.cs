using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using System.Data.SqlClient;
using Conan.Core;
using Conan.DAL;
using Conan.Utils;

namespace Conan.BLL
{
    public   class AdvertisingBll : BaseBll<Advertising>
    {
        #region 构造函数
        private static AdvertisingBll instance;
        public static AdvertisingBll GetInstance()
        {
            if (instance == null)
            {
                instance = new AdvertisingBll();
            }
            return instance;
        }
        #endregion


     



         
    


    }
}
