/*
 * 作者：Ldw    
 * 日期：2016.06.27
 * 描述：咨讯
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using System.Data.SqlClient;

namespace Conan.BLL
{
    /// <summary>
    /// 咨讯管理
    /// </summary>
    public class InformationBll : BaseBll<Information>
    {
        #region 构造函数
        private static InformationBll instance;
        public static InformationBll GetInstance()
        {
            if (instance == null)
            {
                instance = new InformationBll();
            }
            return instance;
        }
        #endregion
    }
}
