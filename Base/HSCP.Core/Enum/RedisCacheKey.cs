//*************************** 
//文件名称(File Name)： RedisCacheKey.cs
//功能描述(Description)：redis 缓存主键前缀定义
//数据表(Tables)：  
//作者(Author)： conan
//日期(Create Date)： 2016.04.16
//参考文档(Reference)(可选)：     
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    /// <summary>
    /// 缓存主键前缀
    /// </summary>

    public enum RedisCacheKey
    {
        /// <summary>
        /// 产品编码
        /// </summary> 
        Produnct,

        /// <summary>
        /// 分类
        /// </summary>
        Category,

        /// <summary>
        /// 产品SKU编码
        /// </summary> 
        SKU,

        /// <summary>
        /// 会员登录token
        /// </summary>
        MLogin,

        /// <summary>
        /// 短信
        /// </summary>
        Sms,

        /// <summary>
        /// 控制台
        /// </summary>
        Console,

        /// <summary>
        /// 其他
        /// </summary>
        Other,
        /// <summary>
        /// 员工端
        /// </summary>
        Employee,
        /// <summary>
        /// 员工端登录
        /// </summary>
        ELogin,
        /// <summary>
        /// 会员端
        /// </summary>
        Member,

        /// <summary>
        /// 短信统计
        /// </summary>
        SmsCount,
        /// <summary>
        /// 短信校验
        /// </summary>
        SmsSign
    }
}
