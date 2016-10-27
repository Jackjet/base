using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    public class neighborhood
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> type { get; set; }

    }



    public class building
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> type { get; set; }

    }



    public class geocodesItem
    {
        /// <summary>
        /// 福建省泉州市南安市新明村
        /// </summary>
        public string formatted_address { get; set; }

        /// <summary>
        /// 福建省
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string citycode { get; set; }

        /// <summary>
        /// 泉州市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 南安市
        /// </summary>
        public string district { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> township { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public neighborhood neighborhood { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public building building { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string adcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> street { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// 村庄
        /// </summary>
        public string level { get; set; }

    }



    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string infocode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<geocodesItem> geocodes { get; set; }

    }

}
