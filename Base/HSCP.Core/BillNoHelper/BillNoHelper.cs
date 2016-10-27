//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：单据号生成类
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.04.16
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Conan.Core {
    /// <summary>
    /// 单号助手
    /// </summary>
    public class BillNoHelper
    {

        /// <summary>
        ///  防止创建类的实例
        /// </summary>
        private BillNoHelper() { }
        private static readonly object Locker = new object();
        private static int _sn = 0;
        /// <summary>
        /// 生成单据编号
        /// </summary>
        /// <returns></returns>
        public static string GenerateId()
        {
            lock (Locker)   //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
            {
                if (_sn == 9999)
                {
                    _sn = 1;
                }
                else
                {
                    _sn++;
                }
                return DateTime.Now.ToString("yyMMddHHmmss") + _sn.ToString().PadLeft(4, '0');
            }
        }
        /// <summary>
        /// 唯一值
        /// </summary>
        /// <returns></returns>
        public static string guid() {
			return Guid.NewGuid().ToString().Replace("-", "");
		}
        /// <summary>
        /// GuidExtension
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string IsNum( Guid guid)
        {
            var s = guid.ToString();
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsNumber(s, i))
                {
                    sb.Append(s.Substring(i, 1));
                }
            }
            return sb.ToString();
        }

    }
}