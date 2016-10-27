using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    [Serializable]
    public class UserLocationResult : LocationDataResult
    {

        /// <summary>
        /// 服务时间
        /// </summary>
      //  [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public long StartTime { get; set; }
        /// <summary>
        /// 员工id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string BillNo { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
      //  [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public long Day { get; set; }

    }
}
