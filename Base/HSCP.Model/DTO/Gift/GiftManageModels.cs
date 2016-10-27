    
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
  
    /// <summary>
    /// 礼包
    /// </summary>
    public class GiftManageModels
    {

        public int Id { get; set; }


        /// <summary>
        /// 礼品名称
        /// </summary>

        public  string GiftName { get; set; }
        /// <summary>
        /// 礼包价值
        /// </summary>
        public decimal Amount { get; set; }


        /// <summary>
        /// 比例
        /// </summary>
        public decimal   bl { get; set; }

        /// <summary>
        /// 优惠券
        /// </summary>
        public string yhq { get; set; }
    }
}
