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
    /// 分享红包
    /// </summary>
    public class ShareRedPacketsBLL : BaseBll<ShareRedPackets>
    {
        #region 构造函数
        private static ShareRedPacketsBLL instance;
        public static ShareRedPacketsBLL GetInstance()
        {
            if (instance == null)
                instance = new ShareRedPacketsBLL();

            return instance;
        }
        #endregion

      
    }
}
