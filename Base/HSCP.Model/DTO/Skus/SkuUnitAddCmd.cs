using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.Model
{
    /// <summary>
    /// sku  单位
    /// </summary>
    public class SkuUnitAddCmd
    {
        /// <summary>
        ///  Id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        ///  名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public int MinValue { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue { get; set; }
        /// <summary>
        /// 递增值 默认1
        /// </summary>
        public int Step { get; set; } = 1;
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; } = 0;
        /// <summary>
        /// 是否是理论工时
        /// </summary>
        public bool IsTheoreticalWork { get; set; } = false;
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
