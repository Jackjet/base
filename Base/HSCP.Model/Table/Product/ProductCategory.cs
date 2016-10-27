using System;
using System.Collections.Generic;
using System.ComponentModel;
using Conan.Core;



namespace Conan.Model
{
    public class ProductCategory : Entity<int>
    {
        /// <summary>
        /// 产品分类
        /// </summary>
        [Description("产品分类名称")]
        public virtual string Name { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        public virtual DepartmentEnum? Department { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        [Description("详情")]
        public virtual string Description { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        public virtual string Icon { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        [Description("删除状态")]
        public virtual DelStateEnum State { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public virtual int Sort { get; set; } = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public virtual DateTime CreateTime { get; set; }
    }
}
