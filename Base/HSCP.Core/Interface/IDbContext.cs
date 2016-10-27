/****************************************************** 

    文件名称：IDbContext.cs
    功能描述： 
    作    者：Jxw
    日    期：2016.04.19
    修改记录：

*******************************************************/

using System;
using System.Threading.Tasks;

namespace Conan.Core
{
    public interface IDbContext: IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
