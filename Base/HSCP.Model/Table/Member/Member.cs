/****************************************************** 

    文件名称：Member.cs
    功能描述：会员主表
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/
using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 会员主表
    /// </summary>
    public class Member : Entity<int>
    {
        public virtual string LblId { get; set; }

        /// <summary>
        /// 会员备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 会员服务备注
        /// </summary>
        public virtual string Remark2 { get; set; }


        /// <summary>
        /// 会员号
        /// </summary>
        public virtual string Account { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 支付密码
        /// </summary>
        public virtual string PayPwd { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Name { get; set; }
    
        /// <summary>
        /// 账号余额
        /// </summary>
        public virtual decimal Amount { get; set; }

        /// <summary>
        /// 账号充值送的金额  旧系统   不可退金额
        /// </summary>
        public virtual decimal? OldRealAmount { get; set; } = 0;

        /// <summary>
        /// 绑定手机
        /// </summary>
        public virtual string BindTel { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public virtual DateTime? LastLogin { get; set; }
        /// <summary>
        /// 来源 或客渠道
        /// </summary>
        public virtual AccessChannel? Source { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public virtual string HeadImg { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public virtual string BirthDate { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public virtual SexEnum Sex { get; set; }
        /// <summary>
        /// 会员级别
        /// </summary>
        public virtual MemberLevel Level { get; set; }
        /// <summary>
        /// 会员标签
        /// </summary>
        public virtual string Tags { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public virtual string Occupation { get; set; }

     
        /// <summary>
        /// 状态
        /// </summary>
        public virtual MemberState State { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public virtual DateTime RegisterTime { get; set; }

      

    }
}