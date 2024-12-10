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
    public class HomePage : IHomePage
    {
        private readonly YummyFoodsDBContext _yummyFoodsDBContext;
        public HomePage(YummyFoodsDBContext yummyFoodsDBContext)
        {
            _yummyFoodsDBContext = yummyFoodsDBContext;
        }

        public List<ProductCategory> categoriesWiseProducts()
        {
            List<TblCategory> categories = _yummyFoodsDBContext.TblCategory.ToList();

            List<TblProduct> products=_yummyFoodsDBContext.TblProducts.ToList();

            List<ProductCategory> data=new List<ProductCategory>();
            
            foreach (var category in categories)
            {
                ProductCategory d = new ProductCategory()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                    IsActive = category.IsActive,
                };

                List<TblProduct> pro = new List<TblProduct>();

                foreach (var product in products)
                {
                    if (category.CategoryId == product.CategoryId)
                    {
                        
                        pro.Add(new TblProduct()
                        {
                            CategoryId= product.CategoryId,
                            ProductId= product.ProductId,
                            ProductName= product.ProductName,
                            ProductDescription= product.ProductDescription,
                            IsActive= product.IsActive,
                            IsBestSeller = product.IsBestSeller,
                            ProductQuantity = product.ProductQuantity,
                            ProductPrice = product.ProductPrice,
                            ProductImage = product.ProductImage
                        });

                        d.products=pro;
                    }
                }
                data.Add(d);
            }

            return data;


        }
    }
}
