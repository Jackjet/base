using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    /// <summary>
    /// 随机码
    /// </summary>
    public class RandomCode
    {
        public static string Number(int len)
        {
            Random random = new Random();
            char[] array = "1234567890".ToCharArray();
            int maxValue = array.Length - 1;
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                int n = random.Next(1, 10000) % 10;
                text.Append(array[n].ToString());
                random.NextDouble();
                random.Next(100, 1999);
            }
            return text.ToString();
        }
    }
}
