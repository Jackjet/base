//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单相关表
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using Conan.Core;
using System;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 订单评价 
    /// </summary>
    public partial class OrderRating : Entity<int>
    {
        /// <summary>
        /// 总订单号
        /// </summary>
        [Description("总订单号")]
        public virtual string BillNo { get; set; }



        /// <summary>
        /// 得分
        /// </summary>
        [Description("得分")]
        public virtual int Score { get; set; }


        /// <summary>
        /// 整体评价 几星
        /// </summary>
        [Description("整体评价")]
        public virtual int OverallRate { get; set; }
        /// <summary>
        /// 服务态度 几星
        /// </summary>
        [Description("服务态度")]
        public virtual int ServiceRate { get; set; }
        /// <summary>
        /// 准时上门   （ 响应速度） 几星
        /// </summary>
        [Description("准时上门")]
        public virtual int ResponseRate { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 评价时间
        /// </summary>
        [Description("评价时间")]
        public virtual DateTime CreateTime { get; set; }


        /// <summary>
        /// 评价人
        /// </summary>
        [Description("评价人")]
        public virtual string Evaluation { get; set; }



        /// <summary>
        /// 评价来源
        /// </summary>
        [Description("评价来源")]
        public virtual EvaluationSoures EvaluationSoure { get; set; }
    }
}

