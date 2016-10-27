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
    public class StoreViewModel: Store
    {
        public List<Product> Productlists { get; set; }
        public List<CityArea> Arealists { get; set; }
        public int EmployeeSum { get; set; } = 0;
    }
}
