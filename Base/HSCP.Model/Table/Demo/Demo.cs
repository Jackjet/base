using System;
using HSCP.Core;
using System.ComponentModel;

namespace HSCP.Model
{
   /// <summary>
   /// Demo 例子
   /// </summary>
    public class Demo : OtherEntity<int>  
    {
        /// <summary>
        /// 文本
        /// </summary>
        [Description("文本")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 布尔值
        /// </summary>
        [Description("布尔值")]
        public virtual bool? IsRequired { get; set; }

        [Description("DemoTypeId")]
        public int? DemoTypeId { get; set; }

        [Description("Checkbox")]
        public virtual string Checkbox { get; set; }
        
    }


  

}
