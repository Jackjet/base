/****************************************************** 

    文件名称：Repository.cs
    功能描述：IRepository接口的实现
    作    者：Jxw
    日    期：2016.04.19
    修改记录：

*******************************************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data;
using System.Linq;
using Conan.Core;

namespace Conan.DAL
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private bool _useUnitWork = false; //readonly
        private IDbSet<T> _entities;
        protected readonly DbContext Context;

        public Repository(IDbContext context, bool useUnitWrok = true)
        {
            this.Context = context as DbContext;
            this._useUnitWork = useUnitWrok;
        }

        public virtual void IsUseUnitWrok(bool useUnitWrok = true)
        {
            this._useUnitWork = useUnitWrok;
        }

        protected virtual IDbSet<T> Entities => _entities ?? (_entities = Context.Set<T>());

        public virtual T Get(object id)
        {
            return this.Entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                var r = this.Entities.Add(entity);

                if (!_useUnitWork)
                    this.Context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public T InsertNoUnitWork(T entity)
        {
            try
            {
                if (_useUnitWork)
                    throw new Exception("The current method does not allow the UnitWork pattern");

                if (entity == null)
                    throw new ArgumentNullException("entity");

                var r = this.Entities.Add(entity);

                this.Context.SaveChanges();

                return r;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");


                //var entry = this.Context.Entry(entity);
                //this.Context.Set<T>().Attach(entity);
                //entry.State = EntityState.Modified;

                if (!_useUnitWork)
                    this.Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}"
                            , validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);

                if (!_useUnitWork)
                    this.Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }
        public virtual IQueryable<T> Table => this.Entities;
        public virtual IQueryable<T> TableNoTracking => this.Entities.AsNoTracking();

        /// <summary>
        /// 执行sql 返回集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlp"></param>
        /// <returns></returns>
        public virtual T[] SqlQuery(string sql, List<SqlParameter> sqlp)
        {
          
            if (sqlp == null)
                return Context.Database.SqlQuery<T>(sql).ToArray();
            else
                return Context.Database.SqlQuery<T>(sql, sqlp.ToArray()).ToArray();
        }

        /// <summary>
        /// 执行sql 返回int 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlp"></param>
        /// <returns></returns>
        public virtual int ExecuteSqlCommand(string sql, List<SqlParameter> sqlp)
        {
            if (sqlp == null)
                return Context.Database.ExecuteSqlCommand(sql);
            else
                return Context.Database.ExecuteSqlCommand(sql, sqlp.ToArray());
        }

        /// <summary>
        /// EF SQL 语句返回 dataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual DataTable SqlQueryForDataTatable(string sql, List<SqlParameter> sqlp)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = Context.Database.Connection.ConnectionString;
            try
            {
               
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                if (sqlp.Count > 0 )
                {
                    foreach (var item in sqlp)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                cmd.CommandTimeout = 180;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                cmd.Parameters.Clear();
                return table;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
           
        }

        /// <summary>
        /// EF SQL 语句返回 单个对象数据  sting  int 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual object SqlQueryForScalar(string sql, List<SqlParameter> sqlp)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = Context.Database.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            if (sqlp.Count > 0)
            {
                foreach (var item in sqlp)
                {
                    cmd.Parameters.Add(item);
                }
            }
            object obj = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return obj;
        }
    }
}