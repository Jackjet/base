/****************************************************** 

    文件名称：DepartmentBll.cs
    功能描述：部门管理
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using Conan.Model;
namespace Conan.BLL
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public class DepartmentBll : BaseBll<Department>
    {
        #region 构造函数
        private static DepartmentBll instance;
        public static DepartmentBll GetInstance()
        {
            if (instance == null)
            {
                instance = new DepartmentBll();
            }
            return instance;
        }
        #endregion 
    }
}