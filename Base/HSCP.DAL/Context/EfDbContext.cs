using System.Data.Entity;
using System.Reflection;
using Conan.Core;

namespace Conan.DAL
{
    public class EfDbContext : DbContext, IDbContext
    {

        public EfDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = false;
            base.Database.Log = (sql) =>
            {
                NLogger.Debug(sql);
            };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.Load("Conan.DAL"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
