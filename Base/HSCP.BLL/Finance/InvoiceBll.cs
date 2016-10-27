/*
 * 作者：chenyuxi    
 * 日期：2016.06.01
 * 描述：发票   
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
    /// 发票管理
    /// </summary>
    public class InvoiceBll : BaseBll<Invoice>
    {
        #region 构造函数
        private static InvoiceBll instance;
        public static InvoiceBll GetInstance()
        {
            if (instance == null)
                instance = new InvoiceBll();

            return instance;
        }
        #endregion

    }
}
