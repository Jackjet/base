/****************************************************** 

    文件名称：Material.cs
    功能描述：材料对应的产品信息
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 材料、产品
    /// </summary>
    public class MaterialProduct : Entity<int>
    {
        /// <summary>
        /// 材料Id
        /// </summary>
        [Description("材料Id")]
        public virtual int MaterialId { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        [Description("产品ID")]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否前端显示
        /// </summary>
        public virtual bool IsShowed { get; set; }
    }
}