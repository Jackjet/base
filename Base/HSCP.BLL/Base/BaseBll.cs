//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：逻辑基础类  对基础逻辑的数据操作   缓存处理进行封装
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.04.16
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Conan.Core;
using Conan.Core.Cache;
using Conan.DAL;
using Conan.Utils;
using System.Linq.Expressions;

namespace Conan.BLL
{
    /// <summary>
    /// 逻辑基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseBll<T> where T : class, IEntity, new()
    {
        #region 数据库操作

        /// <summary>
        /// linq 操作  IQueryable<T> Table() 主要是 select 查询
        /// </summary>
        /// <param name="repository">连接对象 默认为空</param>
        /// <returns> IQueryable<T> </returns>
        public virtual IQueryable<T> Table(IRepository<T> repository = null)
        {
            if (repository == null) repository = DalContext.Repository<T>();
            return repository.Table;
        }

        /// <summary>
        /// linq 操作  IQueryable<T> TableNoTracking() 主要是 select 查询
        /// </summary>
        /// <param name="repository">连接对象 默认为空</param>
        /// <returns> IQueryable<T> </returns>
        public virtual IQueryable<T> TableNoTracking(IRepository<T> repository = null)
        {
            if (repository == null) repository = DalContext.Repository<T>();
            return repository.TableNoTracking;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="obj">实体对象</param>
        ///  <param name="DU">内存事务对象  默认为空</param>
        public virtual void Add(T obj, UnitWork DU = null)
        {
            IRepository<T> repository = null;
            if (DU != null)
            {
                repository = DU.Get<T>();
            }
            else
            {
                repository = DalContext.Repository<T>();
            }
            repository.Insert(obj);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="obj">要修改实体对象</param>
        /// <param name="repository"> 非内存事务修改   定义BaseRepository<T> 先get对象 在修改对象 最后把定义的BaseRepository<T>传进来</param>
        /// <param name="DU">事务对象-  内存事务修改  非事务修改 为空</param>
        public virtual void Update(T obj, IRepository<T> repository = null, UnitWork DU = null)
        {
            IRepository<T> objRepository = null;
            if (repository == null && DU == null)
                objRepository = DalContext.Repository<T>();
            else
            {
                if (repository != null)
                {
                    objRepository = repository;
                }
                if (DU != null)
                {
                    objRepository = DU.Get<T>();
                }
            }
            objRepository.Update(obj);
        }


        /// <summary>
        /// Get 实体对象
        /// </summary>
        /// <param name="ID">主键id</param>
        /// <param name="repository">  链接对象 BaseRepository<T> 非内存事务修改数据的时候需要    其他为空</param>
        /// <param name="DU">事务对象-  内存事务修改使用  其他为空</param>
        /// <returns>返回获取的实体对象</returns>
        public virtual T Get(object ID, IRepository<T> repository = null, UnitWork DU = null)
        {
            IRepository<T> objRepository = null;
            if (repository != null)
            {
                objRepository = repository;
            }
            else if (repository == null && DU == null)
            {
                objRepository = DalContext.Repository<T>();
            }
            else if (DU != null)
            {
                objRepository = DU.Get<T>();
            }
            return objRepository.Get(ID);
        }

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="ID">主键id</param>
        /// <param name="DU">内存事务对象 默认为空</param>
        public virtual void Delete(object ID, UnitWork DU = null)
        {
            IRepository<T> objRepository = null;
            if (DU != null)
            {
                objRepository = DU.Get<T>();
            }
            else
            {
                objRepository = DalContext.Repository<T>();
            }
            var obj = objRepository.Get(ID);
            if (obj != null)
            {
                objRepository.Delete(obj);
            }
        }


        /// <summary>
        /// 执行 sql 返回对象 （实体、list）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlp">参数列表</param>
        ///  <param name="DU">内存事务对象 默认为空  内存事务的时候 需要传入参数</param>
        /// <returns>对象类型数据</returns>
        public virtual T[] SqlQuery(string sql, List<SqlParameter> sqlp, UnitWork DU = null)
        {
            IRepository<T> objRepository = null;
            if (DU != null)
            {
                objRepository = DU.Get<T>();
            }
            else
            {
                objRepository = DalContext.Repository<T>();
            }
            return objRepository.SqlQuery(sql, sqlp);
        }

        /// <summary>
        ///  SQL 语句返回 dataTable
        /// </summary>
        /// <param name="sql">sql语句   </param>
        /// <param name="parameters">参数列表</param>
        ///  <param name="DU">内存事务对象 默认为空  内存事务的时候 需要传入参数</param>
        /// <returns></returns>
        public virtual DataTable SqlQueryForDataTatable(string sql, List<SqlParameter> sqlp, UnitWork DU = null)
        {
            IRepository<T> objRepository = null;
            if (DU != null)
            {
                objRepository = DU.Get<T>();
            }
            else
            {
                objRepository = DalContext.Repository<T>();
            }
            return objRepository.SqlQueryForDataTatable(sql, sqlp);
        }




        /// <summary>
        /// EF SQL 语句返回 单个对象数据  sting  int 
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数列表</param>
        ///  <param name="DU">内存事务对象 默认为空  内存事务的时候 需要传入参数</param>
        /// <returns></returns>
        public virtual object SqlQueryForScalar(string sql, List<SqlParameter> sqlp, UnitWork DU = null)
        {
            IRepository<T> objRepository = null;
            if (DU != null)
            {
                objRepository = DU.Get<T>();
            }
            else
            {
                objRepository = DalContext.Repository<T>();
            }
            return objRepository.SqlQueryForScalar(sql, sqlp);
        }



        /// <summary>
        /// 执行 sql 返回影响行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlp">参数列表</param>
        ///  <param name="DU">内存事务对象 默认为空  内存事务的时候 需要传入参数</param>
        /// <returns>影响行数</returns>
        public virtual int ExecuteSqlCommand(string sql, List<SqlParameter> sqlp, UnitWork DU = null)
        {
            IRepository<T> objRepository = null;
            if (DU != null)
            {
                objRepository = DU.Get<T>();
            }
            else
            {
                objRepository = DalContext.Repository<T>();
            }


            return objRepository.ExecuteSqlCommand(sql, sqlp);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="data">分页数据</param>
        /// <param name="count">总条数</param>
        /// <param name="sqlp">参数</param>
        /// <returns>实体列表数据</returns>
        public virtual List<T> GetQueryManyForPage(SelectBuilderData data, out int count, List<SqlParameter> sqlp)
        {
            List<SqlParameter> temp = new List<SqlParameter>();
            string sqlStr = SqlServerProvider.GetSqlForSelectBuilder(data);
            string sqlStr2 = SqlServerProvider.GetSqlForTotalBuilder(data);
            object totalCount = SqlQueryForScalar(sqlStr2, sqlp);
            count = ZConvert.StrToInt(totalCount, 0);
            return SqlQuery(sqlStr, sqlp).ToList<T>();
        }

        #endregion

        #region 缓存操作
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="region">前缀</param>
        /// <returns></returns>
        public virtual Tentity GetCache<Tentity>(string key, string prefix)
        {
            ICacheBuilder ICacheBuilder = new RedisCacheBuilder();
            Tentity obj = ICacheBuilder.Get<Tentity>(key, prefix);
            return obj;
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">超时时间（按分钟） 0  标示永久</param>
        /// <param name="region">前缀</param>
        public virtual bool SetCache(string key, object data, string prefix, int cacheTime = 0)
        {
            ICacheBuilder ICacheBuilder = new RedisCacheBuilder();
            bool IsSuccess = ICacheBuilder.Set(key, data, prefix, cacheTime);
            return IsSuccess;

        }



        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="region">前缀</param>
        /// <returns></returns>
        public virtual bool ExistCache(string key, string prefix)
        {
            ICacheBuilder ICacheBuilder = new RedisCacheBuilder();
            bool IsSuccess = ICacheBuilder.Exist(key, prefix);
            return IsSuccess;

        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="region">前缀</param>
        public virtual void RemoveCache(string key, string prefix)
        {
            ICacheBuilder ICacheBuilder = new RedisCacheBuilder();
            ICacheBuilder.Remove(key, prefix);

        }
        #endregion

        #region linq 分页
        /// <summary>
        /// linq 分页
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="whereQuery">条件</param>
        /// <param name="orderQuery">排序</param>
        /// <param name="pageID">页码</param>
        /// <param name="pageSizes">每页条数</param>
        ///   /// <param name="selector">查询字段 默认 为空 全部</param>
        /// <returns></returns>
        public virtual PagedynamicResult<dynamic> GetLinqPage<TKey>(Expression<Func<T, bool>> whereQuery, QueryableOrderEntry<T, TKey> orderQuery, int pageID, int pageSizes, Expression<Func<T, dynamic>> selector = null)
        {
            //  pageID = pageID < 1 ? 0 : pageID - 1;
            List<dynamic> data = new List<dynamic>();
            IRepository<T> repository = DalContext.Repository<T>();
            var query = repository.TableNoTracking.Where(whereQuery);
            int count = query.Count();
            if (selector != null)
            {
                if (orderQuery.OrderDirection == OrderDirection.DESC)
                {
                    data = query.OrderByDescending(orderQuery.Expression).Select(selector)
                        .Skip(pageSizes * pageID)
                        .Take(pageSizes).ToList();
                }
                else
                {
                    data = query
                        .OrderBy(orderQuery.Expression).Select(selector)
                        .Skip(pageSizes * pageID)
                        .Take(pageSizes).ToList();
                }
            }
            else
            {
                if (orderQuery.OrderDirection == OrderDirection.DESC)
                {
                    data = query.OrderByDescending(orderQuery.Expression)
                        .Skip(pageSizes * pageID)
                        .Take(pageSizes).ToList<dynamic>();
                }
                else
                {
                    data = query
                        .OrderBy(orderQuery.Expression)
                        .Skip(pageSizes * pageID)
                        .Take(pageSizes).ToList<dynamic>();
                }
            }


            return new PagedynamicResult<dynamic> { Data = data, ItemCount = count, PageSize = pageSizes, PageIndex = pageID + 1 };
        }



        public virtual PageResult<dynamic> PageFind<TOrderByKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereQuery, QueryableOrderEntry<T, TOrderByKey> orderQuery, Expression<Func<T, dynamic>> selector = null)
        {
            List<dynamic> data = new List<dynamic>();
            IRepository<T> repository = DalContext.Repository<T>();
            var query = repository.TableNoTracking.Where(whereQuery);
            int count = query.Count();

            if (orderQuery.OrderDirection == OrderDirection.DESC)
                query = query.OrderByDescending(orderQuery.Expression);
            else
                query = query.OrderBy(orderQuery.Expression);

            if (selector != null)
                data = query.Select(selector).Skip(pageSize * pageIndex).Take(pageSize).ToList();
            else
                data = query.Skip(pageSize * pageIndex).Take(pageSize).ToList<dynamic>();

            return new PageResult<dynamic> { ItemCount = count, Data = data };
        }

        public virtual PageResult<TResult> PageData<TResult, TOrderKey>(int pageIndex, int pageSize, Expression<Func<TResult, bool>> whereQuery, QueryableOrderEntry<TResult, TOrderKey> orderQuery, Expression<Func<T, TResult>> selector)
        {
            List<TResult> data = new List<TResult>();

            var query = DalContext.Repository<T>().TableNoTracking.Select(selector).Where(whereQuery);
            int count = query.Count();

            if (orderQuery.OrderDirection == OrderDirection.DESC)
                query = query.OrderByDescending(orderQuery.Expression);
            else
                query = query.OrderBy(orderQuery.Expression);

            data = query.Skip(pageSize * pageIndex).Take(pageSize).ToList();

            return new PageResult<TResult> { ItemCount = count, Data = data };
        }
        #endregion

    }
}
