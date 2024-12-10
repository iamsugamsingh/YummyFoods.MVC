using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFoods.Models.DBModelClasses
{
    public class TblOffersDBModel
    {
        [Key]
        public int OfferId { get; set; }
        public string OfferCode { get; set; }
        public decimal OfferValue { get; set;}
        public bool IsInPercent { get; set; }
    }
}
