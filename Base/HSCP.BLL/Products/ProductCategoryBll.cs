using Conan.Model;
namespace Conan.BLL
{
    public class ProductCategoryBll : BaseBll<ProductCategory>
    {
        #region 构造函数
        private static ProductCategoryBll instance;
        public static ProductCategoryBll GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductCategoryBll();
            }
            return instance;
        }
        #endregion 
    }
}