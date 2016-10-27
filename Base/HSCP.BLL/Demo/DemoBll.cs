using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSCP.Model;

namespace HSCP.BLL
{
    public class DemoBll : BaseBll<Demo>
    {
        #region 构造函数
        private static DemoBll instance;
        public static DemoBll GetInstance()
        {
            if (instance == null)
            {
                instance = new DemoBll();
            }
            return instance;
        }
        #endregion

    }
}
