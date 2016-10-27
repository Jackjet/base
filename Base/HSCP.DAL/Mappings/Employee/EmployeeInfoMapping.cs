/****************************************************** 

    文件名称：EmployeeInfoMapping.cs
    功能描述：员工信息
    作    者：Jxw
    日    期：2016.07.14
    修改记录：

*******************************************************/

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL.Mappings.Employee
{
    public class EmployeeInfoMapping : EntityTypeConfiguration<EmployeeInfo>
    {

        public EmployeeInfoMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
            //Property(c => c.Hometown).HasMaxLength(50);
            Property(c => c.IDCard).HasMaxLength(18);
            Property(c => c.Nation).HasMaxLength(50);
            Property(c => c.Salary).HasMaxLength(50);
            Property(c => c.Hometown).HasMaxLength(50);
            Property(c => c.Specialty).HasMaxLength(100);
            Property(c => c.Ability).HasMaxLength(100);
            Property(c => c.Experience).HasMaxLength(200);

            Property(c => c.Family).HasMaxLength(200);
            Property(c => c.Training).HasMaxLength(200);
            Property(c => c.Banks).HasMaxLength(50);

            Property(c => c.OpenAccount).HasMaxLength(50);
            Property(c => c.BankCards).HasMaxLength(20);

            ToTable("EmployeeInfo");
        }

    }
}
