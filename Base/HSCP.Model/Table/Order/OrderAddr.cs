//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单相关表
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 订单服务地址表
    /// </summary>
    public partial class OrderAddr : Entity<int>
    {
        /// <summary>
        /// 总订单号
        /// </summary>
        [Description("总订单号")]
        public virtual string BillNo { get; set; }



        /// <summary>
        /// 市
        /// </summary>
        [Description("市")]
        public virtual int CityId { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        [Description("区域")]
        public virtual int AreaId { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Description("详细地址")]
        public virtual string Street { get; set; } = "";

        /// <summary>
        /// 公交站点
        /// </summary>
        [Description("公交站点")]
        public virtual string BusStation { get; set; } = "";


        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public virtual double? Lng { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public virtual double? Lat { get; set; }

        #region 搬家运输 目标地




        /// <summary>
        /// 市
        /// </summary>
        [Description("市")]
        public virtual int EndCityId { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        [Description("区域")]
        public virtual int EndAreaId { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Description("详细地址")]
        public virtual string EndStreet { get; set; } = "";



        /// <summary>
        /// 公交站点
        /// </summary>
        [Description("公交站点")]
        public virtual string EndBusStation { get; set; } = "";

        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public virtual double? EndLng { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public virtual double? EndLat { get; set; }
        #endregion

        /// <summary>
        /// 联系人
        /// </summary>
        [Description("联系人")]
        public virtual string Contact { get; set; } = "";
        /// <summary>
        /// 联系电话
        /// </summary>
        [Description("联系电话")]
        public virtual string Tel { get; set; } = "";



        /// <summary>
        /// 小区id 出发点
        /// </summary>
        [Description("小区id")]
        public virtual int? RQuartersId { get; set; }
        /// <summary>
        /// 小区名称 出发点
        /// </summary>
        [Description("小区名称")]
        public virtual string RQuartersName { get; set; }



        /// <summary>
        /// 小区id  目的地
        /// </summary>
        [Description("小区id")]
        public virtual int? EndRQuartersId { get; set; }
        /// <summary>
        /// 小区名称 目的地
        /// </summary>
        [Description("小区名称")]
        public virtual string EndRQuartersName { get; set; }



    }
}