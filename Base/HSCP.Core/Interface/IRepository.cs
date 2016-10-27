/****************************************************** 

    文件名称：IRepository.cs
    功能描述：IRepository
    作    者：Jxw
    日    期：2016.04.19
    修改记录：

*******************************************************/

using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Conan.Core
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Get(object id);
        void Insert(T entity);
        T InsertNoUnitWork(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }

        T[] SqlQuery(string sql, List<SqlParameter> sqlp);

        int ExecuteSqlCommand(string sql, List<SqlParameter> sqlp);

        DataTable SqlQueryForDataTatable(string sql, List<SqlParameter> sqlp);

        object SqlQueryForScalar(string sql, List<SqlParameter> sqlp);
    }
}
