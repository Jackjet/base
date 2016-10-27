/****************************************************** 
    文件名称：
    功能描述：库存
    作    者：conan
    日    期：2016.06.02
    修改记录：

*******************************************************/
using System;
using System.ComponentModel;
using Conan.Core;

namespace Conan.Model
{
    /// <summary>
    /// 库存
    /// </summary>
    public class Inventory : Entity<int>
    {


        /// <summary>
        /// 门店id
        /// </summary>
        [Description("门店id")]
        public virtual int StoreId { get; set; }


        /// <summary>
        /// 员工id
        /// </summary>
        [Description("员工id")]
        public virtual int EmployeeId { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Description("日期")]
        public virtual DateTime CreTime { get; set; }


        /// <summary>
        /// 是否司机
        /// </summary>
        [Description("是否司机")]
        public virtual bool IsDriver { get; set; } = false;


        #region 时间段   null  没有服务  1  可服务  0  不可服务（占用）  2 预排 占用

        /// <summary>
        /// 时间段1  0.00-0.30
        /// </summary>
        [Description("时间段1")]
        public virtual int? Time1 { get; set; }


        /// <summary>
        /// 时间段2  
        /// </summary>
        [Description("时间段2")]
        public virtual int? Time2 { get; set; } 


        /// <summary>
        /// 时间段3  
        /// </summary>
        [Description("时间段3")]
        public virtual int? Time3 { get; set; } 


        /// <summary>
        /// 时间段4  
        /// </summary>
        [Description("时间段4")]
        public virtual int? Time4 { get; set; } 



        /// <summary>
        /// 时间段5  
        /// </summary>
        [Description("时间段5")]
        public virtual int? Time5 { get; set; }




        /// <summary>
        /// 时间段6  
        /// </summary>
        [Description("时间段6")]
        public virtual int? Time6 { get; set; } 




        /// <summary>
        /// 时间段7  
        /// </summary>
        [Description("时间段7")]
        public virtual int? Time7 { get; set; } 



        /// <summary>
        /// 时间段8  
        /// </summary>
        [Description("时间段8")]
        public virtual int? Time8 { get; set; } 



        /// <summary>
        /// 时间段9  
        /// </summary>
        [Description("时间段9")]
        public virtual int? Time9 { get; set; } 



        /// <summary>
        /// 时间段10  
        /// </summary>
        [Description("时间段10")]
        public virtual int? Time10 { get; set; } 



        /// <summary>
        /// 时间段11  
        /// </summary>
        [Description("时间段11")]
        public virtual int? Time11 { get; set; } 



        /// <summary>
        /// 时间段12  
        /// </summary>
        [Description("时间段12")]
        public virtual int? Time12 { get; set; }



        /// <summary>
        /// 时间段13  
        /// </summary>
        [Description("时间段13")]
        public virtual int? Time13 { get; set; } 



        /// <summary>
        /// 时间段14  
        /// </summary>
        [Description("时间段14")]
        public virtual int? Time14 { get; set; } 




        /// <summary>
        /// 时间段15  
        /// </summary>
        [Description("时间段15")]
        public virtual int? Time15 { get; set; } 




        /// <summary>
        /// 时间段16  
        /// </summary>
        [Description("时间段16")]
        public virtual int? Time16 { get; set; } 




        /// <summary>
        /// 时间段17  
        /// </summary>
        [Description("时间段17")]
        public virtual int? Time17 { get; set; } 



        /// <summary>
        /// 时间段18  
        /// </summary>
        [Description("时间段18")]
        public virtual int? Time18 { get; set; } 




        /// <summary>
        /// 时间段19  
        /// </summary>
        [Description("时间段19")]
        public virtual int? Time19 { get; set; } 



        /// <summary>
        /// 时间段20  
        /// </summary>
        [Description("时间段20")]
        public virtual int? Time20 { get; set; } 



        /// <summary>
        /// 时间段21  
        /// </summary>
        [Description("时间段21")]
        public virtual int? Time21 { get; set; } 


        /// <summary>
        /// 时间段22  
        /// </summary>
        [Description("时间段22")]
        public virtual int? Time22 { get; set; } 



        /// <summary>
        /// 时间段23  
        /// </summary>
        [Description("时间段23")]
        public virtual int? Time23 { get; set; } 



        /// <summary>
        /// 时间段24  
        /// </summary>
        [Description("时间段24")]
        public virtual int? Time24 { get; set; } 



        /// <summary>
        /// 时间段25  
        /// </summary>
        [Description("时间段25")]
        public virtual int? Time25 { get; set; } 



        /// <summary>
        /// 时间段26  
        /// </summary>
        [Description("时间段26")]
        public virtual int? Time26 { get; set; } 


        /// <summary>
        /// 时间段27  
        /// </summary>
        [Description("时间段27")]
        public virtual int? Time27 { get; set; } 



        /// <summary>
        /// 时间段28  
        /// </summary>
        [Description("时间段28")]
        public virtual int? Time28 { get; set; } 






        /// <summary>
        /// 时间段29  
        /// </summary>
        [Description("时间段29")]
        public virtual int? Time29 { get; set; } 



        /// <summary>
        /// 时间段30  
        /// </summary>
        [Description("时间段30")]
        public virtual int? Time30 { get; set; } 



        /// <summary>
        /// 时间段31  
        /// </summary>
        [Description("时间段31")]
        public virtual int? Time31 { get; set; } 





        /// <summary>
        /// 时间段32  
        /// </summary>
        [Description("时间段32")]
        public virtual int? Time32 { get; set; } 



        /// <summary>
        /// 时间段33  
        /// </summary>
        [Description("时间段33")]
        public virtual int? Time33 { get; set; }



        /// <summary>
        /// 时间段34  
        /// </summary>
        [Description("时间段34")]
        public virtual int? Time34 { get; set; } 




        /// <summary>
        /// 时间段35  
        /// </summary>
        [Description("时间段35")]
        public virtual int? Time35 { get; set; }




        /// <summary>
        /// 时间段36  
        /// </summary>
        [Description("时间段36")]
        public virtual int? Time36 { get; set; } 




        /// <summary>
        /// 时间段37  
        /// </summary>
        [Description("时间段37")]
        public virtual int? Time37 { get; set; }



        /// <summary>
        /// 时间段38  
        /// </summary>
        [Description("时间段38")]
        public virtual int? Time38 { get; set; }



        /// <summary>
        /// 时间段39  
        /// </summary>
        [Description("时间段39")]
        public virtual int? Time39 { get; set; }



        /// <summary>
        /// 时间段40  
        /// </summary>
        [Description("时间段40")]
        public virtual int? Time40 { get; set; }



        /// <summary>
        /// 时间段41  
        /// </summary>
        [Description("时间段41")]
        public virtual int? Time41 { get; set; }




        /// <summary>
        /// 时间段42  
        /// </summary>
        [Description("时间段42")]
        public virtual int? Time42 { get; set; }




        /// <summary>
        /// 时间段43  
        /// </summary>
        [Description("时间段43")]
        public virtual int? Time43 { get; set; }




        /// <summary>
        /// 时间段44  
        /// </summary>
        [Description("时间段44")]
        public virtual int? Time44 { get; set; } 



        /// <summary>
        /// 时间段45  
        /// </summary>
        [Description("时间段45")]
        public virtual int? Time45 { get; set; } 





        /// <summary>
        /// 时间段46  
        /// </summary>
        [Description("时间段46")]
        public virtual int? Time46 { get; set; }




        /// <summary>
        /// 时间段47  
        /// </summary>
        [Description("时间段47")]
        public virtual int? Time47 { get; set; } 




        /// <summary>
        /// 时间段48  
        /// </summary>
        [Description("时间段48")]
        public virtual int? Time48 { get; set; } 

        #endregion

    }
}