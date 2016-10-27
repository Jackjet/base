//*************************** 
//文件名称(File Name)： 
//功能描述(Description)：订单标签
//数据表(Tables)：    
//作者(Author)： conan
//日期(Create Date)： 2016.05.05
//参考文档(Reference)(可选)：      
//引用(Using) (可选)﹕        
//修改记录(Revision History)：
//*************************** 
using System;
using Conan.Core;
using System.ComponentModel;

namespace Conan.Model
{
    /// <summary>
    /// 订单标签
    /// </summary>
    public partial class OrderLabel : Entity<int>
    {

      
               public virtual string Name { get; set; }

    


    }
}