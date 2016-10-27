/****************************************************** 

    文件名称：CouponLimit.cs
    功能描述：券使用产品限制
    作    者：Jxw
    日    期：2016.05.18
    修改记录：

*******************************************************/

using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 券限制使用产品
    /// </summary>
    public class CouponLimit : Entity<int>
    {
        /// <summary>
        /// 批次Id
        /// </summary>
        public virtual int CouponGroupId { get; set; }
        /// <summary>
        /// 限制服务产品
        /// </summary>
        public virtual int ProductId { get; set; }
    }
}
