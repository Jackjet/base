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
    /// 库存列表
    /// </summary>
    [NotMapped]
    public class EmployeeProductViewModel : EmployeeProduct
    {
        /// <summary>
        ///开始
        /// </summary>
        public virtual TimeSpan? Stime{ get; set; }


        /// <summary>
        ///结束
        /// </summary>
        public virtual TimeSpan? Etime { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public virtual string  No { get; set; }



        /// <summary>
        /// 区域id
        /// </summary>
        public virtual int  AreaId { get; set; }



    }


    [NotMapped]
    public class StockOutInView 
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
    
        public virtual int StoreId { get; set; }


        /// <summary>
        /// 员工id
        /// </summary>
  
        public virtual int EmployeeId { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
     
        public virtual DateTime CreTime { get; set; }


        /// <summary>
        /// 是否司机
        /// </summary>
     
        public virtual int IsDriver { get; set; } 


        #region 时间段   null  没有服务  1  可服务  0  不可服务（占用）  2 预排 占用

        /// <summary>
        /// 时间段1  0.00-0.30
        /// </summary>
      
        public virtual int? Time1 { get; set; }


        /// <summary>
        /// 时间段2  
        /// </summary>
    
        public virtual int? Time2 { get; set; }


        /// <summary>
        /// 时间段3  
        /// </summary>
    
        public virtual int? Time3 { get; set; }


        /// <summary>
        /// 时间段4  
        /// </summary>
     
        public virtual int? Time4 { get; set; }



        /// <summary>
        /// 时间段5  
        /// </summary>
       
        public virtual int? Time5 { get; set; }




        /// <summary>
        /// 时间段6  
        /// </summary>
    
        public virtual int? Time6 { get; set; }




        /// <summary>
        /// 时间段7  
        /// </summary>
     
        public virtual int? Time7 { get; set; }



        /// <summary>
        /// 时间段8  
        /// </summary>
     
        public virtual int? Time8 { get; set; }



        /// <summary>
        /// 时间段9  
        /// </summary>
      
        public virtual int? Time9 { get; set; }



        /// <summary>
        /// 时间段10  
        /// </summary>
     
        public virtual int? Time10 { get; set; }



        /// <summary>
        /// 时间段11  
        /// </summary>
     
        public virtual int? Time11 { get; set; }



        /// <summary>
        /// 时间段12  
        /// </summary>
     
        public virtual int? Time12 { get; set; }



        /// <summary>
        /// 时间段13  
        /// </summary>
      
        public virtual int? Time13 { get; set; }



        /// <summary>
        /// 时间段14  
        /// </summary>
      
        public virtual int? Time14 { get; set; }




        /// <summary>
        /// 时间段15  
        /// </summary>
     
        public virtual int? Time15 { get; set; }




        /// <summary>
        /// 时间段16  
        /// </summary>
      
        public virtual int? Time16 { get; set; }




        /// <summary>
        /// 时间段17  
        /// </summary>
      
        public virtual int? Time17 { get; set; }



        /// <summary>
        /// 时间段18  
        /// </summary>
      
        public virtual int? Time18 { get; set; }




        /// <summary>
        /// 时间段19  
        /// </summary>
     
        public virtual int? Time19 { get; set; }



        /// <summary>
        /// 时间段20  
        /// </summary>
    
        public virtual int? Time20 { get; set; }



        /// <summary>
        /// 时间段21  
        /// </summary>
      
        public virtual int? Time21 { get; set; }


        /// <summary>
        /// 时间段22  
        /// </summary>
      
        public virtual int? Time22 { get; set; }



        /// <summary>
        /// 时间段23  
        /// </summary>
     
        public virtual int? Time23 { get; set; }



        /// <summary>
        /// 时间段24  
        /// </summary>
      
        public virtual int? Time24 { get; set; }



        /// <summary>
        /// 时间段25  
        /// </summary>
      
        public virtual int? Time25 { get; set; }



        /// <summary>
        /// 时间段26  
        /// </summary>
    
        public virtual int? Time26 { get; set; }


        /// <summary>
        /// 时间段27  
        /// </summary>
     
        public virtual int? Time27 { get; set; }



        /// <summary>
        /// 时间段28  
        /// </summary>
     
        public virtual int? Time28 { get; set; }






        /// <summary>
        /// 时间段29  
        /// </summary>
       
        public virtual int? Time29 { get; set; }



        /// <summary>
        /// 时间段30  
        /// </summary>
     
        public virtual int? Time30 { get; set; }



        /// <summary>
        /// 时间段31  
        /// </summary>
     
        public virtual int? Time31 { get; set; }





        /// <summary>
        /// 时间段32  
        /// </summary>
       
        public virtual int? Time32 { get; set; }



        /// <summary>
        /// 时间段33  
        /// </summary>
     
        public virtual int? Time33 { get; set; }



        /// <summary>
        /// 时间段34  
        /// </summary>
     
        public virtual int? Time34 { get; set; }




        /// <summary>
        /// 时间段35  
        /// </summary>
      
        public virtual int? Time35 { get; set; }




        /// <summary>
        /// 时间段36  
        /// </summary>
      
        public virtual int? Time36 { get; set; }




        /// <summary>
        /// 时间段37  
        /// </summary>
      
        public virtual int? Time37 { get; set; }



        /// <summary>
        /// 时间段38  
        /// </summary>
    
        public virtual int? Time38 { get; set; }



        /// <summary>
        /// 时间段39  
        /// </summary>
     
        public virtual int? Time39 { get; set; }



        /// <summary>
        /// 时间段40  
        /// </summary>
      
        public virtual int? Time40 { get; set; }



        /// <summary>
        /// 时间段41  
        /// </summary>
     
        public virtual int? Time41 { get; set; }




        /// <summary>
        /// 时间段42  
        /// </summary>
      
        public virtual int? Time42 { get; set; }




        /// <summary>
        /// 时间段43  
        /// </summary>
      
        public virtual int? Time43 { get; set; }




        /// <summary>
        /// 时间段44  
        /// </summary>
      
        public virtual int? Time44 { get; set; }



        /// <summary>
        /// 时间段45  
        /// </summary>
      
        public virtual int? Time45 { get; set; }





        /// <summary>
        /// 时间段46  
        /// </summary>
      
        public virtual int? Time46 { get; set; }




        /// <summary>
        /// 时间段47  
        /// </summary>
     
        public virtual int? Time47 { get; set; }




        /// <summary>
        /// 时间段48  
        /// </summary>
      
        public virtual int? Time48 { get; set; }

        #endregion



        public virtual int? week { get; set; }

        public virtual int? AreaId { get; set; }

        public virtual int? PrdouctId { get; set; }

    }



    }
