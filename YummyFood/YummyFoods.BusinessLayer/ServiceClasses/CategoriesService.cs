using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.BusinessLayer.ServiceClasses
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategories _categories;

        public CategoriesService(ICategories categories)
        {
            _categories = categories;
        }

        public bool AddNewCategory(TblCategory tblCategory)
        {
            return _categories.AddNewCategory(tblCategory);
        }

        public bool DeleteCategory(int id)
        {
            return _categories.DeleteCategory(id);  
        }

        public List<TblCategory> GetAllCategories()
        {
            return _categories.GetAllCategories();
        }

        public TblCategory GetCategoryById(int id)
        {
            return _categories.GetCategoryById(id);
        }
    }
}
