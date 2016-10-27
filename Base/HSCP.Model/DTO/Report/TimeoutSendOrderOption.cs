/*
 * 作者：cyx    
 * 日期：2016.06.08  
 * 描述：超时派单-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 超时派单-过滤条件
    /// </summary>
    public class TimeoutSendOrderOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath { get; set; }


        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 派单员
        /// </summary>
        public string SendOrderMember { get; set; }

        /// <summary>
        /// 派单开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 派单结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        public int firstTime { get; set; } = 0;
    }

    public class OrderqkOption
    {


        public int CityId { get; set; }

        public int AreaId { get; set; }
        /// <summary>
        /// 是否瞒报
        /// </summary>
        public int  ismb { get; set; }


        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath { get; set; }


        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 服务人员车辆
        /// </summary>
        public string SendOrderMember { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 服务地址
        /// </summary>
        public string Street { get; set; }




        /// <summary>
        /// 服务开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 服务结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        public int firstTime { get; set; } = 0;
    }

    public class OrderybOption
    {
        /// <summary>
        /// 是否预报时
        /// </summary>
        public OrderybEnum Isyb { get; set; }


        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }


        /// <summary>
        /// 产品分类
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 服务项目
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 服务人员车辆
        /// </summary>
        public string SendOrderMember { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStateEnum OrderState { get; set; }

        /// <summary>
        /// 真实开始时间
        /// </summary>
        public DateTime? RealStartTime { get; set; }

        /// <summary>
        /// 真实结束时间
        /// </summary>
        public DateTime? RealEndTime { get; set; }

        /// <summary>
        /// 预报开始时间
        /// </summary>
        public DateTime? YbStartTime { get; set; }

        /// <summary>
        /// 预报结束时间
        /// </summary>
        public DateTime? YbEndTime { get; set; }

        public int firstTime { get; set; } = 0;
    }
}
