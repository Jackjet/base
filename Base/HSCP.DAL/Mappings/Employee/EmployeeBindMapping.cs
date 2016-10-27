//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 员工第三方登录绑定
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.07.24
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
    /// 员工第三方登录绑定
    /// </summary>
    public class EmployeeBindMapping : EntityTypeConfiguration<EmployeeBind>
    {
        public EmployeeBindMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).IsRequired();
            Property(c => c.OpenId).HasMaxLength(50);
            Property(c => c.UserId).HasMaxLength(50);
            Property(c => c.Source).HasMaxLength(20);


            ToTable("EmployeeBind");
        }
    }
}
