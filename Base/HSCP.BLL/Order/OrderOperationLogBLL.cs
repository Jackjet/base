﻿//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单操作日志
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;
using Conan.Core;

#endregion
namespace Conan.BLL
{
    /// <summary>
    /// 订单操作日志
    /// </summary>
    public class OrderOperationLogBLL : BaseBll<OrderOperationLog>
    {
        #region 构造函数
        private static OrderOperationLogBLL instance;
        public static OrderOperationLogBLL GetInstance()
        {
            if (instance == null)
                instance = new OrderOperationLogBLL();

            return instance;
        }
        #endregion

        #region 自定义 日志内容
        /// <summary>
        /// 自定义 日志内容
        /// </summary>
        /// <param name="uinfo"></param>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        public void CustomLog(UserLogInfo uinfo, string BillNo, string tag, string content)
        {
            OrderOperationLog log = new OrderOperationLog
            {
                CreateTime = DateTime.Now,
                Operator = uinfo.Name,
                OperatorId = uinfo.Id,
                IP = uinfo.ClientIP,
                Title = tag,
                BillNo = BillNo,
                Message = content
            };
            if (!string.IsNullOrWhiteSpace(content))
                base.Add(log);
        }

        #endregion

        #region 添加日志

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uinfo"></param>
        /// <param name="BillNo"></param>
        /// <param name="tag"></param>
        /// <param name="t"></param>
        public void InsertLog<T>(UserLogInfo uinfo, string BillNo, string tag, T t) where T : class, new()
        {
            OrderOperationLog log = new OrderOperationLog
            {
                CreateTime = DateTime.Now,
                Operator = uinfo.Name,
                OperatorId = uinfo.Id,
                IP = uinfo.ClientIP,
                Title = tag,
                BillNo = BillNo,
                Message = OperateLogBLL.ObjectToStr(t)

            };
            base.Add(log);
        }

        #endregion

        #region 对象删除 的日志
        /// <summary>
        /// 对象删除 的日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uinfo"></param>
        /// <param name="BillNo"></param>
        /// <param name="tag"></param>
        /// <param name="t"></param>
        public void RemoveLog<T>(UserLogInfo uinfo, string BillNo, string tag, T t) where T : class, new()
        {
            OrderOperationLog log = new OrderOperationLog
            {
                CreateTime = DateTime.Now,
                Operator = uinfo.Name,
                OperatorId = uinfo.Id,
                IP = uinfo.ClientIP,
                Title = tag,
                BillNo = BillNo,
                Message = OperateLogBLL.ObjectToStr(t)
            };
            base.Add(log);
        }
        #endregion

        #region 对象编辑 的日志
        /// <summary>
        /// 对象编辑 的日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uinfo"></param>
        /// <param name="BillNo"></param>
        /// <param name="tag"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        public void EditLog<T>(UserLogInfo uinfo, string BillNo, string tag, T before, T after) where T : class, new()
        {
            OrderOperationLog log = new OrderOperationLog
            {
                CreateTime = DateTime.Now,
                Operator = uinfo.Name,
                OperatorId = uinfo.Id,
                IP = uinfo.ClientIP,
                Title = tag,
                BillNo = BillNo,
                Message = OperateLogBLL.ObjectEquals(before, after)
            };
            if (!string.IsNullOrEmpty(log.Message))
                base.Add(log);
        }

        #endregion
    }
}
