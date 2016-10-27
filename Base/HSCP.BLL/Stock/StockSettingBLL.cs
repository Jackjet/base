/****************************************************** 

    文件名称：
    功能描述：库存设置
    作    者：coanan
    日    期：2016.06.02
    修改记录：

*******************************************************/
using Conan.Model;
namespace Conan.BLL
{
    /// <summary>
    /// 库存设置
    /// </summary>
    public class StockSettingBLL : BaseBll<StockSetting>
    {
        #region 构造函数
        private static StockSettingBLL instance;
        public static StockSettingBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new StockSettingBLL();
            }
            return instance;
        }
        #endregion 
    }
}