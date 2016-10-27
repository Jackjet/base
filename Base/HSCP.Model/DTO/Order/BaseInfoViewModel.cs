using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 订单详情-基础信息
    /// </summary>
  

    public class BaseInfoViewModel 
    {

        /// <summary>
        /// 客户Id
        /// </summary>
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }



        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string Nickname { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public virtual string Account { get; set; }
        
        /// <summary>
        /// 手机
        /// </summary>
        public virtual string Cellphone { get; set; }


        /// <summary>
        /// 地址  会员地址 默认
        /// </summary>
        public virtual string Addr { get; set; }


        /// <summary>
        /// 门店
        /// </summary>
        public virtual string  StoreName { get; set; }


        /// <summary>
        /// 业务渠道  (订单来源)
        /// </summary>
        public virtual string  BuChannel { get; set; }

        /// <summary>
        /// 获客渠道
        /// </summary>
        public virtual string AccessChannel { get; set; }

        /// <summary>
        /// 开发人
        /// </summary>
        public virtual string Developer { get; set; }



        /// <summary>
        /// 修改之后的总金额  - （总订单分单）  一般是和订单金额一样      
        /// </summary>
        public virtual decimal RealTotalAmount { get; set; }


        /// <summary>
        /// 欠费金额   
        /// </summary>
        public virtual decimal ArrearsAmount { get; set; }


        #region 取消订单信息 
        /// <summary>
        /// 取消时间
        /// </summary>
        public virtual DateTime caceltime { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        public virtual string reason { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remark { get; set; }

        /// <summary>
        /// 扣款金额
        /// </summary>
        public virtual decimal kamunt { get; set; }
        #endregion



    }
}
