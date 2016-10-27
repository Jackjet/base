using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conan.Model
{
    /// <summary>
    /// 枚举下拉列表
    /// </summary>
    public class EnumOption
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool selected { get; set; }
    }
}
