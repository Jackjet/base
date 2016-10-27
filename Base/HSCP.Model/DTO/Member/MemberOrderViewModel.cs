using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 历史订单列表实体
    /// </summary>
    [NotMapped]

    public class MemberOrderViewModel : Order
    {
        #region  会员服务地址(MemberAddr)
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        #endregion

        /// <summary>
        /// 门店
        /// </summary>
        public string StoreName { get; set; }

        
        /// <summary>
        /// 是否欠款
        /// </summary>
        public string IsArrears { get; set; }


        ///// <summary>
        ///// 服务开始时间
        ///// </summary>
        //public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; }




        /// <summary>
        /// 详细地址
        /// </summary>
        public virtual string Street { get; set; }

        /// <summary>
        /// 拆单状态
        /// </summary>
        public virtual string  SplitName { get; set; } 













    }
}
