/*
 * 作者：Ldw    
 * 日期：2016.09.08
 * 描述：提现   
 * 修改记录：    
 * */
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
    public class WithdrawalBll : BaseBll<Withdrawal>
    {
        #region 构造函数
        private static WithdrawalBll instance;
        public static WithdrawalBll GetInstance()
        {
            if (instance == null)
                instance = new WithdrawalBll();

            return instance;
        }
        #endregion

    }
}
