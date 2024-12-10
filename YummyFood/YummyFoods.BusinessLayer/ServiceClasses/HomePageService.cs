using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.DatabaseLayer.RepositoriesClasses;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.BusinessLayer.ServiceClasses
{
    public class HomePageService : IHomePageService
    {

        private readonly IHomePage _homePage;

        public HomePageService(IHomePage homePage)
        {
            _homePage = homePage;
        }

        public List<ProductCategory> ProductWiseCategories()
        {
            return _homePage.categoriesWiseProducts();
        }
    }
}
