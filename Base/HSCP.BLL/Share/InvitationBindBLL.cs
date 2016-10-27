using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using Conan.Core;
  
namespace Conan.BLL
{
    /// <summary>
    /// 领取邀请明细
    /// </summary>
    public class InvitationBindBLL : BaseBll<InvitationBind>
    {
        #region 构造函数
        private static InvitationBindBLL instance;
        public static InvitationBindBLL GetInstance()
        {
            if (instance == null)
                instance = new InvitationBindBLL();

            return instance;
        }
        #endregion

      
    }
}
