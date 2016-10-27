/*
 * 作者：Ldw    
 * 日期：2016.07.26  
 * 描述：礼品管理优惠卷关联表
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
    /// 礼品管理
    /// </summary>
    public class GiftCouponBll : BaseBll<GiftCoupon>
    {
        #region 构造函数
        private static GiftCouponBll instance;
        public static GiftCouponBll GetInstance()
        {
            if (instance == null)
            {
                instance = new GiftCouponBll();
            }
            return instance;
        }
        #endregion
    }
}
