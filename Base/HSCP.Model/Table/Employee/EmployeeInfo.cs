/****************************************************** 

    文件名称：EmployeeInfo.cs
    功能描述：员工信息
    作    者：Jxw
    日    期：2016.07.14
    修改记录：

*******************************************************/
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    public class EmployeeInfo : Entity<int>
    {
        public int EmployeeId { get; set; }


        /// <summary>
        ///性别
        /// </summary>
        [Description("性别")]
        public virtual SexEnum Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Description("出生日期")]
        public virtual DateTime? BirthTime { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Description("身份证")]
        public virtual string IDCard { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [Description("籍贯")]
        public virtual string Hometown { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Description("民族")]
        public virtual string Nation { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        [Description("学历")]
        public virtual EducationEnum? Education { get; set; }








        /// <summary>
        /// 是否已婚
        /// </summary>
        [Description("是否已婚")]
        public virtual Marrieds? Married { get; set; }

        /// <summary>
        /// 待遇要求
        /// </summary>
        [Description("待遇要求")]
        public virtual string Salary { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        [Description("语言")]
        public virtual LanguageEnum? Language { get; set; }
        /// <summary>
        /// 特长
        /// </summary>
        [Description("特长")]
        public virtual string Specialty { get; set; }
        /// <summary>
        /// 个人能力
        /// </summary>
        [Description("个人能力")]
        public virtual string Ability { get; set; }
        /// <summary>
        /// 工作经验
        /// </summary>
        [Description("工作经验")]
        public virtual string Experience { get; set; }
        /// <summary>
        /// 家庭情况
        /// </summary>
        [Description("家庭情况")]
        public virtual string Family { get; set; }
        /// <summary>
        /// 培训情况
        /// </summary>
        [Description("培训情况")]
        public virtual string Training { get; set; }



        /// <summary>
        /// 开户银行
        /// </summary>
        [Description("开户银行")]

        public virtual string Banks { get; set; }

        /// <summary>
        /// 开户支行
        /// </summary>
        [Description("开户支行")]

        public virtual string OpenAccount { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [Description("银行卡号")]

        public virtual string BankCards { get; set; }
    }
}
