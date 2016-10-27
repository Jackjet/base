/****************************************************** 

    文件名称：
    功能描述：库存设置
    作    者：conan
    日    期：2016.06.02
    修改记录：

*******************************************************/
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 库存设置
    /// </summary>
    public class StockSetting : Entity<int>
    {
      
        /// <summary>
        /// 产品Id
        /// </summary>
        [Description("产品ID")]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// 预警值
        /// </summary>
        [Description("预警值")]
        public virtual decimal WarningValue { get; set; }

        /// <summary>
        /// 溢出值
        /// </summary>
        [Description("溢出值")]
        public virtual decimal OverflowValue { get; set; }
    }
}