/****************************************************** 

    文件名称：MemoryCacheManager.cs
    功能描述：内存缓存操作类
    作    者：Jxw
    日    期：2016.04.19
    修改记录：

*******************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace Conan.Core.Cache
{
    /// <summary>
    /// 内存缓存操
    /// </summary>
    public class MemoryCacheBuilder : ICacheBuilder
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public virtual T Get<T>(string key, string prefix = "")
        {
            return (T)Cache[MergeKey(key, prefix)];
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">超时时间（按分钟）</param>
        /// <param name="prefix">前缀</param>
        public virtual bool Set(string key, object data,  string prefix = "", int cacheTime = 0)
        {
            if (data == null) return false;

            CacheItemPolicy policy = null;
            if (cacheTime > 0) policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime) };

            Cache.Set(new CacheItem(MergeKey(key, prefix), data), policy);

            return true;
        }

        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public virtual bool Exist(string key, string prefix = "")
        {
            return (Cache.Contains(MergeKey(key, prefix)));
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="prefix">前缀</param>
        public virtual void Remove(string key, string prefix = "")
        {
            Cache.Remove(MergeKey(key, prefix));
          //  return true;
        }

        /// <summary>
        /// 移除匹配的缓存
        /// </summary>
        /// <param name="pattern"></param>
        public virtual bool RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }

            return true;
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }

        /// <summary>
        /// 合并key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        string MergeKey(string key, string prefix)
        {
            if (!string.IsNullOrWhiteSpace(prefix))
                return string.Format("{0}:{1}", prefix, key);
            else
                return key;
        }
    }
}
