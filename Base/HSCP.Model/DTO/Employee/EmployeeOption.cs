//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：服务员工列表搜索
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.12
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    /// 服务员工列表搜索
    /// </summary>
    public class EmployeeOption
    {
        /// <summary>
        /// 门店
        /// </summary>
        public int? StoreId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public int? DeptId { get; set; }

        /// <summary>
        /// 一级部门
        /// </summary>
        public int? DeptpId { get; set; }
        

        /// <summary>
        /// 状态
        /// </summary>
        public int? State { get; set; }

        /// <summary>
        /// 在此范围内的状态
        /// </summary>
        public List<int> ListState { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public int? TypeId { get; set; }


        /// <summary>
        /// 产品id
        /// </summary>
        public int? ProductId { get; set; }
        /// <summary>
        /// 输入员工编号/姓名/电话
        /// </summary>

        public string DriverSearch { get; set; }


        /// <summary>
        /// 是否司机  
        /// </summary>
        public bool? IsDriver { get; set; }

        /// <summary>
        /// 不包含该用户id列表
        /// </summary>
      public List<int?> NotContain { get; set; }

    }
}
