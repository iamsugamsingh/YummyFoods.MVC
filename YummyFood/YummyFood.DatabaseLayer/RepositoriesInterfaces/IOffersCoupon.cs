using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.DatabaseLayer.RepositoriesInterfaces
{
    public interface IOffersCoupon
    {
        bool AddOffersCoupon(TblOffersDBModel tblOffersDBModel);
        List<TblOffersDBModel> GetAllOffers();
        bool DeleteOffersCoupon(int offerId);
        TblOffersDBModel GetOffersByOfferId(int offerId);
    }
}
