using System;
//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：兑换优惠券
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.06.30
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Model
{

    /// <summary>
    /// 兑换优惠券
    /// </summary>
    public class CouponExchange
    {
        /// <summary>
        /// 兑换优惠券Key
        /// </summary>
        public virtual string Key { get; set; }
    }
}
