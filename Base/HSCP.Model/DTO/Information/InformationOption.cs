/*
 * 作者：Ldw    
 * 日期：2016.06.27
 * 描述：咨讯
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conan.Model
{
    public class InformationOption
    {
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Titles { get; set; }
        /// <summary>
        /// 显示渠道
        /// </summary>
        public virtual string Channel { get; set; }
    }
}
