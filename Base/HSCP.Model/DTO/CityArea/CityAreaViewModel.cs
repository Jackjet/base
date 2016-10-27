using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class CityAreaViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 城市名称或地区
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 名称拼音
        /// </summary>
        public string Pinyin { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 城市拼音
        /// </summary>
        public string CityPinyin { get; set; }
        /// <summary>
        /// 城市排序
        /// </summary>
        public int CitySort { get; set; }

        public int RegionId { get; set; }


        public string RegionName { get; set; }

    }
}
