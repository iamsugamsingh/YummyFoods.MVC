using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YummyFoods.Models.DBModelClasses
{
    public partial class TblCustomer
    {

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public long CustomerContactNo { get; set; }
        public string CustomerEmailId { get; set; } = null!;
        public string CustomerGender { get; set; } = null!;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public string Password { get; set; }
    }
}
