using Conan.Model;
namespace Conan.BLL
{
    public class SalaryCarBll : BaseBll<SalaryCar>
    {
        #region 构造函数
        private static SalaryCarBll instance;
        public static SalaryCarBll GetInstance()
        {
            if (instance == null)
            {
                instance = new SalaryCarBll();
            }
            return instance;
        }
        #endregion 
    }
}