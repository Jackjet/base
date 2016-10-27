/****************************************************** 

    文件名称：StoreProductBll.cs
    功能描述：门店产品管理
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using Conan.Model;
namespace Conan.BLL
{
    /// <summary>
    /// 门店产品管理
    /// </summary>
    public class StoreProductBll : BaseBll<StoreProduct>
    {
        #region 构造函数
        private static StoreProductBll instance;
        public static StoreProductBll GetInstance()
        {
            if (instance == null)
            {
                instance = new StoreProductBll();
            }
            return instance;
        }
        #endregion 
    }
}