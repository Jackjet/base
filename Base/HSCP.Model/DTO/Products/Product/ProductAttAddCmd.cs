//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：产品属性
//数据表(Tables)：    
//作者(Author)： Xrp
//日期(Create Date)： 2016.06.2
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//***************************
namespace Conan.Model
{
    /// <summary>
    /// 产品属性
    /// </summary>
    public class ProductAttAddCmd
    {
        /// <summary>
        ///产品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 是否可拆单
        /// </summary>
        public bool IsSplit { get; set; } = false;
        /// <summary>
        /// 是否可指定员工
        /// </summary>
        public bool IsEmployee { get; set; } = false;
        /// <summary>
        ///关联普通产品编号
        /// </summary>
        public string RelatedProductCode { get; set; }
        /// <summary>
        /// 理论工时
        /// </summary>
        public double TheoreticalWork { get; set; }

        /// <summary>
        /// 服务选项
        /// </summary>
        public ProductServiceEnum ServiceOption { get; set; } = ProductServiceEnum.服务人员;
        /// <summary>
        /// 预定提前时间 小时
        /// </summary>
        public int PresaleMin { get; set; }
        /// <summary>
        /// 最大预售期 天
        /// </summary>
        public int PresaleMax { get; set; }
        /// <summary>
        /// 显示排序
        /// </summary>
        public int DisplaySort { get; set; } = 0;
        /// <summary>
        /// 是否推荐到首页
        /// </summary>
        public bool IsRecommend { get; set; } = false;
        /// <summary>
        /// 是否校验库存（1:前、后台均校验;2:前、后台均不校验;3:前台校验，后台不校验;）
        /// </summary>
        public int VerifyStock { get; set; }
        /// <summary>
        /// 服务地址数量
        /// </summary>
        public int AddressNumber { get; set; }
    }
}