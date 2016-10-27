using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    public class UserLogInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClientIP { get; set; }



        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsSys { get; set; }

        /// <summary>
        /// 门店id   
        /// </summary>
        public List<int> StoreId { get; set; }


        /// <summary>
        /// 角色id
        /// </summary>
        public int? RoleId { get; set; }


        /// <summary>
        /// 产品id
        /// </summary>
        public List<int> ProductId { get; set; }



    }
}
