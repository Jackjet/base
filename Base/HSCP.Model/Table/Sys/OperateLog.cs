using System;
using Conan.Core;

namespace Conan.Model
{
    public  class OperateLog : Entity<int>
    {
        /// <summary>
        /// 操作者
        /// </summary>
        public virtual string Operator { get; set; }

        public virtual int OperatorId { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public virtual string Tag { get; set; }

        public virtual string IP { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public virtual string Content { get; set; }

        public virtual DateTime CreateTime { get; set; } = DateTime.Now;
    }
}