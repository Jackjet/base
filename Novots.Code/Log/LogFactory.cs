/*******************************************************************************
 * Copyright © 2016 Conan.Framework 版权所有
 * Author: Conan
 * Description: Conan快速开发平台
 * Website：http://www.Conan.com
*********************************************************************************/
using log4net;
using System;
using System.IO;
using System.Web;

namespace Conan.Code
{
    public class LogFactory
    {
        static LogFactory()
        {
            FileInfo configFile = new FileInfo(HttpContext.Current.Server.MapPath("/Configs/log4net.config"));
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        public static Log GetLogger(Type type)
        {
            return new Log(LogManager.GetLogger(type));
        }
        public static Log GetLogger(string str)
        {
            return new Log(LogManager.GetLogger(str));
        }
    }
}
