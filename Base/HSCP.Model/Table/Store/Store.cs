/****************************************************** 

    文件名称：Store.cs
    功能描述：门店信息
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using Conan.Core;
using System;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 门店
    /// </summary>
    public partial class Store : Entity<int>
    {
        ///// <summary>
        ///// 门店编号
        ///// </summary>
        //public virtual string StoreCode { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        [Description("门店名称")]
        public virtual string StoreName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        public virtual string Img { get; set; }
        /// <summary>
        /// 属在城市
        /// </summary>
        [Description("属在城市")]
        public virtual int CityId { get; set; }
        /// <summary>
        /// 属在地区
        /// </summary>
        [Description("属在地区")]
        public virtual int AreaId { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        [Description("详细地址")]
        public virtual string Addr { get; set; }
        /// <summary>
        /// 店主名称（负责人）
        /// </summary>
        [Description("店长")]
        public virtual string StoreKeeper { get; set; }
        /// <summary>
        /// 店主手机
        /// </summary>
        [Description("店长手机")]
        public virtual string StoreKeeperTel { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public virtual int State { get; set; }
        /// <summary>
        /// 店长身份证
        /// </summary>
        [Description("店长身份证")]
        public virtual string IDCard { get; set; }
        ///// <summary>
        ///// 身份证图片
        ///// </summary>
        //[Description("身份证图片1")]
        //public virtual string IDCardImg { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        [Description("营业执照")]
        public virtual string BusinessLicense { get; set; }
        /// <summary>
        /// 营业执照图片
        /// </summary>
        [Description("营业执照图片")]
        public virtual string BusinessLicenseImg { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [Description("负责人")]
        public virtual string Officer { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        [Description("负责人电话")]
        public virtual string OfficerTel { get; set; }
        /// <summary>
        /// 负责人身份证
        /// </summary>
        [Description("负责人身份证")]
        public virtual string OfficerIDCard { get; set; }
        /// <summary>
        /// 负责人身份证（正面照）
        /// </summary>
        [Description("负责人身份证（正面照）")]
        public virtual string OfficerIDCartImg1 { get; set; }
        /// <summary>
        /// 负责人身份证（反面照）
        /// </summary>
        [Description("负责人身份证（反面照）")]
        public virtual string OfficerIDCartImg2 { get; set; }
    }
}