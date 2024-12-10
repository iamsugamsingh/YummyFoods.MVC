using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.BusinessLayer.SerivceInterface
{
    public interface ICustomerAuthenticationService
    {
        bool CustomerRegistration(CustomerViewModel customerViewModel);
        bool IsCredentialsMatched(CustomerViewModel customerViewModel);
        TblCustomerLogin GetUserDetails(string userEmail);

    }
}
