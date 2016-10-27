using Conan.Model;
namespace Conan.BLL
{
    public class SalaryBll : BaseBll<Salary>
    {
        #region 构造函数
        private static SalaryBll instance;
        public static SalaryBll GetInstance()
        {
            if (instance == null)
            {
                instance = new SalaryBll();
            }
            return instance;
        }
        #endregion 
    }
}