using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.BusinessLayer.SerivceInterface
{
    public interface ICategoriesService
    {
        bool AddNewCategory(TblCategory tblCategory);

        List<TblCategory> GetAllCategories();

        TblCategory GetCategoryById(int id);

        bool DeleteCategory(int id);
    }
}
