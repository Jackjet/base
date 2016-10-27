using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Model
{
    public class WithdrawalOption
    {
        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 是否处理
        /// </summary>
        public OperationEnum Operation { get; set; }
        /// <summary>
        /// 提现开始时间
        /// </summary>
        public DateTime? CreateTimeStart { get; set; }
        /// <summary>
        /// 提现结束时间
        /// </summary>
        public DateTime? CreateTimeEnd { get; set; }

    }
}
