//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：产品类别添加实体
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
    public class ProductCategoryAddCmd
    {
        /// <summary>
        /// 产品分类
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public DepartmentEnum? Department { get; set; }
        /// <summary>
        ///图片
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 显示排序
        /// </summary>
        public int DisplaySort { get; set; } = 0;
        /// <summary>
        /// 是否推荐到首页
        /// </summary>
        public bool IsRecommend { get; set; } = false;

    }
}