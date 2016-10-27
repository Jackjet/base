/****************************************************** 

    文件名称：RedisCacheBuilder.cs
    功能描述：Redis缓存操作
    作    者：Jxw
    日    期：2016.04.19
    修改记录：

*******************************************************/

using System;
using StackExchange.Redis;
using Newtonsoft.Json;
//using StackExchange.Redis.Extensions.Newtonsoft;

namespace Conan.Core.Cache
{
    /// <summary>
    /// Redis缓存操作
    /// </summary>
    public class RedisCacheBuilder : ICacheBuilder
    {
        static ConnectionMultiplexer _redisConnection = null;    //redis ConnectionMultiplexer

        /// <summary>
        /// redis ConnectionMultiplexer
        /// </summary>
        public ConnectionMultiplexer RedisConnection
        {
            get
            {
                if (_redisConnection == null)
                {
                    var options = ConfigurationOptions.Parse(ZConfig.GetConfigString("redispath"));
                    options.SyncTimeout = int.MaxValue;
                    options.AllowAdmin = false;
                    if (!string.IsNullOrWhiteSpace(ZConfig.GetConfigString("redispwd")))
                        options.Password = ZConfig.GetConfigString("redispwd");

                    return _redisConnection = ConnectionMultiplexer.Connect(options);
                }
                else
                    return _redisConnection;
            }
        }

        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public bool Exist(string key, string prefix = "")
        {
            try
            {
                IDatabase db = RedisConnection.GetDatabase();
                return db.KeyExists(MergeKey(key, prefix));
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="prefix">前缀</param>
        public void Remove(string key, string prefix = "")
        {
            try
            {
                IDatabase db = RedisConnection.GetDatabase();
                db.KeyDelete(MergeKey(key, prefix));
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
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
            try
            {
                IDatabase db = RedisConnection.GetDatabase();
                if (db.KeyExists(MergeKey(key, prefix)))
                {
                    string result = db.StringGet(MergeKey(key, prefix));
                    return JsonConvert.DeserializeObject<T>(result);
                }
                return default(T);

            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return default(T);
            }
        }



        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">超时时间（按分钟）</param>
        /// <param name="prefix">前缀</param>
        public virtual bool Set(string key, object data, string prefix = "", int cacheTime = 0)
        {
            try
            {
                TimeSpan? t = null;
                if (cacheTime > 0)
                    t = new TimeSpan(0, cacheTime, 0);

                IDatabase db = RedisConnection.GetDatabase();
                return db.StringSet(MergeKey(key, prefix), JsonConvert.SerializeObject(data), t);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }
        }



        /// <summary>
        /// 合并key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        protected string MergeKey(string key, string prefix = "")
        {
            if (!string.IsNullOrWhiteSpace(prefix))
                return string.Format("{0}:{1}", prefix, key);
            else
                return key;
        }
    }
}