using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Conan.Model;
using Conan.DAL;
using Conan.Core;

namespace Conan.BLL
{
    public class OperateLogBLL : BaseBll<OperateLog>
    {
        #region 构造函数
        private static OperateLogBLL instance;
        public static OperateLogBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new OperateLogBLL();
            }
            return instance;
        }
        #endregion

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="user"></param>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        /// <param name="ip"></param>
        public void LoginLog(string tag, string content, int userId, string userName, string ip)
        {
            OperateLog log = new OperateLog
            {
                Tag = tag,
                Content = content,
                Operator = userName,
                OperatorId = userId,
                IP = ip
            };
            base.Add(log);
        }


        /// <summary>
        /// 自定义 日志内容
        /// </summary>
        /// <param name="uinfo"></param>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        public void CustomLog(UserLogInfo uinfo, string tag, string content)
        {
            OperateLog log = new OperateLog
            {
                Tag = tag,
                Content = content,
                Operator = uinfo.Name,
                OperatorId = uinfo.Id,
                IP = uinfo.ClientIP
            };
            if (!string.IsNullOrWhiteSpace(content))
                base.Add(log);
        }

        /// <summary>
        /// 对象添加 的日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <param name="tag"></param>
        /// <param name="t"></param>
        /// <param name="ip"></param>
        public void InsertLog<T>(UserLogInfo uinfo, string tag, T t) where T : class, new()
        {
            OperateLog log = new OperateLog
            {
                Tag = tag,
                Content = ObjectToStr(t, "UpdatePerson,UpdateDate"),
                Operator = uinfo.Name,
                OperatorId = uinfo.Id,
                IP = uinfo.ClientIP
            };
            base.Add(log);
        }

        /// <summary>
        /// 对象删除 的日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <param name="tag"></param>
        /// <param name="t"></param>
        /// <param name="ip"></param>
        public void RemoveLog<T>(UserLogInfo uinfo, string tag, T t) where T : class, new()
        {
            OperateLog log = new OperateLog
            {
                Tag = tag,
                Content = ObjectToStr(t),
                Operator = uinfo.Name,
                OperatorId = uinfo.Id,
                IP = uinfo.ClientIP
            };
            base.Add(log);
        }

        /// <summary>
        /// 对象编辑 的日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <param name="tag"></param>
        /// <param name="ip"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        public void EditLog<T>(UserLogInfo uinfo, string tag, T before, T after) where T : class, new()
        {
            OperateLog log = new OperateLog
            {
                Tag = tag,
                Content = ObjectEquals(before, after, "CreatePerson,CreateDate,UpdatePerson,UpdateDate"),
                Operator = uinfo.Name,
                OperatorId = uinfo.Id,
                IP = uinfo.ClientIP
            };
            if (!string.IsNullOrEmpty(log.Content))
                base.Add(log);
        }


        /// <summary>
        /// 获取对象的修改值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static string ObjectEquals<T>(T t1, T t2, string excepts = "") where T : class, new()
        {
            string[] arrs = excepts.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            Type p1 = t1.GetType();
            Type p2 = t2.GetType();

            var ns = p1.GetProperties();
            foreach (var p in ns)
            {
                string name = p.Name;

                if (arrs.Contains(name))
                    continue;

                string cnname = ((DescriptionAttribute)Attribute.GetCustomAttribute(p, typeof(DescriptionAttribute)))?.Description;

                var v1 = p1.GetProperty(name).GetValue(t1, null);
                var v2 = p2.GetProperty(name).GetValue(t2, null);
                //Id处理
                if (name.ToString().ToLower() == "id")
                {
                    if (sb.Length > 0 && v1.Equals(v2))
                    {
                        sb.AppendFormat($"{cnname} 值为 \"{v1}\" \r\n", cnname ?? p.Name, v1 ?? "");
                    }
                    continue;
                }
                #region 判断
                if (v1 == null && v2 == null)
                {
                    continue;
                }
                else
                          if (v1 == null && v2 != null)
                {
                    sb.AppendFormat($"修改了 {cnname} 旧值为 \"{v1}\",新值为 \"{v2}\"\r\n", cnname ?? name, v1 ?? "", v2 ?? "");

                }
                else
                       if (v1 != null && v2 == null)
                {
                    sb.AppendFormat($"修改了 {cnname} 旧值为 \"{v1}\",新值为 \"{v2}\"\r\n", cnname ?? name, v1 ?? "", v2 ?? "");

                }
                else
                       if (v1 != null && v2 != null)
                {
                    if (v1.Equals(v2))
                        continue;
                    else
                        sb.AppendFormat($"修改了 {cnname} 旧值为 \"{v1}\",新值为 \"{v2}\"\r\n", cnname ?? name, v1 ?? "", v2 ?? "");

                }
                #endregion
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
        public static string ObjectToStr<T>(T t, string excepts = "") where T : class, new()
        {
            string[] arrs = excepts.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            Type p1 = t.GetType();
            foreach (var p in p1.GetProperties())
            {
                if (arrs.Contains(p.Name))
                    continue;
                string cnname = ((DescriptionAttribute)Attribute.GetCustomAttribute(p, typeof(DescriptionAttribute)))?.Description;

                object v = p.GetValue(t);
                sb.AppendFormat($"{cnname} 值为 \"{v}\" \r\n", cnname ?? p.Name, v ?? "");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 对象复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="RealObject"></param>
        /// <returns></returns>
        public static T Clone<T>(T RealObject) where T : class, new()
        {
            string s = JsonHelper.SerializeObject(RealObject);
            return JsonHelper.DeserializeObject<T>(s);
        }
    }
}