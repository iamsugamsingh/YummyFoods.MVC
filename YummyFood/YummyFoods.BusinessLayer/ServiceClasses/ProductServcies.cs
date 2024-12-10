using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.BusinessLayer.ServiceClasses
{
    public class ProductServcies : IProductServices
    {
        private readonly IProduct _product;

        public ProductServcies(IProduct product)
        {
            _product = product;
        }

        public bool AddNewProduct(TblProductViewModel tblProductViewModel)
        {
            TblProduct tblProduct = new TblProduct();
            tblProduct=tblProductViewModel;

            return _product.AddNewProduct(tblProduct);
        }

        public bool DeleteProduct(int productId)
        {
            return _product.DeleteProduct(productId);
        }

        public TblProduct EditProduct(int productId)
        {
            return _product.EditProduct(productId);
        }

        public List<TblProductViewModel> GetAllProducts()
        {
            return _product.GetAllProducts();
        }

        public TblProductViewModel GetProductByProductId(int productId)
        {
           return _product.GetProductByProductId(productId);
        }
    }
}
