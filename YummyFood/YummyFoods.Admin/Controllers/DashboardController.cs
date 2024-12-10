using Microsoft.AspNetCore.Mvc;

namespace YummyFoods.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            //string EmpToken=HttpContext.Session.GetString("LoggedInUserToken");

            //if (IsEmpLoggedIn()==false)
            //{
            //    return RedirectToAction("AdminLogin", "AdminAuthorization");
            //}
            //else
            //{
            //    return View();
            //}

            return View();

        }



        public bool IsEmpLoggedIn()
        {
            string empToken = HttpContext.Session.GetString("LoggedInUserToken");

            return string.IsNullOrEmpty(empToken) ? false : true;

        }
    }
}
