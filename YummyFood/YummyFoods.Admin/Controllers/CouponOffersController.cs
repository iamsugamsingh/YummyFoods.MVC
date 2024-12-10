using Microsoft.AspNetCore.Mvc;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.Admin.Controllers
{
    public class CouponOffersController : Controller
    {
        private readonly IOfferCouponService _offerCouponService;
        public CouponOffersController(IOfferCouponService offerCouponService)
        {
            _offerCouponService = offerCouponService;
        }

        public IActionResult Index()
        {
            List<TblOffersDBModel> data=_offerCouponService.GetAllOffers();

            ViewBag.AllOffersList= data;

            TblOffersDBModel obj=new TblOffersDBModel();

            return View(obj);
        }

        [HttpPost]
        public IActionResult AddOffers(TblOffersDBModel tblOffersDBModel)
        {
            bool res=_offerCouponService.AddOffersCoupon(tblOffersDBModel);

            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteOffer(int id)
        {
            bool res=_offerCouponService.DeleteOffersCoupon(id);

            return RedirectToAction("Index");
        }

        public IActionResult EditOffer(int id)
        {
            var data =_offerCouponService.GetOffersByOfferId(id);


            return Json(data);
        }
    }
}
