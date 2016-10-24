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
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new Cache();
        }
    }
}
