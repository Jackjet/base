using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Conan.Model
{
    /// <summary>
    /// 集团单 详细信息
    /// </summary>
    public class SplitInfoViewModel 
    {


        /// <summary>
        /// 会员账号
        /// </summary>
        public virtual string  Account { get; set; }

        /// <summary>
        /// 会员姓名
        /// </summary>
        public virtual string Name { get; set; }


        /// <summary>
        /// 会员电话
        /// </summary>
        public virtual string BindTel { get; set; }



        /// <summary>
        /// 门店名称
        /// </summary>
        public virtual string StoreName { get; set; }














        /// <summary>
        /// 会员id
        /// </summary>
        public virtual int MemberId { get; set; }

        /// <summary>
        /// 总订单号
        /// </summary>
        public virtual string BillNo { get; set; }

        /// <summary>
        /// 产品名称(描述) 服务项目
        /// </summary>
        public virtual string ProductName { get; set; }

        /// <summary>
        /// 拆单状态
        /// </summary>
        public virtual string SplitName { get; set; }

        /// <summary>
        /// 修改之后的总金额  - （总订单分单）  一般是和订单金额一样      
        /// </summary>
        public virtual decimal? RealTotalAmount { get; set; }
        /// <summary>
        /// 欠款金额
        /// </summary>

        public virtual decimal? TotalAmount { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; }

        /// <summary>
        /// 服务开始时间
        /// </summary>
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 服务结束时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Addr { get; set; }

        /// <summary>
        /// 公交站点
        /// </summary>
        public virtual string BusStation { get; set; }

        /// <summary>
        /// 服务备注
        /// </summary>
        public virtual string ServiceRemark { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public virtual List<SplitModel>  SplitModel { get; set; }

        
    }
}
