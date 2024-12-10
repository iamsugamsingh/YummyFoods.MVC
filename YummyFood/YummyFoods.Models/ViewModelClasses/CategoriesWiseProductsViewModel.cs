using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.Models.ViewModelClasses
{
    public class ProductCategory:TblCategory
    {
        public List<TblProduct>products { get; set; }
    }
}
