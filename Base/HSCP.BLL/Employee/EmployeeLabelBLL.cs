//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工标签
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.11
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.DAL;
using Conan.Model;

namespace Conan.BLL
{
    /// <summary>
    /// 员工标签
    /// </summary>
    public class EmployeeLabelBLL : BaseBll<EmployeeLabel>
    {
        #region 构造函数
        private static EmployeeLabelBLL instance;
        public static EmployeeLabelBLL GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeLabelBLL();
            }
            return instance;
        }
        #endregion

        #region 添加
        public void AddObj(EmployeeLabel obj)
        {
            Add(obj);
        }
        public void AddObj(OrderLabel obj)
        {
           OrderLabelBLL.GetInstance(). Add(obj);
        }

        public void AddObj(MemberLabel obj)
        {
            MemberLabelBLL.GetInstance().Add(obj);
        }

        #endregion


    }
}
