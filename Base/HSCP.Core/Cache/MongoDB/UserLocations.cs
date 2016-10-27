using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Core
{

public class UserLocations
    {
        public static string TableName = "UserLocation";

        #region 删除历史数据
        /// <summary>
        /// 删除历史数据
        /// </summary>
        /// <param name="Day"></param>
        public static void Deletehis(long Day)
        {
            try
            {
                var db = DBManager.getDB();
                var collection = db.GetCollection(TableName);
                var query = Query.LT("Day", Day);
                collection.Remove(query);
            }
            catch (Exception exp)
            {
                NLogger.Error("删除历史数据:" + exp.ToString());
            }
        }

        #endregion

        #region 添加或更新用户位置信息
        /// <summary>
        /// 添加或更新用户位置信息
        /// </summary>
        /// <param name="UserLoc"></param>
        public static void Insert(UserLocation UserLoc)
        {
            try
            {
                var db = DBManager.getDB();
                var collection = db.GetCollection(TableName);
             //  var  query = Query.And(Query.NE("Day", UserLoc.Day), Query.NE("BillNo", UserLoc.BillNo));
                IMongoQuery query = Query<UserLocation>.Where(o => o.Day==  UserLoc.Day  &&  o.StartTime== UserLoc.StartTime  && o.BillNo== UserLoc.BillNo  &&  o.EmployeeId== UserLoc.EmployeeId);// Query<UserLocation>.Where(o=>o.StartTime>=DateTime.Now.AddHours(8).AddHours(1)  &&  o.Day.Date==DateTime.Now.Date);//<ObjectId>(t => t._id, 0);

                var obj = collection.FindOneAs<UserLocation>(query);
                if (obj != null)
                {
                    UserLoc._id = obj._id;
                }
                collection.Save<UserLocation>(UserLoc);
             
    }
            catch (Exception exp)
            {
                NLogger.Error("添加或更新用户位置信息:" + exp.ToString());
            }
        } 
        #endregion

        #region 查询附近的人

        public static List<UserLocationResult> GetNear(double lon, double lat, int pageIndex, int pageSize,long Day,long StartTime)
        {

            double rangeInM = Convert.ToDouble(  ZConfig.GetConfigString("Aotopddistance")  );
            List<UserLocationResult> objList = new List<UserLocationResult>();
            try
            {
                // lat = 24.47871208190918, lon = 118.18478393554690
             var options = DBManager.getGeoNearOption(rangeInM);
            var db = DBManager.getDB();
            var collection = db.GetCollection(TableName);
                IMongoQuery query = Query<UserLocation>.Where(o =>o.Day== Day  && o.StartTime< StartTime);// Query<UserLocation>.Where(o=>o.StartTime>=DateTime.Now.AddHours(8).AddHours(1)  &&  o.Day.Date==DateTime.Now.Date);//<ObjectId>(t => t._id, 0);
               
                var req = collection.GeoNearAs<UserLocation>(query, lon, lat, pageSize * (pageIndex + 1), options).Hits.Skip(pageSize * pageIndex).Take(pageSize);
            if (req != null)
            {

               
                foreach (var item in req)
                {
                    UserLocationResult objResult = new UserLocationResult();
                    objResult.Loc = item.Document;
                        objResult.StartTime = item.Document.StartTime;
                        objResult.EmployeeId = item.Document.EmployeeId;
                        objResult.Day = item.Document.Day;
                        objResult.BillNo = item.Document.BillNo;
                    objResult.Distance = item.Distance;
                    objList.Add(objResult);
                }
            }
            return objList;
            }
            catch (Exception exp)
            {
                NLogger.Error("查询附近的人:"+ exp.ToString());
                return objList;
            }
        }

        #endregion

        #region 删除指定项
        /// <summary>
        /// 删除指定项
        /// </summary>
        /// <param name="Day"></param>
        public static void Deleteitem(long Day,string BillNo, int EmployeeId)
        {
            try
            {
                var db = DBManager.getDB();
                var collection = db.GetCollection(TableName);
                IMongoQuery query = Query<UserLocation>.Where(o => o.Day == Day && o.BillNo == BillNo && o.EmployeeId== EmployeeId);
                
                collection.Remove(query);
            }
            catch (Exception exp)
            {
                NLogger.Error("删除指定项:" + exp.ToString());
            }
        }

        #endregion

    }
}
