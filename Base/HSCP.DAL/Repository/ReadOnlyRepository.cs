using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Core;
using PetaPoco;


namespace Conan.DAL
{
    public class ReadOnlyRepository
    {
        Database _db;

        public ReadOnlyRepository(string connectionStringName= "Xiaoyujia")
        {
            _db = new Database(connectionStringName);
        }


        public static Sql SqlBuilder()
        {
            return Sql.Builder;
        }

        public T ExecuteScalar<T>(Sql sql)
        {
            T t = _db.ExecuteScalar<T>(sql);
            NLogger.Debug(_db.LastCommand, "PetaPoco ExecuteScalar");
            return t;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex">从1开始</param>
        /// <param name="pageSize"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Page<T> Page<T>(int pageIndex, int pageSize, Sql sql)
        {
            Page<T> page = _db.Page<T>(pageIndex, pageSize, sql);
            NLogger.Debug(_db.LastCommand, "PetaPoco Page");
            return page;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(Sql sql)
        {
            IEnumerable<T> data = _db.Query<T>(sql);
            NLogger.Debug(_db.LastCommand, "PetaPoco Query");
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, params object[] args)
        {
            IEnumerable<T> data = _db.Query<T>(sql, args);
            NLogger.Debug(_db.LastCommand, "PetaPoco Query");
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> Fetch<T>(Sql sql)
        {
            List<T> data = _db.Fetch<T>(sql);
            NLogger.Debug(_db.LastCommand, "PetaPoco Fetch");
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public List<T> Fetch<T>(string sql, params object[] args)
        {
            List<T> data = _db.Fetch<T>(sql, args);
            NLogger.Debug(_db.LastCommand, "PetaPoco Fetch");
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T FirstOrDefault<T>(Sql sql)
        {
            T t = _db.FirstOrDefault<T>(sql);
            NLogger.Debug(_db.LastCommand, "PetaPoco FirstOrDefault");
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public T FirstOrDefault<T>(string sql, params object[] args)
        {
            T t = _db.FirstOrDefault<T>(sql, args);
            NLogger.Debug(_db.LastCommand, "PetaPoco FirstOrDefault");
            return t;
        }

        public IGridReader QueryMultiple(Sql sql)
        {
            IGridReader grs = _db.QueryMultiple(sql);

            NLogger.Debug(_db.LastCommand, "PetaPoco FirstOrDefault");
            return grs;
        }

        public void Dispose()
        {
            ((IDisposable)_db).Dispose();
        }
    }
}
