using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Helper;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.BusinessLayer.ServiceClasses
{
    public class AdminAuthenticationService : IAdminAuthenticationService
    {
        private readonly IAdminAuthentication _adminAuthentication;
        public AdminAuthenticationService(IAdminAuthentication adminAuthentication) 
        {
            _adminAuthentication = adminAuthentication;
        }

        public string GetCurrentLoggedinEmpToken(string empEmail)
        {
            return _adminAuthentication.GetCurrentLoggedinEmpToken(empEmail);
        }

        public bool IsCredentialsMatched(tblAdmin tblAdmin)
        {
            return _adminAuthentication.IsCredentialsMatched(tblAdmin);
        }

        public bool IsLoginDetailsSaved(tblAdmin tblAdmin)
        {
            TblAdminLogin tblAdminLogin = new TblAdminLogin();

            Guid token = Guid.NewGuid();

            tblAdminLogin.LoginToken = token.ToString();
            tblAdminLogin.EmpEmail=tblAdmin.EmpEmail;
            tblAdminLogin.CreatedDate= DateTime.Now;

            return _adminAuthentication.IsLoginDetailsSaved(tblAdminLogin);





        }
    }
}
