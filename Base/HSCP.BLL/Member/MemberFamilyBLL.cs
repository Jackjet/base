/****************************************************** 

    文件名称：MemberFamilyBLL.cs
    功能描述：会员家庭信息
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
    /// 会员家庭信息
    /// </summary>
    public class MemberFamilyBLL : BaseBll<MemberFamilyInfo>
    {
        #region 构造函数
        private static MemberFamilyBLL instance;
        public static MemberFamilyBLL GetInstance()
        {
            if (instance == null)
                instance = new MemberFamilyBLL();

            return instance;
        }
        #endregion

      
    }
}
