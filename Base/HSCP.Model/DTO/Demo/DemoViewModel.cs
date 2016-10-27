using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSCP.Model
{
    /// <summary>
    /// 列表实体
    /// </summary>
    [NotMapped]

    public class DemoViewModel : Demo
    {
        public string NameExt { get; set; }


        public string DemoTypeName { get; set; }
    }
}
