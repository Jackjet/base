//*************************** 
//文件名称(File Name)： 
//功能描述(Description)： 订单改价
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using HSCP.Core;
using System.ComponentModel;

namespace HSCP.Model
{
    /// <summary>
    /// 订单改价
    /// </summary>
    public partial class OrderChange : Entity<int>
    {
      

        /// <summary>
        /// 总订单号
        /// </summary>
        [Description("总订单号")]
        public virtual string BillNo { get; set; }


        /// <summary>
        /// 订单金额             
        /// </summary>
        [Description("订单金额")]
        public virtual decimal SoureAmount { get; set; }


        /// <summary>
        /// 修改后订单金额             
        /// </summary>
        [Description("修改后订单金额")]
        public virtual decimal EndAmount { get; set; }


        /// <summary>
        /// 发生金额             
        /// </summary>
        [Description("发生金额")]
        public virtual decimal ChangeAmount { get; set; }



        /// <summary>
        /// 改价原因 
        /// </summary>
        [Description("改价原因")]
        public virtual OrdechangeEnum   Ordechange { get; set; }


        /// <summary>
        /// 操作人
        /// </summary>
        [Description("操作人")]
        public virtual string Developer { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Description("操作时间")]
        public virtual DateTime? CreDateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public virtual string Remark { get; set; }

  

    }
}