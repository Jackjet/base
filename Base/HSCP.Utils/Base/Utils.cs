using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Conan.Utils
{

    public class Utils
    {
        /// <summary>
        /// 比较两个对象属性 是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static string ObjectEquals<T>(T t1, T t2, string excepts = "")
        {
            string[] arrs = excepts.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            Type p1 = t1.GetType();
            Type p2 = t2.GetType();
            var ns = p1.GetProperties().Select(o => o.Name);
            foreach (string n in ns)
            {
                if (arrs.Contains(n))
                    continue;
                var v1 = p1.GetProperty(n).GetValue(t1, null);
                var v2 = p2.GetProperty(n).GetValue(t2, null);

                if (v1 != null && v2 != null)
                {
                    if (!v1.Equals(v2))
                        sb.AppendFormat("字段{0}:\"{1}\"被更改为\"{2}\";", n, v1, v2);
                }
                if (v1 == null && v2 != null)
                    sb.AppendFormat("字段{0}:\"{1}\"被更改为\"{2}\";", n, "", v2);
                else if (v2 == null && v1 != null)
                    sb.AppendFormat("字段{0}:\"{1}\"被更改为\"{2}\";", n, v1, "");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 对象转成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="excepts"></param>
        /// <returns></returns>
        public static string ObjectToStr<T>(T t, string excepts = "")
        {
            string[] arrs = excepts.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder("");
            Type p1 = t.GetType();
            foreach (var p in p1.GetProperties())
            {
                if (arrs.Contains(p.Name))
                    continue;
                object v = p.GetValue(t);
                if (v == null || v.Equals(null))
                { }
                else
                    sb.AppendFormat("字段{0}:\"{1}\";", p.Name, v);
            }
            return sb.ToString();
        }

        //public static T Clone<T>(T RealObject)
        //{
        //    string s = Newtonsoft.Json.JsonConvert.SerializeObject(RealObject);
        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(s);
        //}


        /// <summary>
        /// 计算权限总和
        /// </summary>
        /// <param name="OldStatus">数据库现有权限总和</param>
        /// <param name="Action">取消或设置操作（0取消，1设置）</param>
        /// <param name="StatusVal">设置操作对应的状态值</param>
        /// <returns></returns>
        public static int ReturnStatusTotal(int OldStatus, int Action, int StatusVal)
        {
            int NewStatus = OldStatus;
            if (Action == 1)
            {
                //判断此权限串是否拥有相应操作,不包括时加入权限
                if ((OldStatus & StatusVal) <= 0)
                {
                    NewStatus = OldStatus | StatusVal;
                }
            }
            else
            {
                //判断此权限串是否拥有相应操作,有权限时移除权限
                if ((OldStatus & StatusVal) > 0)
                {
                    NewStatus = OldStatus & ~StatusVal;
                }
            }
            return NewStatus;
        }

    }
}
