using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Model
{
    [NotMapped]
    public class MaterialViewModel: Material
    {
        public string ProductNames { get; set; }
        public string StoreDeduct { get; set; }

        public string ProductShowedNames { get; set; }
    }
}
