using System;
using System.Collections.Generic;

namespace YummyFoods.Models.DBModelClasses
{
    public partial class TblCustomerLogin
    {
        public int CustomerLoginId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerEmailId { get; set; } = null!;
        public string CustomerToken { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
