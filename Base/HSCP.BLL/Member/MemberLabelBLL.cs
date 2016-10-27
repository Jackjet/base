/****************************************************** 

    文件名称：MemberAddrBLL.cs
    功能描述：会员标签
    作    者：cyx
    日    期：2016.05.19
    修改记录：

*******************************************************/
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
    /// 会员标签
    /// </summary>
    public class MemberLabelBLL : BaseBll<MemberLabel>
    {
        #region 构造函数
        private static MemberLabelBLL instance;
        public static MemberLabelBLL GetInstance()
        {
            if (instance == null)
                instance = new MemberLabelBLL();

            return instance;
        }
        #endregion

      
    }
}
