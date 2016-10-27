using System;
using System.Collections.Generic;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
  /// <summary>
  /// 小区表
  /// </summary>
    public partial class RQuarters : Entity<int>
    {
        /// <summary>
        /// 小区编号
        /// </summary>
        [Description("小区编号")]
        public virtual string Code { get; set; }


        /// <summary>
        /// 小区名称
        /// </summary>
        [Description("小区名称")]
        public virtual string Name { get; set; }


        /// <summary>
        /// 小区拼音
        /// </summary>
        [Description("小区拼音")]
        public virtual string Pinyin { get; set; }


        /// <summary>
        /// 小区首拼
        /// </summary>
        [Description("小区首拼")]
        public virtual string Sp{ get; set; }




        /// <summary>
        /// 经度
        /// </summary>
        [Description("经度")]
        public virtual double Lng { get; set; }


        /// <summary>
        /// 纬度
        /// </summary>
        [Description("纬度")]
        public virtual double Lat { get; set; } 






        /// <summary>
        /// 城市ID
        /// </summary>
        [Description("城市ID")]
        public virtual int CityId { get; set; } = 0;
        /// <summary>
        /// 区域id 
        /// </summary>
        [Description("区域id")]
        public virtual int AreaId { get; set; } = 0;


        /// <summary>
        /// 状态  1  启用  0  禁用 
        /// </summary>
        [Description("状态")]
        public virtual int Status { get; set; }



        /// <summary>
        /// 详细地址
        /// </summary>
        [Description("详细地址")]
        public virtual string  Addr { get; set; }


    }
}
