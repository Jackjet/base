/*******************************************************************************
 * Copyright © 2016 Novots.Framework 版权所有
 * Author: Novots
 * Description: Novots快速开发平台
 * Website：http://www.Novots.com
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novots.Code
{
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new Cache();
        }
    }
}
