//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：分享送红包界面模型
//数据表(Tables)：    
//作者(Author)： Ldw
//日期(Create Date)： 2016‎.08.16
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Conan.Model
{
    [NotMapped]
    public class ShareRedBindViewModel
    {
        /// <summary>
        /// 优惠卷名
        /// </summary>
        public string GiftName { get; set; }
        /// <summary>
        /// 优惠卷简称
        /// </summary>
        public string SimpleName { get; set; }
        /// <summary>
        /// 优惠卷价值
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 活动规则
        /// </summary>
        public string Rules { get; set; }
        /// <summary>
        /// 是否领取过
        /// </summary>
        public bool Receive { get; set; }
        public List<FriendPacketsModel> FriendPacketsModels { get; set; } = new List<FriendPacketsModel>();
        public List<CouponGroupRecordModel> CouponGroupRecordModels { get; set; } = new List<CouponGroupRecordModel>();

    }
    public class FriendPacketsModel
    {
        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime BindTime { get; set; }
        /// <summary>
        /// 优惠卷价值
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 优惠卷名
        /// </summary>
        public string GiftName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Img { get; set; }
    }
    public class CouponGroupRecordModel
    {
        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        public string CouponGroupName { get; set; }
        /// <summary>
        /// 优惠卷价值
        /// </summary>
        public decimal Amount { get; set; }
    }
}
