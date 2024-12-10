using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.BusinessLayer.SerivceInterface;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Helper;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.BusinessLayer.ServiceClasses
{
    public class CustomerAuthenticationService : ICustomerAuthenticationService
    {
        private readonly ICustomerAuthentication _customerAuthentication;
        public CustomerAuthenticationService(ICustomerAuthentication customerAuthentication) 
        {
            _customerAuthentication = customerAuthentication;
        }
        public bool CustomerRegistration(CustomerViewModel customerViewModel)
        {
            customerViewModel.Password = PasswordEncryptionDecryption.EncodePasswordToBase64(customerViewModel.Password);

            return _customerAuthentication.CustomerRegistration(customerViewModel);
        }

        public bool IsCredentialsMatched(CustomerViewModel customerViewModel)
        {
            return _customerAuthentication.IsCredentialsMatched(customerViewModel);
        }

        public TblCustomerLogin GetUserDetails(string userEmail)
        {
            return _customerAuthentication.GetUserDetails(userEmail);
        }
    }
}
