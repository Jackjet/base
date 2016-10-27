using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conan.Model
{
    [NotMapped]
    public class CarViewModel:Car
    {
        /// <summary>
        ///门店名
        /// </summary>
        public virtual string StoreName{ get; set; }
        ///// <summary>
        ///// 关联员工名
        ///// </summary>
        //public virtual string UserName { get; set; }
        public virtual string VehicleTypeName { get; set; }
        public virtual string VehicleSizeName { get; set; }
    }
}
