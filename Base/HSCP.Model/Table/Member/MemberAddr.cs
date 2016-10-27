/****************************************************** 

    文件名称：MemberAddr.cs
    功能描述：会员联系地址
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/

using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 会员联系地址
    /// </summary>
    public class MemberAddr : Entity<int>
    {
        /// <summary>
        /// 会员Id
        /// </summary>
        public virtual int MemberId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public virtual string Phone { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public virtual string City { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public virtual string Area { get; set; }
        /// <summary>
        /// 街道
        /// </summary>
        public virtual string Street { get; set; }
        /// <summary>
        /// 公交站
        /// </summary>
        public virtual string BugStop { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public virtual double? Lng { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public virtual double? Lat { get; set; }
        /// <summary>
        /// 市Id
        /// </summary>
        public virtual int CityId { get; set; }
        /// <summary>
        /// 区Id
        /// </summary>
        public virtual int AreaId { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public virtual bool IsDefault { get; set; }

        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 小区Id
        /// </summary>
        public virtual int RQuartersId { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public virtual string  RQuartersName { get; set; }



    }
}