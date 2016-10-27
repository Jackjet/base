/****************************************************** 

    文件名称：MemberBLL.cs
    功能描述：会员管理
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
    /// 会员管理
    /// </summary>
    public class MemberBLL : BaseBll<Member>
    {
        #region 构造函数
        private static MemberBLL instance;
        public static MemberBLL GetInstance()
        {
            if (instance == null)
                instance = new MemberBLL();

            return instance;
        }
        #endregion

      
    }
}
