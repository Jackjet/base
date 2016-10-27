/****************************************************** 
    功能描述：微信家庭信息模型
    作    者：ldw
    日    期：2016.07.29
    修改记录：

*******************************************************/
using System;
using Conan.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 微信家庭信息表
    /// </summary>
    [NotMapped]
    public class WxMemberFamilyViewModel: MemberFamilyInfo
    {
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddRess { get; set; }
        /// <summary>
        /// 判断是否已经存在住宅信息
        /// </summary>
        public bool IsHave { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string BillNo { get; set; }
    }
}
