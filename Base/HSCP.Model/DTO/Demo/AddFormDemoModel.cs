
using HSCP.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSCP.Model
{
    /// <summary>
    /// 添加表单实体
    /// </summary>
    public class AddFormDemoModel :BackUrl
    {
        public string CreatePerson { get; set; }

        public DateTime? CreateDate { get; set; } 

        public string UpdatePerson { get; set; }

        public DateTime? UpdateDate { get; set; } 

        public int Id { get; set; }

        public string Name { get; set; }

        public  int  IsRequired { get; set; }

        public int? DemoTypeId { get; set; }

        public List<DemoType> DemoTypeList { get; set; }

        public string[] CheckboxArray { get; set; }

        public List<DemoType> CheckboxList { get; set; }




    }
}
 