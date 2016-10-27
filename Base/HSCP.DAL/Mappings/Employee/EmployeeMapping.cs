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
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    /// <summary>
    /// 员工表
    /// </summary>
    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public EmployeeMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.DxCode).HasMaxLength(20);
            Property(c => c.DxPwd).HasMaxLength(20);
            Property(c => c.RealName).HasMaxLength(20);
            Property(c => c.No).HasMaxLength(10);
            Property(c => c.Password).HasMaxLength(100);
            Property(c => c.Phone).HasMaxLength(20);
            Property(c => c.Address).HasMaxLength(100);
            Property(c => c.Remark).HasMaxLength(1000);
            Property(c => c.CreatePerson).HasMaxLength(20);
            Property(c => c.UpdatePerson).HasMaxLength(20);


            ToTable("Employee");
        }
    }
}
