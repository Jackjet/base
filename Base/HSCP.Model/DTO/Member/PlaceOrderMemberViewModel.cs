/****************************************************** 

    文件名称：PlaceOrderMemberViewModel.cs
    功能描述：后台开单（会员查询）视图信息
    作    者：cyx
    日    期：2016.05.26
    修改记录：

*******************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Conan.Model
{
    [NotMapped]
    public class PlaceOrderMemberViewModel : Member
    {
        /// <summary>
        /// 默认地址信息
        /// </summary>
        public string DefaultMemberAddr { get; set; }
        /// <summary>
        /// 发票
        /// </summary>
        public string InvoiceHeader { get; set; }

        /// <summary>
        /// 有效优惠券总额
        /// </summary>
        public virtual decimal CouponSummary { get; set; }
    }
}
