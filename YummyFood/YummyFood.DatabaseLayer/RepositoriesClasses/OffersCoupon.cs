using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.DatabaseLayer.RepositoriesClasses
{
    public class OffersCoupon : IOffersCoupon
    {
        private readonly YummyFoodsDBContext _yummyFoodsDBContext;
        public OffersCoupon(YummyFoodsDBContext yummyFoodsDBContext)
        {
            _yummyFoodsDBContext = yummyFoodsDBContext;
        }


        public bool AddOffersCoupon(TblOffersDBModel tblOffersDBModel)
        {
            if (tblOffersDBModel.OfferId == 0)
            {
                TblOffersDBModel obj = new TblOffersDBModel();
                obj.OfferValue = tblOffersDBModel.OfferValue;
                obj.OfferCode = tblOffersDBModel.OfferCode;
                obj.IsInPercent = tblOffersDBModel.IsInPercent;

                _yummyFoodsDBContext.Add(obj);
                int res = _yummyFoodsDBContext.SaveChanges();

                return res > 0 ? true : false;
            }
            else
            {
                TblOffersDBModel record =_yummyFoodsDBContext.tblOffers.Where(x=>x.OfferId == tblOffersDBModel.OfferId).FirstOrDefault();

                record.OfferValue=tblOffersDBModel.OfferValue;
                record.OfferCode=tblOffersDBModel.OfferCode;
                record.IsInPercent=tblOffersDBModel.IsInPercent;
                _yummyFoodsDBContext.Update(record);

                int res = _yummyFoodsDBContext.SaveChanges();

                return res > 0 ? true : false;

            }
            
        }

        public List<TblOffersDBModel> GetAllOffers()
        {
           return _yummyFoodsDBContext.tblOffers.ToList();
        }
        
        public bool DeleteOffersCoupon(int offerId)
        {
           var data=_yummyFoodsDBContext.tblOffers.Where(x=>x.OfferId==offerId).FirstOrDefault();

            if (data != null)
            {
                _yummyFoodsDBContext.Remove(data);
                int res = _yummyFoodsDBContext.SaveChanges();
                return res > 0?true:false;
            }
            return false;
        }

        public TblOffersDBModel GetOffersByOfferId(int offerId)
        {
            TblOffersDBModel data=_yummyFoodsDBContext.tblOffers.Where(x=>x.OfferId==offerId).FirstOrDefault();

            return data;
        }
    }
}
