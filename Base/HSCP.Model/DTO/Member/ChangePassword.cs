using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class ChangePassword
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// 新秘密
        /// </summary>
        public string NewPassword { get; set; }
      
    }
}
