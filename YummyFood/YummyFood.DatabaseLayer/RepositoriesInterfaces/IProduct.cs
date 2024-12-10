using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.DatabaseLayer.RepositoriesInterfaces
{
    public interface IProduct
    {
        bool AddNewProduct(TblProduct tblProduct);
        List<TblProductViewModel> GetAllProducts();
        TblProduct EditProduct(int productId);
        bool DeleteProduct(int productId);

        TblProductViewModel GetProductByProductId(int productId);

    }
}
