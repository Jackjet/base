/*
 * 作者：Ldw    
 * 日期：2016.05.23  
 * 描述：优惠券   
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
    /// 优惠券限制管理
    /// </summary>
    public class CouponLimitBll : BaseBll<CouponLimit>
    {
        #region 构造函数
        private static CouponLimitBll instance;
        public static CouponLimitBll GetInstance()
        {
            if (instance == null)
            {
                instance = new CouponLimitBll();
            }
            return instance;
        }
        #endregion
    }
}
