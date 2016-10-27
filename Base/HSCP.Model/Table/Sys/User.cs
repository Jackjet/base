using System;
using HSCP.Core;

namespace HSCP.Model
{
    public partial class User : OtherEntity<int>
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string YourName { get; set; }
        public virtual string Telephone { get; set; }
        /// <summary>
        /// StoreId = null 为总部用户
        /// </summary>
        public virtual int? StoreId { get; set; }
        public virtual bool IsSys { get; set; }
        public virtual int State { get; set; }
    }
}