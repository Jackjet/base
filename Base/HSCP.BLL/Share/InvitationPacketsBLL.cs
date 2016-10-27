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
    /// 邀请
    /// </summary>
    public class InvitationPacketsBLL : BaseBll<InvitationPackets>
    {
        #region 构造函数
        private static InvitationPacketsBLL instance;
        public static InvitationPacketsBLL GetInstance()
        {
            if (instance == null)
                instance = new InvitationPacketsBLL();

            return instance;
        }
        #endregion

      
    }
}
