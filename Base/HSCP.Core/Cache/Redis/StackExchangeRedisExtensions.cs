//*************************** 
//文件名称(File Name)： StackExchangeRedisExtensions.cs
//功能描述(Description)：redis 缓存操作类
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
using System.Threading.Tasks;
using Conan.Core;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace Conan.Core.Cache
{
    /// <summary>
    /// redis 缓存操作类
    /// </summary>
	public static class StackExchangeRedisExtensions
    {
        #region 主键key查找
        /// <summary>
        /// 主键key查找
        /// </summary>
        /// <param name="key">关键字</param>
        public static List<string> GetByKey(string key)
        {
            List<string> result = new List<string>();
            try
            {

                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    string host = ZConfig.GetConfigString("redispath");
                    var server = redis.GetServer(host);

                    foreach (var item in server.Keys(pattern: key))
                    {
                        result.Add(item);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return new List<string>();
            }
        }
        #endregion

        #region 设置缓存 string
        /// <summary>
        /// 设置缓存 string
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="t">过期时间(分钟)</param>
        public static bool Set(string key, string value, int i)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    TimeSpan t = new TimeSpan(0, i, 0);
                    IDatabase db = redis.GetDatabase();
                    return db.StringSet(key, value, t);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }
        }
        #endregion

        #region 设置缓存 T
        /// <summary>
        /// 设置缓存 T
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="t">过期时间(分钟)</param>
        public static bool Set<T>(string key, T value, int i)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    TimeSpan t = new TimeSpan(0, i, 0);
                    IDatabase db = redis.GetDatabase();
                    var jsonString = JsonHelper.SerializeObject(value);
                    return db.StringSet(key, jsonString, t);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }

        }
        #endregion

        #region 设置缓存 List<T>
        /// <summary>
        /// 设置缓存 List<T>
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="t">过期时间(分钟)</param>
        public static bool SetList<T>(string key, List<T> value, int i)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    TimeSpan t = new TimeSpan(0, i, 0);
                    IDatabase db = redis.GetDatabase();
                    var jsonString = JsonHelper.SerializeObject(value);
                    return db.StringSet(key, jsonString, t);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }
        }

        #endregion

        #region 设置缓存 string  （永久） 
        /// <summary>
        /// 设置缓存  （永久）
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        public static bool Set(string key, string value)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    return db.StringSet(key, value);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }

        }
        #endregion

        #region 设置缓存 T  （永久）
        /// <summary>
        /// 设置缓存  （永久）
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        public static bool Set<T>(string key, T value)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {

                    IDatabase db = redis.GetDatabase();
                    var jsonString = JsonHelper.SerializeObject(value);
                    return db.StringSet(key, jsonString);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }

        }
        #endregion

        #region 设置缓存  List<T>（永久）
        /// <summary>
        /// 设置缓存  List<T>（永久）
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        public static bool SetList<T>(string key, List<T> value)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    var jsonString = JsonHelper.SerializeObject(value);
                    return db.StringSet(key, jsonString);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }
        }
        #endregion

        #region 读取缓存 object
        /// <summary>
        /// 读取缓存 object
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    return db.StringGet(key);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return null;
            }

        }
        #endregion

        #region 读取缓存 T

        /// <summary>
        /// 读取缓存 T
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    string result = db.StringGet(key);
                    var empty = JsonHelper.DeserializeObject<T>(result);
                    return empty;
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return default(T);
            }

        }
        #endregion

        #region 读取缓存 List<T> 

        /// <summary>
        /// 读取缓存 List<T> 
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public static List<T> GetList<T>(string key)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    string result = db.StringGet(key);
                    var empty = JsonHelper.DeserializeObject<List<T>>(result);
                    return empty;
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return null;
            }

        }
        #endregion

        #region 删除缓存
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">主键</param>
        public static bool Delete(string key)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    return db.KeyDelete(key);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }

        }
        /// <summary>
        /// 删除多个key
        /// </summary>
        /// <param name="keys">rediskey</param>
        /// <returns>成功删除的个数</returns>
        public static long keyDelete(RedisKey[] keys)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    return db.KeyDelete(keys);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return 0;
            }

        }

        #endregion

        #region 计数器  +
        /// <summary>
        ///  计数器  +
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="i">值</param>
        public static long Increment(string key, int i)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    return db.StringIncrement(key, i);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return 0;
            }

        }
        #endregion

        #region 计数器 -

        /// <summary>
        /// 计数器 -
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="i">值</param>
        public static long Decrement(string key, int i)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    return db.StringDecrement(key, i);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return 0;
            }

        }
        #endregion

        #region SortedSet 添加
        /// <summary>
        /// SortedSet 添加
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="key">主键</param>
        /// <param name="value">实体值</param>
        /// <param name="score">排序值</param>
        /// <returns></returns>
        public static bool SortedSetAdd<T>(string key, T value, double score)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    var jsonString = JsonHelper.SerializeObject(value);
                    return db.SortedSetAdd(key, jsonString, score);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");
                return false;
            }

        }
        #endregion

        #region SortedSet  移除  某项

        /// <summary>
        /// SortedSet  移除  某项
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="key">主键</param>
        /// <param name="value">实体值</param>
        /// <returns></returns>
        public static bool SortedSetRemove<T>(string key, T value)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    var jsonString = JsonHelper.SerializeObject(value);
                    return db.SortedSetRemove(key, jsonString);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return false;
            }

        }
        #endregion

        #region SortedSet  排序 获取
        /// <summary>
        /// SortedSet  排序 获取
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="key">主键</param>
        /// <param name="start">开始  默认 0</param>
        /// <param name="end">结束 默认-1 </param>
        /// <param name="order">排序 默认降序</param>
        /// <returns></returns>
        public static List<T> SortedSetRangeByRank<T>(string key, int start = 0, int end = -1, Order order = Order.Descending)
        {
            try
            {

                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    var list = db.SortedSetRangeByRank(key, start, end, order);
                    if (list != null && list.Length > 0)
                    {
                        List<T> result = new List<T>();
                        foreach (var item in list)
                        {
                            var data = JsonHelper.DeserializeObject<T>(item.ToString());
                            result.Add(data);
                        }
                        return result;
                    }
                    return null;
                }

            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return null;
            }


        }
        #endregion

        #region 过期 (时间)
        /// <summary>
        /// 过期 (时间)
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="expiry">时间</param>
        /// <returns></returns>
        public static bool KeyExpire(string key, DateTime expiry)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    return db.KeyExpire(key, expiry);
                }

            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return false;
            }

        }
        #endregion

        #region 过期  分钟数
        /// <summary>
        /// 过期
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="i">分钟数</param>
        /// <returns></returns>
        public static bool KeyExpire(string key, int i)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    TimeSpan t = new TimeSpan(0, i, 0);
                    return db.KeyExpire(key, t);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return false;
            }

        }
        #endregion

        #region Hash  添加
        /// <summary>
        ///  Hash  添加
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="key">主键</param>
        /// <param name="hashField">字段主键</param>
        /// <param name="value">实体值</param>
        /// <returns></returns>
        public static bool HashSet<T>(string key, string hashField, T value)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    var jsonString = JsonHelper.SerializeObject(value);
                    return db.HashSet(key, hashField, jsonString);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return false;
            }

        }

        #endregion

        #region Hash  删除 
        /// <summary>
        ///  Hash  删除 
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="hashField">字段主键</param>
        /// <returns></returns>
        public static bool HashDelete(string key, string hashField)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    return db.HashDelete(key, hashField);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return false;
            }

        }
        #endregion

        #region Hash 指定的项 是否存在
        /// <summary>
        /// 指定的项 是否存在
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="hashField">字段主键</param>
        /// <returns></returns>
        public static bool HashExists(string key, string hashField)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();

                    return db.HashExists(key, hashField);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return false;
            }

        }
        #endregion

        #region 获取Hash中的单个key的值
        /// <summary>
        /// 获取Hash中的单个key的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="hasFildValue">RedisValue</param>
        /// <returns></returns>
        public static T GetHashKey<T>(string key, string hasFildValue)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();

                    if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(hasFildValue))
                    {
                        RedisValue value = db.HashGet(key, hasFildValue);
                        if (!value.IsNullOrEmpty)
                        {
                            return JsonConvert.DeserializeObject<T>(value);
                        }
                    }
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return default(T);
            }
        }
        #endregion

        #region 获取hash中的多个key的值
        /// <summary>
        /// 获取hash中的多个key的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="listhashFields">RedisValue value</param>
        /// <returns></returns>
        public static List<T> GetHashKey<T>(string key, List<RedisValue> listhashFields)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();


                    List<T> result = new List<T>();
                    if (!string.IsNullOrWhiteSpace(key) && listhashFields.Count > 0)
                    {
                        RedisValue[] value = db.HashGet(key, listhashFields.ToArray());
                        foreach (var item in value)
                        {
                            if (!item.IsNullOrEmpty)
                            {
                                result.Add(JsonConvert.DeserializeObject<T>(item));
                            }
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return null;
            }
        }

        #endregion

        #region 获取hashkey所有Redis key
        /// <summary>
        /// 获取hashkey所有Redis key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<T> GetHashAll<T>(string key)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                  //  db.HashScan
                    List<T> result = new List<T>();
                    RedisValue[] arr = db.HashKeys(key);
                    foreach (var item in arr)
                    {
                        if (!item.IsNullOrEmpty)
                        {
                            result.Add(JsonConvert.DeserializeObject<T>(item));
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return null;
            }
        }

        #endregion

        #region 获取hashkey所有的值
        /// <summary>
        /// 获取hashkey所有的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<T> HashGetAll<T>(string key)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    List<T> result = new List<T>();
                    HashEntry[] arr = db.HashGetAll(key);
                    foreach (var item in arr)
                    {
                        if (!item.Value.IsNullOrEmpty)
                        {
                            result.Add(JsonConvert.DeserializeObject<T>(item.Value));
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return null;
            }
        }

        #endregion

        #region 追加值
        /// <summary>
        /// 追加值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static long StringAppend(string key, string value)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();
                    ////追加值，返回追加后长度
                    long appendlong = db.StringAppend(key, value);
                    return appendlong;
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return 0;
            }
        }
        #endregion

        #region 重新命名key
        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        public static bool KeyRename(string key, string newKey)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();

                    return db.KeyRename(key, newKey);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return false;
            }
        }
        #endregion

        #region 判断key是否存储
        /// <summary>
        /// 判断key是否存储
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns></returns>
        public static bool KeyExists(string key)
        {
            try
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(GetConn.GetInstance().Conn()))
                {
                    IDatabase db = redis.GetDatabase();

                    return db.KeyExists(key);
                }
            }
            catch (Exception ex)
            {
                NLogger.Error(ex.ToString(), "Cache");

                return false;
            }
        }
        #endregion
    }
    /// <summary>
    /// 连接信息
    /// </summary>
	public class GetConn
    {
        #region 构造函数

        private static GetConn _instance;
        public static GetConn GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GetConn();
            }
            return _instance;
        }

        #endregion

        #region 连接串
        /// <summary>
        /// 连接串
        /// </summary>
        /// <returns></returns>
        public ConfigurationOptions Conn()
        {
            var options = ConfigurationOptions.Parse(ZConfig.GetConfigString("redispath"));
            options.SyncTimeout = int.MaxValue;
            options.AllowAdmin = true;
            options.Password = ZConfig.GetConfigString("redispwd");
            return options;
        }
        #endregion
    }
}