/*
 * 作者：cyx    
 * 日期：2016.06.08  
 * 描述：评价明细表-过滤条件
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 评价明细表-过滤条件
    /// </summary>
    public class OrderRatingStatisticalOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath { get; set; }
        
        /// <summary>
        /// 员工标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 综合评分
        /// </summary>
        public int? Score { get; set; }
        /// <summary>
        /// 评价时间开始
        /// </summary>
        public DateTime? TimeBegin { get; set; }
        /// <summary>
        /// 评价时间结束
        /// </summary>
        public DateTime? TimeEnd { get; set; }
        /// <summary>
        /// 隐藏的input判断次数
        /// </summary>
        public virtual int firstselect { get; set; } = 0;
    }
    /// <summary>
    /// 部门评价表-过滤条件
    /// </summary>
    public class DepartmentEvaluationOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DepartMentId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath { get; set; }
        /// <summary>
        /// 时间开始
        /// </summary>
        public DateTime? TimeBegin { get; set; }
        /// <summary>
        /// 时间结束
        /// </summary>
        public DateTime? TimeEnd { get; set; }
    }

    /// <summary>
    /// 部门评价明细表-过滤条件
    /// </summary>
    public class DepartmentEvaluationDetailOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DepartMentId { get; set; }
        /// <summary>
        /// 部门路径
        /// </summary>
        public string DepartMentPath { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartMentName { get; set; }
        /// <summary>
        /// 时间开始
        /// </summary>
        public DateTime? TimeBegin { get; set; }
        /// <summary>
        /// 时间结束
        /// </summary>
        public DateTime? TimeEnd { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string BillNo { get; set; }
    }
}
