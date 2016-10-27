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
    /// 优惠券管理
    /// </summary>
    public class CouponBll : BaseBll<Coupon>
    {
        #region 构造函数
        private static CouponBll instance;
        public static CouponBll GetInstance()
        {
            if (instance == null)
            {
                instance = new CouponBll();
            }
            return instance;
        }
        #endregion
    }
}
