using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.Models.ViewModelClasses
{
    public class TblProductCartVierwModel: TblProductCart
    {
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
    }
}
