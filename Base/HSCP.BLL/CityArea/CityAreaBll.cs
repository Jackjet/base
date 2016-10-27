using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using System.Data.SqlClient;

namespace Conan.BLL
{
    public   class CityAreaBll : BaseBll<CityArea>
    {
        #region 构造函数
        private static CityAreaBll instance;
        public static CityAreaBll GetInstance()
        {
            if (instance == null)
            {
                instance = new CityAreaBll();
            }
            return instance;
        }
        #endregion

        #region 根据id 获取地区名称
        /// <summary>
        /// 根据id 获取地区名称
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetCityAreaNameById(int Id)
        {
            return Get(Id)?.Name;
        }
        #endregion

        #region 根据门店id获取地区列表
        /// <summary>
        /// 根据门店id获取地区列表
        /// </summary>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        public List<CityArea> GetCityAreaByStoreId(int StoreId)
        {
            List<CityArea> result = new List<CityArea>();
            string sql = "  select * from  CityArea where CityId=(select[CityId] from[Store] where[Id]=@StoreId)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter("@StoreId", StoreId);
            paramList.Add(sp);
            result = SqlQuery(sql, paramList).ToList();
            return result;
        }
        #endregion

    }
}
