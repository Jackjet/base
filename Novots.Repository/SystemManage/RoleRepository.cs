/*******************************************************************************
 * Copyright © 2016 Conan.Framework 版权所有
 * Author: Conan
 * Description: Conan快速开发平台
 * Website：http://www.Conan.com
*********************************************************************************/
using Conan.Data;
using Conan.Domain.Entity.SystemManage;
using Conan.Domain.IRepository.SystemManage;
using Conan.Repository.SystemManage;
using System.Collections.Generic;

namespace Conan.Repository.SystemManage
{
    public class RoleRepository : RepositoryBase<RoleEntity>, IRoleRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<RoleEntity>(t => t.F_Id == keyValue);
                db.Delete<RoleAuthorizeEntity>(t => t.F_ObjectId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntitys, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(roleEntity);
                }
                else
                {
                    roleEntity.F_Category = 1;
                    db.Insert(roleEntity);
                }
                db.Delete<RoleAuthorizeEntity>(t => t.F_ObjectId == roleEntity.F_Id);
                db.Insert(roleAuthorizeEntitys);
                db.Commit();
            }
        }
    }
}
