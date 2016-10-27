using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Model;

namespace Conan.Web.BLL
{
    public class OrderSettlementDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int StoreId { get; set; }
        public string BillNo { get; set; }
        public SettlementLabelEnum PaySettlement { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? PaySettlementTime { get; set; }
        public decimal RealTotalAmount { get; set; }
        public string Account { get; set; }
        public int? PaySettlementPerson { get; set; }
        public string StoreName { get; set; }
        /// <summary>
        /// excel泛型中使用到的员工薪酬
        /// </summary>
        public string TOrderWage { get; set; }
        /// <summary>
        /// 薪酬结算人
        /// </summary>
        public string PaySettlementPersonName { get; set; }

        public int MemberId { get; set; }

        public Dictionary<string, decimal?> OrderWage { get; set; }
    }

    

    public class StoresTemp {
        public int Id { get; set; }

        public string StoreName { get; set; }
    }

    public class OrderWageTemp {
        public string BillNo { get; set; }

        public string No { get; set; }

        public decimal? RealWage { get; set; }
    }

    public class EmployeeTemp {
        public int Id { get; set; }

        public string No { get; set; }
    }

    public class MemberTemp {
        public int Id { get; set; }

        public string Account { get; set; }
    }
}
