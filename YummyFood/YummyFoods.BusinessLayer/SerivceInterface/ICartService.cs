using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.BusinessLayer.SerivceInterface
{
    public interface ICartService
    {
        bool AddToCart(TblProductCart tblProductCart);
        List<TblProductCartVierwModel> GetAllProductCart(int userId);
        bool DeleteProductCart(int cartId);
        bool BuySingleProduct(int CartId, int customerId, string couponCode);
        bool BuyAllProduct(int customerId, string couponCode);
        List<TblProductCartVierwModel> GetAllOrder(int customerId);
        Tuple<decimal, bool> ApplyCouponCode(string couponCode);

    }
}
