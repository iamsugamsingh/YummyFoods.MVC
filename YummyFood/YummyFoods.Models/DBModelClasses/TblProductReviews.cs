using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFoods.Models.DBModelClasses
{
    public class TblProductReviews
    {
        [Key]
        public int ReviewId { get; set; }
        public decimal ReviewRating { get; set; }
        public string ReviewComments { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
