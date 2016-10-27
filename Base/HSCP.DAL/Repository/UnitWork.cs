/****************************************************** 

    文件名称：UnitWork.cs
    功能描述：工作单元
    作    者：Jxw
    日    期：2016.04.19
    修改记录：

*******************************************************/

using System;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using Conan.Core;

namespace Conan.DAL
{
    public class UnitWork : IUnitWork
    {
        public UnitWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly IDbContext _dbContext;

        public IRepository<T> Get<T>()
            where T : class, IEntity, new()
        {
            return new Repository<T>(_dbContext);
        }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg +=
                            string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                
                NLogger.Error(fail, fail.Message);
                throw fail;
            }
            finally
            {
                Dispose();
            }
        }

        public Task<int> CommitAsync()
        {
            try
            {
                return _dbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg +=
                            string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
            finally
            {
                Dispose();
            }
        }

        public void Rollback()
        {
            Dispose();
        }

        public void Dispose()
        {
                _dbContext.Dispose();
        }
    }
}
