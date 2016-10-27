using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Utils
{
    public class Common
    {
        /// <summary>
        /// 执行线程异步回调方法
        /// 内部发生异常IIS不受影响 
        /// </summary>
        /// <param name="call">异步回调方法</param>
        /// <param name="par">回调方法的传入参数</param>
        public static void RunAsyn(System.Threading.WaitCallback call, object par)
        {
            call.BeginInvoke(par, null, null);
        }

    }
}
