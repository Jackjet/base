/*******************************************************************************
 * Copyright © 2016 Conan.Framework 版权所有
 * Author: Conan
 * Description: Conan快速开发平台
 * Website：http://www.Conan.com
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Code
{
    public interface ICache
    {
        T GetCache<T>(string cacheKey) where T : class;
        void WriteCache<T>(T value, string cacheKey) where T : class;
        void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class;
        void RemoveCache(string cacheKey);
        void RemoveCache();
    }
}
