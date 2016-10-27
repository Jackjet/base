/****************************************************** 

    文件名称：Member.cs
    功能描述：会员标签
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/
using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 会员标签
    /// </summary>
    public class MemberLabel : Entity<int>
    {
        public virtual string Name { get; set; }

      

    }
}