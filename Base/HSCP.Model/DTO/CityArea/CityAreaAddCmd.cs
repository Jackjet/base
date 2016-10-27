using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class CityAreaAddCmd
    {
        /// <summary>
        /// 大区id
        /// </summary>
        public int RegionId { get; set; }

        public int Id { get; set; }

        /// <summary>
        /// 城市名称或地区
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 名称拼音
        /// </summary>
        public string Pinyin { get; set; }

        public int CityId { get; set; }

        public int State { get; set; }

        public int Sort { get; set; }

        public bool IsEdit { get; set; }
    }
}
