/****************************************************** 

    文件名称：MemberBind.cs
    功能描述：会员第三方登录绑定
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/

using Conan.Core;
using System;

namespace Conan.Model
{
    /// <summary>
    /// 会员第三方登录绑定表
    /// </summary>
    public class MemberBind : Entity<int>
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 用户的昵称 
        /// </summary>
        public virtual string Nickname { get; set; }
        /// <summary>
        /// OpenId
        /// </summary>
        public virtual string OpenId { get; set; }
        /// <summary>
        /// 第三方来源
        /// </summary>
        public virtual string Source { get; set; }

        public virtual DateTime CreateTime { get; set; }
    }
}