//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：广告图片
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.06.22
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
    /// 广告图片
    /// </summary>
    public class AdvertisingImageMapping : EntityTypeConfiguration<AdvertisingImage>
    {
        public AdvertisingImageMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
            Property(c => c.Img).HasMaxLength(200);
            Property(c => c.Link).HasMaxLength(100);
            ToTable("AdvertisingImage");
        }
    }
}
