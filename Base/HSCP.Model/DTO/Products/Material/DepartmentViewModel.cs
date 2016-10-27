using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.Model
{
    /// <summary>
    /// 门店视图
    /// </summary>
    [NotMapped]
    public class DepartmentViewModel : Department
    {
      public string ParentDepartMentName { get; set; }
      public string StoreName { get; set; }


    }
}
