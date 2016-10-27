using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Conan.Core
{
    public class Utility
    {
        /// <summary>
        /// 订单号转手签保存路径
        /// </summary>
        /// <param name="NO"></param>
        public static string SignaturePath(string NO)
        {
            string SignedPath = ZConfig.GetConfigString("SignedPath");
            return Path.Combine(SignedPath, NO.Substring(0, 2), NO.Substring(2, 2), NO.Substring(4, 2), NO.Substring(5, (NO.Length - 1) - 5) + ".jpg");
        }
    }
}
