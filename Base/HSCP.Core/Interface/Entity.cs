/****************************************************** 

    文件名称：Entity.cs
    功能描述： 
    作    者：Jxw
    日    期：2016.04.19
    修改记录：

*******************************************************/

using System;
using System.ComponentModel;

namespace Conan.Core
{
    public abstract class Entity<T> : IEntity
    {
        [Description("Id")]
        public virtual T Id { get; set; }
    }

    public abstract class OtherEntity<T> : Entity<T>
    {
        [Description("添加时间")]
        public virtual string CreatePerson { get; set; }

        [Description("添加时间")]
        public virtual DateTime CreateDate { get; set; } = DateTime.Now;

        [Description("更新人")]
        public virtual string UpdatePerson { get; set; }

        [Description("更新时间")]
        public virtual DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}