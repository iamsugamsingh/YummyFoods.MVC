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
    public class CartService : ICartService
    {
        private readonly ICart _cart;

        public CartService(ICart cart)
        {
            _cart = cart;
        }


        public bool AddToCart(TblProductCart tblProductCart)
        {
            return _cart.AddToCart(tblProductCart);
        }

        public bool BuyAllProduct(int customerId, string couponCode)
        {
           return _cart.BuyAllProduct(customerId, couponCode);  
        }

        public bool BuySingleProduct(int CartId, int customerId, string couponCode)
        {
            return _cart.BuySingleProduct(CartId, customerId, couponCode);
        }

        public bool DeleteProductCart(int cartId)
        {
            return _cart.DeleteProductCart(cartId);
        }

        public List<TblProductCartVierwModel> GetAllOrder(int customerId)
        {
            return _cart.GetAllOrder(customerId);
        }

        public List<TblProductCartVierwModel> GetAllProductCart(int userId)
        {
            return _cart.GetAllProductCart(userId);
        }

        public Tuple<decimal, bool> ApplyCouponCode(string couponCode)
        {
            return _cart.ApplyCouponCode(couponCode);
        }
    }
}
