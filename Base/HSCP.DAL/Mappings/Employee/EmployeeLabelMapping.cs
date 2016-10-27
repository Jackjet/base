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
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings
{
    /// <summary>
    /// 员工标签
    /// </summary>
    public class EmployeeLabelMapping : EntityTypeConfiguration<EmployeeLabel>
    {
        public EmployeeLabelMapping() {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
            Property(c => c.Name).HasMaxLength(20);
            ToTable("EmployeeLabel");
        }
    }
}
