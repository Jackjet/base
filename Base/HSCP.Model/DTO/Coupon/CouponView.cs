using System;
/*
 * 作者：conan   
 * 日期：2016.05.23  
 * 描述：优惠券   
 * 修改记录：    
 * */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Model
{
  
    /// <summary>
    /// 优惠券支付
    /// </summary>
    public class CouponView
    {
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }


        /// <summary>
        /// 面值
        /// </summary>
        public virtual decimal FaceValue { get; set; }
        /// <summary>
        /// 实际值  如果是赠送 的 RealValue=0  在财务统计中有用
        /// </summary>
        public virtual decimal RealValue { get; set; }


        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// 限制服务产品
        /// </summary>
        public virtual string  ProductStr { get; set; }

        /// <summary>
        /// 时间段
        /// </summary>
        public virtual string TimeStr { get; set; }

    }

    /// <summary>
    /// 选中的优惠券
    /// </summary>
    public class CouponSelect
    {
       /// <summary>
       /// 张数
       /// </summary>
        public int CNum { get; set; }
        /// <summary>
        /// 优惠面值
        /// </summary>
        public string  CyVale { get; set; }


        /// <summary>
        /// 面值
        /// </summary>
        public string CVale { get; set; }
    }
    }
