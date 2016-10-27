//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：职能范围
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.12
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    /// <summary>
    ///职能范围
    /// </summary>
    public class EmployeeStoreVIew
    {
        /// <summary>
        /// 大区id
        /// </summary>
        public int RegionId { get; set; }


        /// <summary>
        /// 大区名称
        /// </summary>
        public string RegionName { get; set; }


        public List<CityView> CityViewList { get; set; }
    }

    public class CityView
    {
        /// <summary>
        /// 城市id
        /// </summary>
        public int CityId { get; set; }


        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }



        public List<StoreView> StoreViewList { get; set; }
    }

    public class StoreView
    {
        /// <summary>
        /// 门店id
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 门店
        /// </summary>
        public string StoreName { get; set; }


        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsCheck { get; set; }

    }
}
