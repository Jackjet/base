using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 系统错误日志表
    /// </summary>
    public class ErrorLog : Entity<int>
    {
        public virtual string Origin { get; set; }

        public virtual string LogLevel { get; set; }

        public virtual string Message { get; set; }

        public virtual string StackTrace { get; set; }

        public virtual DateTime CreateDate { get; set; }



    }
}
