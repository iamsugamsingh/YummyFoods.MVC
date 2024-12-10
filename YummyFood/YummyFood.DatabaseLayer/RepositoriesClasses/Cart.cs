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
    public class Cart : ICart
    {
        private readonly YummyFoodsDBContext _yummyFoodsDBContext;
        public Cart(YummyFoodsDBContext yummyFoodsDBContext)
        {
            _yummyFoodsDBContext = yummyFoodsDBContext;
        }
        public bool AddToCart(TblProductCart tblProductCart)
        {
            TblProductCart obj = new TblProductCart();
            obj.CategoryId = tblProductCart.CategoryId;
            obj.ProductId = tblProductCart.ProductId;
            obj.Price = tblProductCart.Price;
            obj.Quantity = tblProductCart.Quantity;
            obj.UserId = tblProductCart.UserId;
            obj.CreatedBy = tblProductCart.UserId;
            obj.CreatedDate = DateTime.Now;
            obj.IsBuy = false;

            _yummyFoodsDBContext.Add(obj);
            int res = _yummyFoodsDBContext.SaveChanges();

            return res > 0 ? true : false;
        }

        public List<TblProductCartVierwModel> GetAllProductCart(int userId)
        {
            List<TblProductCartVierwModel> data=(from cart in _yummyFoodsDBContext.TblProductCart
                                      join product in _yummyFoodsDBContext.TblProducts
                                      on cart.ProductId equals product.ProductId
                                      where cart.IsBuy== false && cart.UserId==userId
                                      select new TblProductCartVierwModel()
                                      {
                                          CartId=cart.CartId,
                                          CategoryId=cart.CategoryId,
                                          ProductId=cart.ProductId,
                                          Price=cart.Price,
                                          IsBuy=cart.IsBuy,
                                          ProductName=product.ProductName,
                                          Quantity = cart.Quantity,
                                          ProductImage=product.ProductImage,
                                      }).ToList();
            return data;
        }

        public bool DeleteProductCart(int cartId)
        {
            TblProductCart data=_yummyFoodsDBContext.TblProductCart.Where(x=>x.CartId==cartId).FirstOrDefault();

            if (data!=null)
            {
                _yummyFoodsDBContext.Remove(data);
                int res=_yummyFoodsDBContext.SaveChanges();

                if(res>0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool BuySingleProduct(int CartId, int customerId, string couponCode)
        {
            TblProductCart DataFound=_yummyFoodsDBContext.TblProductCart.Where(x=>x.CartId==CartId && x.IsBuy==false && x.UserId==customerId).FirstOrDefault();

            TblOffersDBModel couponCodedata = _yummyFoodsDBContext.tblOffers.Where(x => x.OfferCode.ToLower() == couponCode.ToLower()).FirstOrDefault();

            decimal calculatedPrice = 0;

            if (couponCodedata != null)
            {
                if (couponCodedata.IsInPercent)
                {
                    var discountedValue = ((DataFound.Price*DataFound.Quantity) * couponCodedata.OfferValue) / 100;
                    DataFound.Price=(DataFound.Price*DataFound.Quantity) -discountedValue;
                }
                else
                {
                    DataFound.Price = (DataFound.Price * DataFound.Quantity) - couponCodedata.OfferValue;
                }
            }


            DataFound.IsBuy=true;
            DataFound.OrderDate=DateTime.Now;
            

            _yummyFoodsDBContext.Update(DataFound);
            int res = _yummyFoodsDBContext.SaveChanges();

            return res>0?true : false;

        }
        
        public bool BuyAllProduct(int customerId, string couponCode)
        {
            List<TblProductCart> DataFound=_yummyFoodsDBContext.TblProductCart.Where(x=>x.IsBuy==false && x.UserId==customerId).ToList();
            TblOffersDBModel couponCodedata = _yummyFoodsDBContext.tblOffers.Where(x => x.OfferCode.ToLower() == couponCode.ToLower()).FirstOrDefault();

            foreach (TblProductCart cart in DataFound)
            {
                decimal calculatedPrice = 0;

                if (couponCodedata != null)
                {
                    if (couponCodedata.IsInPercent)
                    {
                        var discountedValue = ((cart.Price* cart.Quantity) * couponCodedata.OfferValue) / 100;
                        cart.Price = (cart.Price * cart.Quantity) - discountedValue;
                    }
                    else
                    {
                        cart.Price = (cart.Price*cart.Quantity) - couponCodedata.OfferValue;
                    }
                }
                cart.IsBuy = true;
                cart.OrderDate = DateTime.Now;

                _yummyFoodsDBContext.Update(cart);
                int res = _yummyFoodsDBContext.SaveChanges();

            }

            return true;

        }

        public List<TblProductCartVierwModel> GetAllOrder(int customerId)
        {
            List<TblProductCartVierwModel> data = (from cart in _yummyFoodsDBContext.TblProductCart
                                                   join product in _yummyFoodsDBContext.TblProducts
                                                   on cart.ProductId equals product.ProductId
                                                   where cart.IsBuy == true && cart.UserId == customerId
                                                   select new TblProductCartVierwModel()
                                                   {
                                                       CartId = cart.CartId,
                                                       CategoryId = cart.CategoryId,
                                                       ProductId = cart.ProductId,
                                                       Price = cart.Price,
                                                       IsBuy = cart.IsBuy,
                                                       ProductName = product.ProductName,
                                                       Quantity = cart.Quantity,
                                                       ProductImage = product.ProductImage,
                                                       OrderDate=cart.OrderDate
                                                   }).ToList();
            return data;
        }

        public Tuple<decimal, bool> ApplyCouponCode(string couponCode)
        {
            TblOffersDBModel data = _yummyFoodsDBContext.tblOffers.Where(x=>x.OfferCode.ToLower() == couponCode.ToLower()).FirstOrDefault();

            if(data != null)
            {
                return new Tuple<decimal, bool>(data.OfferValue, data.IsInPercent);
            }

            return new Tuple<decimal, bool> ( 0, false );
        }
    }
}
