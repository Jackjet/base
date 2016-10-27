using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
   public class PriceSkuAddCmd
    {
        /// <summary>
        /// 价格模板Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 关联SkuPrice 多个“,”分隔
        /// </summary>
        public string SkuPriceId { get; set; }
        /// <summary>
        /// Sku名称
        /// </summary>
        public string SkuValue { get; set; }
        /// <summary>
        /// 时间段 多个“,”分隔
        /// </summary>
        public virtual string SkuTimeId { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public virtual int SkuAreaId { get; set; }
        /// <summary>
        /// 会员 多个“,”分隔
        /// </summary>
        public virtual string MemberLevel { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public virtual decimal RawPrice { get; set; }
        /// <summary>
        /// 原附加价
        /// </summary>
        public virtual decimal RawAdditionalPrice { get; set; }
        /// <summary>
        /// 临时价
        /// </summary>
        public virtual decimal TempPrice { get; set; }
        /// <summary>
        /// 临时附加价
        /// </summary>
        public virtual decimal TempAdditionalPrice { get; set; }
        /// <summary>
        ///时间段
        /// </summary>
        public string TimeSlotName { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 时间段
        /// </summary>
        public int TimeSlotNo { get; set; } = 0;
        ///// <summary>
        ///// 选择 
        ///// </summary>
        //public bool Checked { get; set; }
    }
    public class PriceTimeSlot
    {
        /// <summary>
        ///时间段
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        ///时间段
        /// </summary>
        public string TimeSlotName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked { get; set; } = false;
        /// <summary>
        /// 时间段
        /// </summary>
        public int TimeSlotNo { get; set; } = 0;
    }
}
