/*******************************************************************************
 * Copyright © 2016 Novots.Framework 版权所有
 * Author: Novots
 * Description: Novots快速开发平台
 * Website：http://www.Novots.com
*********************************************************************************/
using Novots.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Novots.Mapping.SystemManage
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            this.ToTable("Sys_User");
            this.HasKey(t => t.F_Id);
        }
    }
}
