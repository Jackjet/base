using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using Conan.Core;

namespace Conan.DAL
{
    public sealed class CreateDatabaseIfNotExists : CreateDatabaseIfNotExists<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            try
            {
                //context.Set<CityArea>().AddRange(new List<CityArea> {
                //new CityArea { Name = "厦门", Pinyin = "xiamen", CityId = 0, IsEdit = false, Sort = 1, State = 1, CreateTime = DateTime.Now },
                //new CityArea { Name = "深圳", Pinyin = "shenzhen", CityId = 0, IsEdit = false, Sort = 1, State = 0, CreateTime = DateTime.Now },
                //new CityArea { Name = "福州", Pinyin = "fuzhou", CityId = 0, IsEdit = false, Sort = 1, State = 0, CreateTime = DateTime.Now },
                //new CityArea { Name = "泉州", Pinyin = "quanzhou", CityId = 0, IsEdit = false, Sort = 1, State = 0, CreateTime = DateTime.Now },
                //new CityArea { Name = "龙岩", Pinyin = "longyan", CityId = 0, IsEdit = false, Sort = 1, State = 0, CreateTime = DateTime.Now },
                //new CityArea { Name = "武汉", Pinyin = "wuhan", CityId = 0, IsEdit = false, Sort = 1, State = 0, CreateTime = DateTime.Now },
                //new CityArea { Name = "重庆", Pinyin = "chongqing", CityId = 0, IsEdit = false, Sort = 1, State = 0, CreateTime = DateTime.Now }});
                //context.SaveChanges();

                //ProductCategory productCategory = new ProductCategory { Name = "其他", CreateTime = DateTime.Now, State = DelStateEnum.正常 };
                //context.Set<ProductCategory>().Add(productCategory);
                //context.SaveChanges();
                //context.Set<Product>().Add(new Product { Name = "其他", ProductCategoryId = productCategory.Id, State = DelStateEnum.正常, CreateTime = DateTime.Now });
                //context.SaveChanges();

                var filePath = ZConfig.GetConfigString("InitSqlFile");
                if (string.IsNullOrEmpty(filePath))
                    throw new Exception("初始化数据文件不能为空!");
                if (filePath.StartsWith("~"))
                {
                    filePath = filePath.Substring(2);
                    filePath = $"{AppDomain.CurrentDomain.BaseDirectory}{filePath}";
                }
                var sql = File.ReadAllText(filePath);
                context.Database.ExecuteSqlCommand(sql);
                base.Seed(context);
            }
            catch (Exception ex)
            {
                NLogger.Error(ex);
            }

        }
    }
}
