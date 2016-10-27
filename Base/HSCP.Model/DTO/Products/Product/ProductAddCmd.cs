//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：产品添加实体
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.04.28
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************
namespace Conan.Model
{
    /// <summary>
    /// 产品添加类
    /// </summary>
    public class ProductAddCmd
    {    
        /// <summary>
        ///Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        ///产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// 产品简介
        /// </summary>
        public string Discription { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Banner
        /// </summary>
        public string Banner { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 是否可拆单
        /// </summary>
        public bool IsSplit { get; set; }
        /// <summary>
        ///是否可指定员工
        /// </summary>
        public bool IsEmployee { get; set; }
        /// <summary>
        /// 是否校验库存
        /// </summary>
        public int IsVerifyStock { get; set; }
        /// <summary>
        /// 预定提前时间 小时
        /// </summary>
        public int? PresaleMin { get; set; }
        /// <summary>
        /// 最大预售期 天
        /// </summary>
        public int? PresaleMax { get; set; }
        /// <summary>
        /// 关联普通产品编号
        /// </summary>
        public string RelatedProductCode { get; set; }
        public int? RelatedProductId { get; set; }
    }
}