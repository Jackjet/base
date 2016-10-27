//文件名称(File Name)： 
//功能描述(Description)：车辆分成比例表
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.06.11
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 车辆薪酬计算
    /// </summary>
    public class SalaryCar : Entity<int>
    {
        /// <summary>
        /// 产品编号 
        /// </summary>
        [Description("产品ID")]
        public virtual int? ProductId { get; set; }
        /// <summary>
        /// 产品分类编号 
        /// </summary>
        [Description("产品分类ID")]
        public virtual int ProductCategoryId { get; set; }

        //车辆附加提成   

        /// <summary>
        /// 自有附加(好评)提成 
        /// </summary>
        [Description("自有附加(好评)提成")]
        public virtual float OwnGood { get; set; }
        /// <summary>
        /// 自有附加(差评)提成
        /// </summary>
        [Description("自有附加(差评)提成")]
        public virtual float OwnBad { get; set; }
        /// <summary>
        /// 挂靠(好评) 提成
        /// </summary>
        [Description("挂靠(好评)提成")]
        public virtual float AnchoredGood { get; set; }
        /// <summary>
        /// 挂靠 (差评)提成
        /// </summary>
        [Description("挂靠(差评)提成")]
        public virtual float AnchoredBad { get; set; }
        /// <summary>
        /// 外协(好评) 提成
        /// </summary>
        [Description("外协(好评)提成")]
        public virtual float OuterGood { get; set; }
        /// <summary>
        ///外协(差评)提成
        /// </summary>
        [Description("外协(差评)提成")]
        public virtual float OuterBad { get; set; }
    }
}