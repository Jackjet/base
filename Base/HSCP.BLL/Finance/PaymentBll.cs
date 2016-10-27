/*
 * 作者：Ldw    
 * 日期：2016.05.25
 * 描述：资金流水   
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
    public class PaymentBll : BaseBll<Payment>
    {
        #region 构造函数
        private static PaymentBll instance;
        public static PaymentBll GetInstance()
        {
            if (instance == null)
                instance = new PaymentBll();

            return instance;
        }
        #endregion

    }
}
