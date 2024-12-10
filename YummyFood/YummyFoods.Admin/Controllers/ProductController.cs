using Microsoft.AspNetCore.Mvc;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.Models.DBModelClasses;

using YummyFoods.Models.ViewModelClasses;


namespace YummyFoods.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoriesService _categoriesService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnv;

        public ProductController(IProductServices productServices, ICategoriesService categoriesService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv)
        {
            _productServices = productServices;
            _categoriesService = categoriesService;
            _hostingEnv = hostingEnv;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var AllCategories = _categoriesService.GetAllCategories();

            ViewBag.AllCategories = AllCategories;

            List<TblProductViewModel> Products = _productServices.GetAllProducts();


            return View(Products);
        }

        [HttpPost]
        public IActionResult AddNewProduct(TblProductViewModel tblProductViewModel)
        {
            tblProductViewModel.CreatedBy = 1;
            if(tblProductViewModel.UploadedProductImage != null) {
                string fileName = tblProductViewModel.UploadedProductImage.FileName;
                string fileExtention = fileName.Split('.').Last();

                Guid guid = Guid.NewGuid();

                tblProductViewModel.ProductImage = guid + "." + fileExtention;
                bool isFileSavedTOFolder = IsFileUploaded(tblProductViewModel.UploadedProductImage, tblProductViewModel.ProductImage);

            }

            bool res = _productServices.AddNewProduct(tblProductViewModel);


            return RedirectToAction("Index");
        }

        public bool IsFileUploaded(IFormFile formFile, string fileName)
        {
            var FileDic = "ProductImages";

            string FilePath = Path.Combine(_hostingEnv.WebRootPath, FileDic);

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            var filePath = Path.Combine(FilePath, fileName);

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                formFile.CopyTo(fs);
            }

            return true;

        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            TblProduct data=_productServices.EditProduct(id);


            return Json(data);
        }

        [HttpGet]
        public IActionResult DeleteProduct(int Id)
        {
            bool res=_productServices.DeleteProduct(Id);

            return RedirectToAction("Index");
        }

    }
}
