//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工表
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.11
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 员工表
    /// </summary>
    public  class Employee : OtherEntity<int>
    {
        /// <summary>
        /// 电信账号
        /// </summary>
        [Description("电信账号")]
        public virtual string DxCode { get; set; }

        /// <summary>
        /// 电信密码
        /// </summary>
        [Description("电信密码")]
        public virtual string DxPwd { get; set; }

        /// <summary>
        /// 员工角色
        /// </summary>
        [Description("员工角色")]
        public virtual int? RoleId { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        [Description("员工编号")]
        public virtual string No { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }




        /// <summary>
        /// 真实姓名
        /// </summary>
        [Description("真实姓名")]
        public virtual string RealName { get; set; }
    
        /// <summary>
        /// 手机
        /// </summary>
        [Description("手机")]
        public virtual string Phone { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Description("城市")]
        public virtual int? CityId { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        [Description("地区")]
        public virtual int? AreaId { get; set; }

        /// <summary>
        /// 地址（详细地址）
        /// </summary>
        [Description("地址")]
        public virtual string Address { get; set; }



        



        /// <summary>
        /// 所属门店
        /// </summary>
        [Description("所属门店")]
        public virtual int StoreId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        public virtual int DepartId { get; set; }

        /// <summary>
        /// 工作性质
        /// </summary>
        [Description("工作性质")]
        public virtual WorkingPropertys WorkingProperty { get; set; }

        /// <summary>
        /// 上下架状态  （支持员工  上架 代表在职）
        /// </summary>
        [Description("上下架状态")]
        public virtual EmployeeStateEnum State { get; set; }


        /// <summary>
        /// 标签id  001,002,003
        /// </summary>
        [Description("标签id")]
        public virtual string  LabelId { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>
        [Description("离职时间")]
        public virtual DateTime? LeaveTime { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        [Description("入职时间")]
        public virtual DateTime? EntryTime { get; set; }

        /// <summary>
        /// 职员类型
        /// </summary>
        [Description("职员类型")]
        public virtual EmployeeTypeEnum EmployeeType { get; set; }

        /// <summary>
        /// 员工头像
        /// </summary>
        [Description("员工头像")]
        public virtual string HeadPortrait { get; set; }

        /// <summary>
        /// 是否司机
        /// </summary>
        [Description("是否司机")]
        public virtual bool IsDriver { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        [Description("是否超级管理员")]
        public virtual bool IsSys { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }
    } 
}