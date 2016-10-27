using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    public class DBManager
    {
        public static double earthRadius = 6378137.0; // m
        public static MongoDatabase getDB()
        {
            string connectionStr = ZConfig.GetConfigString("MongoDB");
            MongoClient client = new MongoClient(connectionStr);
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase(ZConfig.GetConfigString("MongoDB_DBNAME")  );
            return db;
        }

        public static GeoNearOptionsBuilder getGeoNearOption(double rangeInM)
        {
            return GeoNearOptions.SetMaxDistance(rangeInM / earthRadius /* to radians */)
                                                .SetSpherical(true).SetDistanceMultiplier(earthRadius);
        }
    }
}
