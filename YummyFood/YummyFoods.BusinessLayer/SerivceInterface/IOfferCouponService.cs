using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.BusinessLayer.SerivceInterface
{
    public interface IOfferCouponService
    {
        bool AddOffersCoupon(TblOffersDBModel tblOffersDBModel);
        List<TblOffersDBModel> GetAllOffers();
        bool DeleteOffersCoupon(int offerId);
        TblOffersDBModel GetOffersByOfferId(int offerId);
    }
}
