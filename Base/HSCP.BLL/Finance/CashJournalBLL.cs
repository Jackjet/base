//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 资金流水
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.11
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

namespace Conan.BLL
{
    /// <summary>
    /// 员工
    /// </summary>
    public class CashJournalBLL : BaseBll<CashJournal>
    {
        #region 构造函数
        private static CashJournalBLL instance;
        public static CashJournalBLL GetInstance()
        {
            if (instance == null)
                instance = new CashJournalBLL();

            return instance;
        }
        #endregion

    }
}
