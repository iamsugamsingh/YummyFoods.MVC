using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.BusinessLayer.ServiceClasses
{
    public class OffersCouponService : IOfferCouponService
    {
        private readonly IOffersCoupon _offersCoupon;
        public OffersCouponService(IOffersCoupon offersCoupon)
        {
            _offersCoupon = offersCoupon;
        }

        public bool AddOffersCoupon(TblOffersDBModel tblOffersDBModel)
        {
            return _offersCoupon.AddOffersCoupon(tblOffersDBModel);
        }

        public bool DeleteOffersCoupon(int offerId)
        {
            return _offersCoupon.DeleteOffersCoupon(offerId);
        }

        public List<TblOffersDBModel> GetAllOffers()
        {
            return _offersCoupon.GetAllOffers();
        }

        public TblOffersDBModel GetOffersByOfferId(int offerId)
        {
            return _offersCoupon.GetOffersByOfferId(offerId);
        }
    }
}
