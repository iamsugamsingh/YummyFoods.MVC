using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFoods.Models.DBModelClasses
{
    public class TblProductCart
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifyBy { get; set; }
        public bool IsBuy { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
