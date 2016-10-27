/****************************************************** 

    文件名称：MemberBind.cs
    功能描述：会员  第三方 
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
    /// 会员  第三方
    /// </summary>
    public class MemberBindBLL : BaseBll<MemberBind>
    {
        #region 构造函数
        private static MemberBindBLL instance;
        public static MemberBindBLL GetInstance()
        {
            if (instance == null)
                instance = new MemberBindBLL();

            return instance;
        }
        #endregion

      
    }
}
