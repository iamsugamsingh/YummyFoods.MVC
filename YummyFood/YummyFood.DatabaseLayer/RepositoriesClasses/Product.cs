using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.DatabaseLayer.RepositoriesClasses
{
    public class Product : IProduct
    {
        private readonly YummyFoodsDBContext _dbContext;
        public Product(YummyFoodsDBContext dbContext)
        {
           _dbContext = dbContext;
        }


        public bool AddNewProduct(TblProduct tblProduct)
        {
            if (tblProduct.ProductId > 0)
            {
                TblProduct data=_dbContext.TblProducts.Where(p => p.ProductId == tblProduct.ProductId).FirstOrDefault();

                data.ProductName = tblProduct.ProductName;
                data.ProductDescription = tblProduct.ProductDescription;
                data.ProductPrice = tblProduct.ProductPrice;
                data.ProductQuantity = tblProduct.ProductQuantity;
                if (!string.IsNullOrEmpty(tblProduct.ProductImage))
                {
                    data.ProductImage = tblProduct.ProductImage;
                }
                data.ModifiedDate = DateTime.Now;
                data.ModifiedBy = 1;

                int res = _dbContext.SaveChanges();

                return res > 0 ? true : false;
            }
            else
            {
                TblProduct productObj = new TblProduct();
                productObj.ProductName = tblProduct.ProductName;
                productObj.ProductDescription = tblProduct.ProductDescription;
                productObj.ProductPrice = tblProduct.ProductPrice;
                productObj.CategoryId = tblProduct.CategoryId;
                productObj.ProductImage = tblProduct.ProductImage;
                productObj.ProductQuantity = tblProduct.ProductQuantity;
                productObj.CreatedDate = DateTime.Now;
                productObj.CreatedBy = tblProduct.CreatedBy;
                productObj.ProductQuantity = tblProduct.ProductQuantity;
                productObj.IsBestSeller = true;

                _dbContext.Add(productObj);
                int res = _dbContext.SaveChanges();

                return res > 0 ? true : false;
            }
        }

        public bool DeleteProduct(int productId)
        {
            TblProduct tblProduct = _dbContext.TblProducts.Where(x => x.ProductId == productId).FirstOrDefault();


            if (tblProduct != null)
            {
                _dbContext.Remove(tblProduct);
                int res = _dbContext.SaveChanges();
                return res > 0 ? true : false;
            }
           
            return false;
            
        }

        public TblProduct EditProduct(int productId)
        {
            TblProduct tblProduct=_dbContext.TblProducts.Where(x=>x.ProductId== productId).FirstOrDefault();

            return tblProduct;
        }

        public List<TblProductViewModel> GetAllProducts()
        {
            List<TblProductViewModel> data= (from prod in _dbContext.TblProducts
                                   join cat in _dbContext.TblCategory
                                   on prod.CategoryId equals cat.CategoryId
                                   select new TblProductViewModel()
                                   {
                                       ProductId = prod.ProductId,
                                       ProductName = prod.ProductName,
                                       ProductDescription = prod.ProductDescription,
                                       ProductPrice = prod.ProductPrice,
                                       CategoryName=cat.CategoryName,
                                       ProductImage= prod.ProductImage,
                                       ProductQuantity=prod.ProductQuantity,
                                       CreatedDate = prod.CreatedDate
                                   }).ToList();


            return data;
        }

        public TblProductViewModel GetProductByProductId(int productId)
        {
            var data=_dbContext.TblProducts.Where(x=>x.ProductId == productId).FirstOrDefault();

            TblProductViewModel obj= new TblProductViewModel()
            {
                ProductId=data.ProductId,
                ProductName=data.ProductName,
                ProductDescription=data.ProductDescription,
                ProductPrice=data.ProductPrice,
                CategoryId=data.CategoryId,
                CategoryName= _dbContext.TblCategory.Where(x => x.CategoryId == data.CategoryId).Select(y=>y.CategoryName).FirstOrDefault(),
                ProductImage= data.ProductImage,
            };

            return obj;
        }
    }
}
