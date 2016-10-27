//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：资金流水
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.12
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
    /// 资金流水
    /// </summary>
    public class CashJournalMapping : EntityTypeConfiguration<CashJournal>
    {
        public CashJournalMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
            Property(c => c.Remark).HasMaxLength(100);
            Property(c => c.TraNumber).HasMaxLength(50);
            Property(c => c.RelationId).HasMaxLength(50);
            ToTable("CashJournal");
        }
    }
}
