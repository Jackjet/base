using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    /// <summary>
    /// 分页返回数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T>
    {
        public int ItemCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount
        {
            get
            {
                try
                {
                    int m = ItemCount % PageSize;
                    if (m == 0)
                        return ItemCount / PageSize;
                    else
                        return ItemCount / PageSize + 1;
                }
                catch {
                    return 0;
                }
            }
        }

        public List<T> Data { get; set; }
    }

    /// <summary>
    /// 分页返回数据
    /// </summary>
    /// <typeparam name="dynamic">动态类型</typeparam>
    public class PagedynamicResult<dynamic>
    {
        public int ItemCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount
        {
            get
            {
                try
                {
                    int m = ItemCount % PageSize;
                    if (m == 0)
                        return ItemCount / PageSize;
                    else
                        return ItemCount / PageSize + 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public List<dynamic> Data { get; set; }
    }
}
