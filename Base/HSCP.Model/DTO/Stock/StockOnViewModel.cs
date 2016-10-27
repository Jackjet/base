//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016‎.‎06.02‎
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conan.Model
{
    /// <summary>
    /// 库存设置列表
    /// </summary>
    [NotMapped]
    public class StockOnViewModel :Employee
    {
        /// <summary>
        ///时间管理
        /// </summary>
        public virtual string TimeStr{ get; set; }



        /// <summary>
        ///上午
        /// </summary>
        public virtual string MorningStr { get; set; }

        /// <summary>
        ///下午
        /// </summary>
        public virtual string AfternoonStr { get; set; }

        /// <summary>
        ///晚间
        /// </summary>
        public virtual string EveningStr { get; set; }





    }


    [NotMapped]
    public class EmployeeStockOnViewModel : Inventory
    {

      
        public virtual int week { get; set; }
        public virtual int AreaId { get; set; }
        public virtual int PrdouctId { get; set; }


        /// <summary>
        ///员工编号
        /// </summary>
        public virtual string No { get; set; }

    }

    /// <summary>
    /// 账单催收表
    /// </summary>
    
    public class OrderqkViewModel 
    {
        public int CityId { get; set; }

        public int AreaId { get; set; }

        /// <summary>
        /// 是否瞒报
        /// </summary>
        public virtual string ismb { get; set; }

        /// <summary>
        /// 总订单号
        /// </summary>

        public virtual string BillNo { get; set; }

        /// <summary>
        /// 修改之后的总金额  - （总订单分单）  一般是和订单金额一样      
        /// </summary>
 
        public virtual decimal RealTotalAmount { get; set; }

       
       
        /// <summary>
        /// 产品名称(描述) 服务项目
        /// </summary>
    
        public virtual string ProductName { get; set; }
        
     

        /// <summary>
        /// 预约服务开始时间
        /// </summary>
     
        public virtual DateTime StartTime { get; set; }
     





        /// <summary>
        /// 门店名称
        /// </summary>
        public virtual string StoreName { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Street { get; set; }

        /// <summary>
        /// 欠款
        /// </summary>
        public virtual decimal qk { get; set; }


        /// <summary>
        /// 服务人员/车辆
        /// </summary>
        public virtual string ServiceNo { get; set; }

    }

  



}
