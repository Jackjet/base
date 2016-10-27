using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using System.Data.SqlClient;

namespace Conan.BLL
{
    public   class CarBll : BaseBll<Car>
    {
        #region 构造函数
        private static CarBll instance;
        public static CarBll GetInstance()
        {
            if (instance == null)
            {
                instance = new CarBll();
            }
            return instance;
        }
        #endregion

     

    }
}
