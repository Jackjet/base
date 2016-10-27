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
    /// sku 
    /// </summary>
    public class SkuAddCmd
    {
        /// <summary>
        /// SkuId
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// SKU名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 属性1
        /// </summary>
        public string Property1 { get; set; }
        /// <summary>
        /// 属性2
        /// </summary>
        public string Property2 { get; set; }
        /// <summary>
        /// 属性3
        /// </summary>
        public string Property3 { get; set; }
        /// <summary>
        /// 属性4
        /// </summary>
        public string Property4 { get; set; }
        /// <summary>
        /// 属性5
        /// </summary>
        public string Property5 { get; set; }
        /// <summary>
        /// 属性6
        /// </summary>
        public string Property6 { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
