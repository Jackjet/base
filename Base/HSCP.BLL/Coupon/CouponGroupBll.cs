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
    /// 优惠券组管理
    /// </summary>
    public class CouponGroupBll : BaseBll<CouponGroup>
    {
        #region 构造函数
        private static CouponGroupBll instance;
        public static CouponGroupBll GetInstance()
        {
            if (instance == null)
            {
                instance = new CouponGroupBll();
            }
            return instance;
        }
        #endregion
    }
}
