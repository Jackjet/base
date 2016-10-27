/****************************************************** 

    文件名称：MaterialProudctBll.cs
    功能描述：材料产品
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.BLL
{
    /// <summary>
    /// 材料产品
    /// </summary>
    public class MaterialProudctBll : BaseBll<MaterialProduct>
    {
        #region 构造函数
        private static MaterialProudctBll instance;
        public static MaterialProudctBll GetInstance()
        {
            if (instance == null)
            {
                instance = new MaterialProudctBll();
            }
            return instance;
        }
        #endregion




    }
}
