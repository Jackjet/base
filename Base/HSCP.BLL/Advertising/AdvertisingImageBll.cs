using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.BLL
{
    public class AdvertisingImageBll : BaseBll<AdvertisingImage>
    {
        #region 构造函数
        private static AdvertisingImageBll instance;
        public static AdvertisingImageBll GetInstance()
        {
            if (instance == null)
            {
                instance = new AdvertisingImageBll();
            }
            return instance;
        }
        #endregion

        #region 根据广告id 删除 广告图片数据
        /// <summary>
        ///根据广告id 删除 广告图片数据
        /// </summary>
        /// <param name="advertisingId">广告id</param>
        /// <returns></returns>
        public int DeleteByAvertisingId(int advertisingId)
        {

            string sql = "delete  [AdvertisingImage]  where  [AdvertisementId] = @AdvertisementId ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@AdvertisementId", advertisingId);
            paramList.Add(sp);
            return ExecuteSqlCommand(sql, paramList);
        }
        #endregion


    }
}
