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
    public class DBConnection
    {
        public static bool Encrypt { get; set; }
        public DBConnection(bool encrypt)
        {
            Encrypt = encrypt;
        }
        public static string connectionString
        {
            get
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["ConanDbContext"].ConnectionString;
                if (Encrypt == true)
                {
                    return DESEncrypt.Decrypt(connection);
                }
                else
                {
                    return connection;
                }
            }
        }
    }
}
