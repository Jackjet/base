using Conan.Model;
using System;
using System.Collections.Generic;

namespace Conan.Model
{
    /// <summary>
    /// 订单添加
    /// </summary>
    public class OrderAdd
    {
        #region 可选项  材料

        /// <summary>
        /// 材料编号
        /// </summary>

        public virtual string[] OrderMaterialCode { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>

        public virtual string[] OrderMaterialName { get; set; }


        /// <summary>
        /// 材料金额（单价）
        /// </summary>

        public virtual string[] OrderMaterialWage { get; set; }

        /// <summary>
        /// 材料金额 总价
        /// </summary>

        public virtual string[] OrderMaterialTotalWage { get; set; }


        /// <summary>
        /// 数量
        /// </summary>

        public virtual string[] OrderMaterialNum { get; set; }




        /// <summary>
        /// 单位
        /// </summary>

        public virtual string[] OrderMaterialUnit { get; set; }


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

        #region 合同时间
        /// <summary>
        /// 合同开始时间
        /// </summary>
        public virtual DateTime? htStartTime { get; set; }
        /// <summary>
        /// 合同结束时间
        /// </summary>
        public virtual DateTime? htendTime { get; set; } 
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

        #region 出发地

        /// <summary>
        ///服务 地址id  出发地
        /// </summary>
        public virtual int Rid { get; set; }
        /// <summary>
        /// 市id
        /// </summary>
        public virtual int CityId { get; set; }
        /// <summary>
        /// 区域id
        /// </summary>
        public virtual int AreaId { get; set; }



        /// <summary>
        /// 详细地址
        /// </summary>
        public virtual string Street { get; set; } = "";

        /// <summary>
        /// 公交站点
        /// </summary>
        public virtual string BusStation { get; set; } = "";


        #endregion

        #region 目的地

        /// <summary>
        ///服务 地址id  目的地
        /// </summary>
        public virtual int ERid { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public virtual int EndCityId { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public virtual int EndAreaId { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public virtual string EndStreet { get; set; } = "";



        /// <summary>
        /// 公交站点
        /// </summary>
        public virtual string EndBusStation { get; set; } = "";


        #endregion

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


        #region  添加 sku 
        /// <summary>
        /// sku1 -添加 sku 
        /// </summary>
        public virtual string Sku1 { get; set; } = "";
        /// <summary>
        /// sku2-添加 sku 
        /// </summary>
        public virtual string Sku2 { get; set; } = "";

        /// <summary>
        /// sku3-添加 sku 
        /// </summary>
        public virtual string Sku3 { get; set; } = "";

        /// <summary>
        /// 销售属性1-添加 sku 
        /// </summary>
        public virtual int sale1 { get; set; } = 0;

        /// <summary>
        /// 销售属性2-添加 sku 
        /// </summary>
        public virtual int sale2 { get; set; } =0;


        /// <summary>
        /// 销售属性id1-添加 sku 
        /// </summary>
        public virtual int SkuUnitId1 { get; set; } = 0;

        /// <summary>
        /// 销售属性id2-添加 sku 
        /// </summary>
        public virtual int SkuUnitId2 { get; set; } = 0;
        #endregion

        /// <summary>
        /// 子订单金额
        /// </summary>
        public virtual string OrderSubPrices { get; set; }

        #region  提交sku

        /// <summary>
        /// sku1
        /// </summary>
        public virtual string[] SkuName1 { get; set; }

        /// <summary>
        /// sku2
        /// </summary>
        public virtual string[] SkuName2 { get; set; }

        /// <summary>
        /// sku3
        /// </summary>
        public virtual string[] SkuName3 { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual string[] SinPrice { get; set; }

        /// <summary>
        /// 销售id1
        /// </summary>
        public virtual int[] SalesId1 { get; set; }

        /// <summary>
        /// 销售1数量
        /// </summary>
        public virtual int[] SalesIdNum1 { get; set; }

        /// <summary>
        /// 销售id2
        /// </summary>
        public virtual int[] SalesId2 { get; set; }

        /// <summary>
        /// 销售2数量
        /// </summary>
        public virtual int[] SalesIdNum2 { get; set; }

        /// <summary>
        /// sku 总价格
        /// </summary>
        public virtual string[] TotalOrderPrices { get; set; }

        #endregion


    }

    #region 子订单明细sku描述
    /// <summary>
    /// 子订单明细sku描述
    /// </summary>
    //public class OrderItemSkuDes
    //{

    //    /// <summary>
    //    /// sku1
    //    /// </summary>
    //    public virtual string SkuName1 { get; set; }

    //    /// <summary>
    //    /// sku2
    //    /// </summary>
    //    public virtual string SkuName2 { get; set; }

    //    /// <summary>
    //    /// sku3
    //    /// </summary>
    //    public virtual string SkuName3 { get; set; }



    //    /// <summary>
    //    /// 单价
    //    /// </summary>
    //    public virtual string SinPrice { get; set; }



    //    /// <summary>
    //    /// 销售id1
    //    /// </summary>
    //    public virtual int SalesId1 { get; set; }


    //    /// <summary>
    //    /// 销售1数量
    //    /// </summary>
    //    public virtual int SalesIdNum1 { get; set; }



    //    /// <summary>
    //    /// 销售id2
    //    /// </summary>
    //    public virtual int SalesId2 { get; set; }


    //    /// <summary>
    //    /// 销售2数量
    //    /// </summary>
    //    public virtual int SalesIdNum2 { get; set; }



    //    /// <summary>
    //    /// sku 总价格
    //    /// </summary>
    //    public virtual string TotalOrderPrices { get; set; }




    //}

    public class SkuDes
    {
        /// <summary>
        /// sku
        /// </summary>
        public List<string> SkuNames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Unit> Units { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public virtual string SinPrice { get; set; }

        /// <summary>
        /// sku 总价格
        /// </summary>
        public virtual string TotalOrderPrices { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }


    #endregion

}