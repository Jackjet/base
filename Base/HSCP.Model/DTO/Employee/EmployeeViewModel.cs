//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：服务员工列表视图
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.12
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 服务员工列表视图
    /// </summary>
    [NotMapped]
    public class EmployeeViewModel : Employee
    {
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string LabelName { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }


        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductsName { get; set; }


    }

    /// <summary>
    /// 修改员工时间
    /// </summary>
    public class UpdateEmployeeTime
    {
        public virtual int EmployeeId { get; set; }

        public virtual DateTime CreateTime { get; set; }

        public virtual string AreaStr { get; set; }
    }

    /// <summary>
    /// 修改员工
    /// </summary>
    public partial class EmployeeServeAreaView
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>

        public virtual int EmployeeId { get; set; }
        /// <summary>
        /// 可服务区域
        /// </summary>

        public virtual string AreaName { get; set; }
        /// <summary>
        /// 可服务区域ID
        /// </summary>
        //    [Description("可服务区域ID")]
        public virtual int AreaId { get; set; }
        /// <summary>
        /// 星期
        /// </summary>

        public virtual DayOfWeek Week { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>

        public virtual DateTime CreateTime { get; set; }

    }
}
