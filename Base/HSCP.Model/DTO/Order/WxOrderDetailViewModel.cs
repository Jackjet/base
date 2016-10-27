using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 微信员工订单详情实体
    /// </summary>
    [NotMapped]

    public class WxOrderDetailViewModel
    {

        /// <summary>
        /// 是否预报时过
        /// </summary>
        public bool? isybs { get; set; }



        /// <summary>
        /// 是否溢价
        /// </summary>
        public bool? isyj { get; set; }


        /// <summary>
        /// 订单编号
        /// </summary>
        public string Billno { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStateEnum OrderState { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        ///  修改之后的总金额  - （总订单分单）  一般是和订单金额一样    
        /// </summary>
        public decimal RealTotalAmount { get; set; }
        /// <summary>
        /// 客户付款金额（客户实际支付的金额）  实收金额   
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 是否手签
        /// </summary>
        public bool? IsSigns { get; set; }
        /// <summary>
        /// 服务项目名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 预约服务开始时间
        /// </summary>
        public  DateTime? StartTime { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public  string ContactTel { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Street { get; set; }

        public int CityId { get; set; }
        public int AreaId { get; set; }
        /// <summary>
        /// 公交站点
        /// </summary>
        public string BusStation { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double? Lng { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double? Lat { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string EndStreet { get; set; }

        public int EndCityId { get; set; }
        public int EndAreaId { get; set; }

        /// <summary>
        /// 服务明细
        /// </summary>
        public List<string> Skus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 服务备注
        /// </summary>
        public string ServiceRemark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 该订单用户的Id
        /// </summary>
        public int MemberId { get; set; }
        //员工集合
        public List<WxOrderDetailEmployee> Employees { get; set; }
        //家庭信息
        public WxMemberFamilyViewModel Family { get; set; }
        

    }
    public class WxOrderDetailEmployee
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 员工电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 是否队长
        /// </summary>
       public bool? IsLeader { get; set; }
    }
}
