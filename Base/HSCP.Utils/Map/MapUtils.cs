using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Utils
{
    public class MapUtils
    {
        private const double EARTH_RADIUS = 6378.137;//地球半径
        private const string BaiduMapKey = "IrBP8MLy1WXy7ajGFuKXdoWB";
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        /// <summary>
        /// 获取公里数
        /// </summary>
        /// <param name="lat1">纬度</param>
        /// <param name="lng1">经度</param>
        /// <param name="lat2">纬度</param>
        /// <param name="lng2">经度</param>
        /// <returns>返回公里数</returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }



        /// <summary>
        /// 根据地址获取经纬度地址
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="city"></param>
        /// <param name="lng">经度</param>
        /// <param name="lat">纬度</param>
        public static void GetLngLat(string addr, string city, ref string lng, ref string lat)
        {

            string url = "http://api.map.baidu.com/geocoder/v2/?ak=" + BaiduMapKey + "&callback=renderOption&output=json&city=" + city + "&address=" + addr;

            var wclient = new System.Net.WebClient();
            byte[] jsonbyte = System.Text.Encoding.ASCII.GetBytes(url);
            byte[] ret = wclient.UploadData(url, "POST", jsonbyte);
            if (ret != null)
            {
                string[] jsons = System.Text.Encoding.UTF8.GetString(ret).Split(',');
                foreach (string strJson in jsons)
                {
                    if (strJson.Contains("lng"))
                    {
                        lng = strJson.Split(':')[strJson.Split(':').Length - 1];
                    }
                    if (strJson.Contains("lat"))
                    {
                        lat = strJson.Split(':')[strJson.Split(':').Length - 1].Replace("}", null);
                    }
                }
            }
        }

        /// <summary>
        /// 根据经纬度获取地址
        /// </summary>
        /// <param name="lng">经度</param>
        /// <param name="lat">纬度</param>       
        public static string GetAddressByLngLat(string lng, string lat)
        {
             
            string address = string.Empty;
            string url = "http://api.map.baidu.com/geocoder/v2/?ak=" + BaiduMapKey + "&callback=renderOption&output=json&location=" + lat + "," + lng;

            var wclient = new System.Net.WebClient();
            byte[] jsonbyte = System.Text.Encoding.ASCII.GetBytes(url);
            try
            {
                byte[] ret = wclient.UploadData(url, "POST", jsonbyte);
                if (ret != null)
                {
                    string[] jsons = System.Text.Encoding.UTF8.GetString(ret).Split(',');
                    foreach (string strJson in jsons)
                    {
                        if (strJson.Contains("formatted_address"))
                        {
                            address = strJson.Split(':')[strJson.Split(':').Length - 1].Replace("\"", "");
                        }
                    }
                }
            }
            catch { }
            return address;
        }
    }
}
