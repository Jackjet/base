//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：价格模板实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.04.28
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************

using System;

namespace Conan.Model
{
    public class PriceTempletViewModel
    {
        /// <summary>
        /// 价格模板Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 产品
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public PriceTempletStateEnum State { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime EditTime { get; set; }
    }
}
