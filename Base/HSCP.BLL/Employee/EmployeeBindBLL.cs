//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工第三方登录绑定
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.07.24  
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using System.Data.SqlClient;
using System.Data;
using Conan.Core;
using Conan.DAL;
using Conan.Utils;
using System.Threading;
using System.Text.RegularExpressions;

namespace Conan.BLL
{
    /// <summary>
    /// 员工第三方登录绑定
    /// </summary>
    public class EmployeeBindBLL : BaseBll<EmployeeBind>
    {
        #region 构造函数
        private static EmployeeBindBLL instance;
        public static EmployeeBindBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeBindBLL();
            }
            return instance;
        }
        #endregion
    }
}
