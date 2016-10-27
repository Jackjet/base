/****************************************************** 

    文件名称：ICacheBuilder.cs
    功能描述：缓存操作接口
    作    者：Jxw
    日    期：2016.04.19
    修改记录：

*******************************************************/

namespace Conan.Core.Cache
{
    public partial interface ICacheBuilder
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="region">前缀</param>
        /// <returns></returns>
        T Get<T>(string key, string prefix);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">超时时间（按分钟） 0  标示永久</param>
        /// <param name="region">前缀</param>
        bool Set(string key, object data,string prefix ,int cacheTime=0 );

        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="region">前缀</param>
        /// <returns></returns>
        bool Exist(string key, string prefix );

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="region">前缀</param>
        void Remove(string key, string prefix );

    }
}
