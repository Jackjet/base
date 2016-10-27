using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
   public class TimeSlotAddCmd
    {
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
