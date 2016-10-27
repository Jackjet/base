using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class SkuTimeAddCmd
    {
        /// <summary>
        /// 服务时间Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 周几
        /// </summary>
        public DayOfWeek Week { get; set; }
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
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 时间段
        /// </summary>
        public int TimeSlotNo { get; set; } = 0;
    }
}
