/****************************************************** 

    文件名称：StoreAreaBll.cs
    功能描述：门店区域管理
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using Conan.Model;
namespace Conan.BLL
{
    /// <summary>
    /// 门店区域管理
    /// </summary>
    public class StoreAreaBll : BaseBll<StoreProductArea>
    {
        #region 构造函数
        private static StoreAreaBll instance;
        public static StoreAreaBll GetInstance()
        {
            if (instance == null)
            {
                instance = new StoreAreaBll();
            }
            return instance;
        }
        #endregion 
    }
}