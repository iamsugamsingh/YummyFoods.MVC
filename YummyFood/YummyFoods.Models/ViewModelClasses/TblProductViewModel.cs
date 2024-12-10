using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.Models.ViewModelClasses
{
    public class TblProductViewModel:TblProduct
    {
        public IFormFile UploadedProductImage { get; set; }
        public string CategoryName { get; set; }    
    }
}
