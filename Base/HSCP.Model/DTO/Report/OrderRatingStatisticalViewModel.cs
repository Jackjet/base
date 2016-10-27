/*
 * 作者：cyx    
 * 日期：2016.06.13  
 * 描述：评价明细表
 * 修改记录：    
 * */

using System;

namespace Conan.Model
{
    /// <summary>
    /// 评价明细表
    /// </summary>
    public class OrderRatingStatisticalViewModel
    {

        
              public int StoreId { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 员工标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 综合评分
        /// </summary>

        public virtual int Score { get; set; }

        /// <summary>
        /// 【综合评分】大于3总订单数
        /// </summary>
        public virtual int OverScore3 { get; set; }
        /// <summary>
        /// 整体评价
        /// </summary>
        public virtual int OverallRate { get; set; }
        /// <summary>
        /// 服务态度 几星
        /// </summary>
        public virtual int ServiceRate { get; set; }
        /// <summary>
        /// 准时上门
        /// </summary>
        public virtual int ResponseRate { get; set; }
    }
    /// <summary>
    /// 部门评价表
    /// </summary>
    public class DepartmentEvaluationViewModel
    {


        public int StoreId { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMentPath { get; set; }

        /// <summary>
        /// 订单总数
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 部门分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 平均分
        /// </summary>

        public float Average { get; set; }
    }

    /// <summary>
    /// 部门评价明细表
    /// </summary>
    public class DepartmentEvaluationDetailViewModel
    {


        public int StoreId { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 服务地址
        /// </summary>

        public string Street { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public virtual string codestr { get; set; }

        /// <summary>
        /// 少于两个员工编号
        /// </summary>
        public virtual string codetwo { get; set; }
        /// <summary>
        /// 多于两个员工编号
        /// </summary>
        public virtual string codemor { get; set; }

        /// <summary>
        /// 部门分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 评价内容
        /// </summary>
        public string Remark { get; set; }


    }
}
