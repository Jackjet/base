/****************************************************** 

    文件名称：StoreBll.cs
    功能描述：门店管理
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using Conan.Model;
namespace Conan.BLL
{
    /// <summary>
    /// 门店管理
    /// </summary>
    public class StoreBll : BaseBll<Store>
    {
        #region 构造函数
        private static StoreBll instance;
        public static StoreBll GetInstance()
        {
            if (instance == null)
            {
                instance = new StoreBll();
            }
            return instance;
        }
        #endregion 
    }
}