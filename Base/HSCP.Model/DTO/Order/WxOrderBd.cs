using Conan.Model;
using System;
using System.Collections.Generic;

namespace Conan.Model
{
    /// <summary>
    /// WxOrderBd
    /// </summary>
    public class WxOrderBd
    {
        //#region 可选项  材料

        ///// <summary>
        ///// 材料编号
        ///// </summary>

        //public virtual string[] OrderMaterialCode { get; set; }

        ///// <summary>
        ///// 材料名称
        ///// </summary>

        //public virtual string[] OrderMaterialName { get; set; }


        ///// <summary>
        ///// 材料金额（单价）
        ///// </summary>

        //public virtual string[] OrderMaterialWage { get; set; }

        ///// <summary>
        ///// 材料金额 总价
        ///// </summary>

        //public virtual string[] OrderMaterialTotalWage { get; set; }


        ///// <summary>
        ///// 数量
        ///// </summary>

        //public virtual string[] OrderMaterialNum { get; set; }




        ///// <summary>
        ///// 单位
        ///// </summary>

        //public virtual string[] OrderMaterialUnit { get; set; }


        //#endregion

        #region 补材料
        /// <summary>
        /// 材料 编号
        /// </summary>
        public virtual string[] MaterialSNo { get; set; }

        /// <summary>
        /// 材料金额
        /// </summary>

        public virtual string[] MaterialWage { get; set; }

        #endregion
        #region 补单指定人员
        /// <summary>
        /// 车辆 编号
        /// </summary>
        public virtual string[] SCCode { get; set; }


        /// <summary>
        /// 司机 编号
        /// </summary>
        public virtual string[] SCarCode { get; set; }




        /// <summary>
        /// 人员 编号
        /// </summary>
        public virtual string[] SNo { get; set; }

        /// <summary>
        /// 人员名称
        /// </summary>
        public virtual string[] SName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual string[] STel { get; set; }





        #endregion

        #region 补材料
        /// <summary>
        /// 数量
        /// </summary>
        public virtual string[] Snum { get; set; }


        /// <summary>
        /// 总价格
        /// </summary>
        public virtual string[] Samount { get; set; }
        #endregion

        /// <summary>
        /// 客户Id
        /// </summary>
        public virtual int MemberId { get; set; }


        /// <summary>
        /// 子单号
        /// </summary>
        public virtual string BillItemNo { get; set; }



        /// <summary>
        /// 单据号
        /// </summary>
        public virtual string BillNo { get; set; }


        /// <summary>
        /// 业务渠道
        /// </summary>
        public virtual int BusinessChannel { get; set; }

   

        /// <summary>
        /// 开发人
        /// </summary>
        public virtual string Developer { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        public virtual int StoreId { get; set; }





        /// <summary>
        /// 所属产品id  服务项目
        /// </summary>
        public virtual int ProductId { get; set; }

    

      

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual string Contact { get; set; } = "";
        /// <summary>
        /// 联系电话
        /// </summary>
        public virtual string Tel { get; set; } = "";


        /// <summary>
        /// 服务开始时间
        /// </summary>

        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 服务结束时间
        /// </summary>
      
        public virtual DateTime? EndTime { get; set; }




        /// <summary>
        /// 员工编号/车辆编号  指定服务
        /// </summary>
        public virtual string[] ServiceNo { get; set; }

        /// <summary>
        /// 服务员工/车辆  类型  指定服务
        /// </summary>
        public virtual int[] WaiterType { get; set; }



        //sku  待实现



        /// <summary>
        /// 服务备注
        /// </summary>
        public virtual string ServiceRemark { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        public virtual string Remark { get; set; }
        /// <summary>
        /// 是否使用余额支付
        /// </summary>
        public virtual int IsRequired { get; set; }


        /// <summary>
        /// 是否面议
        /// </summary>
        public virtual int IsFace { get; set; }


      

        /// <summary>
        /// 子订单金额
        /// </summary>
        public virtual string OrderSubPrices { get; set; }


    }

}