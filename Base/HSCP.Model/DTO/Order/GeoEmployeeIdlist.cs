using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model
{
    /// <summary>
    /// 地理位置  员工列表
    /// </summary>
  

    public class GeoEmployeeIdlist
    {

        /// <summary>
        /// 员工id
        /// </summary>
        public virtual int EmployeeId { get; set; }

       /// <summary>
       /// 距离  单位 m
       /// </summary>
        public double Distance { get; set; }



    }
}
