using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.BusinessLayer.SerivceInterface
{
    public interface IAdminAuthenticationService
    {
        bool IsCredentialsMatched(tblAdmin tblAdmin);
        bool IsLoginDetailsSaved(tblAdmin tblAdmin);
        string GetCurrentLoggedinEmpToken(string empEmail);


    }
}
