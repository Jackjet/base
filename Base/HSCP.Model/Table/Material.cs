/****************************************************** 

    文件名称：Material.cs
    功能描述：产品材料信息
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
    /// 材料 和 材料分成
    /// </summary>
    public class Material : Entity<int>
    {
        /// <summary>
        /// 材料名称
        /// </summary>
        [Description("材料名称")]
        public virtual string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public virtual int State { get; set; }

        /// <summary>
        /// 员工分成
        /// </summary>
        public virtual float EmployeeDeduct { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public virtual decimal Price{ get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }


        [Description("备注")]
        public virtual string Remark { get; set; }
    }
}