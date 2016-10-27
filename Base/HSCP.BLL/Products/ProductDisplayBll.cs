using Conan.Model;
namespace Conan.BLL
{
    public class ProductDisplayBll : BaseBll<ProductDisplay>
    {
        #region 构造函数
        private static ProductDisplayBll instance;
        public static ProductDisplayBll GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductDisplayBll();
            }
            return instance;
        }
        #endregion 
    }
}