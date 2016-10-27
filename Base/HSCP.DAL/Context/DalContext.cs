using System;
using System.Collections.Generic;
using System.Linq;
using Conan.Core;

namespace Conan.DAL
{

    public class DalContext
    {
        public static IRepository<T> Repository<T>(string nameOrConnectionString = "Xiaoyujia")
            where T : class, IEntity, new()
        {
            return new Repository<T>(new EfDbContext(nameOrConnectionString), false);
        }

        public static UnitWork UnitWork(string nameOrConnectionString = "Xiaoyujia")
        {
            return new UnitWork(new EfDbContext(nameOrConnectionString));
        }

        public static void DataBaseInit()
        {
            //System.Data.Entity.Database.SetInitializer<EfDbContext>(new CreateDatabaseIfNotExists());
        }
    }
}
