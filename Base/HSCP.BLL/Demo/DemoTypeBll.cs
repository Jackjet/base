using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSCP.Model;

namespace HSCP.BLL
{
    public   class DemoTypeBll : BaseBll<DemoType>
    {
        #region 构造函数
        private static DemoTypeBll instance;
        public static DemoTypeBll GetInstance()
        {
            if (instance == null)
            {
                instance = new DemoTypeBll();
            }
            return instance;
        }
        #endregion




    }
}
