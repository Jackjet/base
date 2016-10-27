using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conan.Model.DTO
{
    /// <summary>
    /// 公共类 返回  Id 和 Name
    /// </summary>
    [NotMapped]
    public class IdName
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }

    [NotMapped]
    public class IdName2 : IdName
    {
        /// <summary>
        /// 分类Id
        /// </summary>
        public int FId { get; set; }
    }
    /// <summary>
    /// 分组统计类
    /// </summary>
    [NotMapped]
    public class GroupCount
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class IdAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Default { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Tags { get; set; }
    }


}
