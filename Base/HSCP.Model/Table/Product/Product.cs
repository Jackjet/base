using Conan.Core;
using System;
using System.ComponentModel;


namespace Conan.Model
{
    /// <summary>
    /// 服务产品 
    /// </summary>
    public class Product : Entity<int>
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        [Description("产品名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 产品类别
        /// </summary>
        [Description("产品类别")]
        public virtual int ProductCategoryId { get; set; }
        /// <summary>
        /// 简介
        /// </summary>        
        [Description("简介")]
        public virtual string Discription { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        [Description("详情")]
        public virtual string Details { get; set; }
        /// <summary>
        /// Banner
        /// </summary>
        [Description("Banner")]
        public virtual string Banner { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [Description("图标")]
        public virtual string Icon { get; set; }
        /// <summary>
        /// 上下架状态
        /// </summary>
        [Description("上下架状态")]
        public virtual ProductStateEnum State { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [Description("产品编号")]
        public virtual string ProductCode { get; set; }
        /// <summary>
        /// 预定提前时间 小时
        /// </summary>
        [Description("预定提前时间")]
        public virtual int? PresaleMin { get; set; }
        /// <summary>
        /// 最大预售期 天
        /// </summary>
        [Description("最大预售期")]
        public virtual int? PresaleMax { get; set; }
        /// <summary>
        /// 是否可拆单（）
        /// </summary>
        [Description("是否可拆单")]
        public virtual bool IsSplit { get; set; } = false;
        /// <summary>
        /// 关联普通产品编号
        /// </summary>
        [Description("关联普通产品编号")]
        public virtual int? RelatedProductId  { get; set; }
        /// <summary>
        /// 是否可指定员工
        /// </summary>
        [Description("是否可指定员工")]
        public virtual bool IsEmployee { get; set; } = false;
        /// <summary>
        /// 是否校验库存（1:前、后台均校验;2:前、后台均不校验;
        /// 
        /// </summary>
        [Description("是否校验库存")]
        public virtual int VerifyStock { get; set; }
        /// <summary>
        /// 理论工时
        /// </summary>
        [Description("理论工时")]
        public virtual double? TheoreticalWork { get; set; }

        /// <summary>
        /// 服务选项
        /// </summary>
        [Description("服务选项")]
        public virtual ProductServiceEnum ServiceOption { get; set; } = ProductServiceEnum.服务人员;
        /// <summary>
        /// 服务地址数量
        /// </summary>
        [Description("服务地址数量")]
        public virtual int AddressNumber { get; set; } = 1;
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public virtual int Sort { get; set; } = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 溢出价钱
        /// </summary>
        [Description("溢出价钱")]
        public virtual decimal? SpillPrice { get; set; } 
        
    }
}