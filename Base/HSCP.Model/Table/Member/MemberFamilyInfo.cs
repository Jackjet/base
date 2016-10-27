/****************************************************** 

    文件名称：MemberFamilyInfo.cs
    功能描述：家庭信息表
    作    者：Jxw
    日    期：2016.05.10
    修改记录：

*******************************************************/
using System;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 家庭信息表
    /// </summary>
    public class MemberFamilyInfo : Entity<int>
    {
        /// <summary>
        /// 服务地址ID
        /// </summary>
        public virtual int MemberAddrId { get; set; }

        /// <summary>
        /// 房间数量
        /// </summary>
        public virtual int Room { set; get; }
        /// <summary>
        /// 大厅数量
        /// </summary>
        public virtual int Hall { set; get; }
        /// <summary>
        /// 厨房数量
        /// </summary>
        public virtual int Kitchen { set; get; }
        /// <summary>
        /// 卫生间数量
        /// </summary>
        public virtual int BathRoom { set; get; }
        /// <summary>
        /// 阳台数量
        /// </summary>
        public virtual int Balcony { set; get; }
        /// <summary>
        /// 是否有冰箱
        /// </summary>
        public virtual bool HasFridge { set; get; }
        /// <summary>
        /// 是否有空调
        /// </summary>
        public virtual bool HasAirCondition { set; get; }
        /// <summary>
        /// 是否有抽油烟机
        /// </summary>
        public virtual bool HasRangeHood { set; get; }
        /// <summary>
        /// 是否有煤气灶
        /// </summary>
        public virtual bool HasGasStoves { set; get; }
        /// <summary>
        /// 是否有老人
        /// </summary>
        public virtual bool HasOldMan { set; get; }
        /// <summary>
        /// 是否有小孩
        /// </summary>
        public virtual bool HasChild { set; get; }
        /// <summary>
        /// 房间大小
        /// </summary>
        public virtual int RoomSize { set; get; }
        /// <summary>
        /// 是否有电视
        /// </summary>
        public virtual bool HasTV { set; get; }
        /// <summary>
        /// 是否有孕妇
        /// </summary>
        public virtual bool HasPregnantWoman { set; get; }
        /// <summary>
        /// 是否有洗衣机
        /// </summary>
        public virtual bool HasWashingMachine { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }
    }
}
