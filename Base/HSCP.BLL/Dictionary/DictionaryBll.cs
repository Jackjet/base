using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.BLL
{
    public   class DictionaryBll : BaseBll<Dictionary>
    {
        #region 构造函数
        private static DictionaryBll instance;
        public static DictionaryBll GetInstance()
        {
            if (instance == null)
            {
                instance = new DictionaryBll();
            }
            return instance;
        }
        #endregion




    }
}
