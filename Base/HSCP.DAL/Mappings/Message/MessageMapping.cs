//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：资金流水
/*
 * 作者：Ldw    
 * 日期：2016.06.18  
 * 描述：消息中心
 * 修改记录：    
 * */
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Conan.Model;

namespace Conan.DAL
{
    /// <summary>
    /// 消息中心
    /// </summary>
    public class MessageMapping : EntityTypeConfiguration<Message>
    {
        public MessageMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
                .IsRequired();
         
            ToTable("Message");
        }
    }
}
