using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.BusinessLayer.SerivceInterface
{
    public interface IHomePageService
    {
        List<ProductCategory> ProductWiseCategories();
    }
}
