using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.BusinessLayer.ServiceClasses;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.Admin.Controllers
{
    public class AdminAuthorizationController : Controller
    {
        private readonly IAdminAuthenticationService _adminAuthenticationService;
        public AdminAuthorizationController(IAdminAuthenticationService adminAuthenticationService)
        {
            _adminAuthenticationService = adminAuthenticationService; 
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            if (IsEmpLoggedIn()==false)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "Dashboard");
            }

            
        }
        [HttpPost]
        public IActionResult AdminLogin(tblAdmin tblAdmin)
        {
            bool IsCredentialsMatched = _adminAuthenticationService.IsCredentialsMatched(tblAdmin);

            if (IsCredentialsMatched==true)
            {
                bool IsDataSaved=_adminAuthenticationService.IsLoginDetailsSaved(tblAdmin);

                if(IsDataSaved==true)
                {
                    string EmpLoggedinToken = _adminAuthenticationService.GetCurrentLoggedinEmpToken(tblAdmin.EmpEmail);

                    HttpContext.Session.SetString("LoggedInUserToken", EmpLoggedinToken);
                }

                return RedirectToAction("index", "Dashboard");
            }
            else
            {
                return View();
            }

            
        }


        public bool IsEmpLoggedIn()
        {
            string empToken = HttpContext.Session.GetString("LoggedInUserToken");

            return string.IsNullOrEmpty(empToken) ? false:true ;

        }


    }
}
