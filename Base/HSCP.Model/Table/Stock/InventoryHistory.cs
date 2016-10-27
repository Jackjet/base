/****************************************************** 
    文件名称：
    功能描述：库存更新历史
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
    /// 库存更新历史
    /// </summary>
    public class InventoryHistory : Entity<int>
    {


        /// <summary>
        /// 日期
        /// </summary>
        [Description("日期")]
        public virtual DateTime CreTime { get; set; }


    }
}