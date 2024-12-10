using Microsoft.AspNetCore.Mvc;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
             _categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<TblCategory> categories = _categoriesService.GetAllCategories();

            if (categories.Any())
            {
                ViewBag.allCategories= categories;
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(TblCategory tblCategory)
        {
            tblCategory.CreatedBy = 1;

            bool IsCategorySaved = _categoriesService.AddNewCategory(tblCategory);


            List<TblCategory> categories = _categoriesService.GetAllCategories();

            if (categories.Any())
            {
                ViewBag.allCategories = categories;
            }

            return View("Index");
        }

        public IActionResult EditCategory(int id)
        {
            TblCategory data=_categoriesService.GetCategoryById(id);

            return Json(data);
        }

        public IActionResult DeleteCategory(int id)
        {
            bool res=_categoriesService.DeleteCategory(id); 



            List<TblCategory> categories = _categoriesService.GetAllCategories();

            if (categories.Any())
            {
                ViewBag.allCategories = categories;
            }
            return View("Index");
        }

    }
}
