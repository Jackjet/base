/****************************************************** 

    文件名称：MaterialBll.cs
    功能描述：材料
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
    /// 材料管理
    /// </summary>
    public   class MaterialBll : BaseBll<Material>
    {
        #region 构造函数
        private static MaterialBll instance;
        public static MaterialBll GetInstance()
        {
            if (instance == null)
            {
                instance = new MaterialBll();
            }
            return instance;
        }
        #endregion

    }
}
