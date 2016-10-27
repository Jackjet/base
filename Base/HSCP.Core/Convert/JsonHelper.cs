/****************************************************** 

    文件名称：JsonHelper.cs
    功能描述：Json 转换
    作    者：Jxw
    日    期：2016.04.25
    修改记录：

*******************************************************/

using System;
using Newtonsoft.Json;

namespace Conan.Core
{
    public class JsonHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string result)
        {
            return JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static dynamic Deserialize(string input)
        {
            return (dynamic)JsonConvert.DeserializeObject(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SerializeObject(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }


     
    }
}
