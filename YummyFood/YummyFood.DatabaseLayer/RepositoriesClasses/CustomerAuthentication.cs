using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Helper;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.DatabaseLayer.RepositoriesClasses
{
    public class CustomerAuthentication : ICustomerAuthentication
    {
        private readonly YummyFoodsDBContext _dbContext;
        public CustomerAuthentication(YummyFoodsDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool CustomerRegistration(CustomerViewModel customerViewModel)
        {
            TblCustomer tblCustomer = new TblCustomer();

            tblCustomer.CustomerName= customerViewModel.CustomerName;
            tblCustomer.CustomerGender= customerViewModel.CustomerGender;
            tblCustomer.CustomerContactNo= customerViewModel.CustomerContactNo;
            tblCustomer.CustomerEmailId= customerViewModel.CustomerEmailId;
            tblCustomer.CreatedDate= DateTime.Now;
            tblCustomer.Password= customerViewModel.Password;
            tblCustomer.IsActive = true;

            _dbContext.Add(tblCustomer);
            int res= _dbContext.SaveChanges();

            return res>0?true: false;

        }

        public bool IsCredentialsMatched(CustomerViewModel customerViewModel)
        {
            var encryptedPassword = PasswordEncryptionDecryption.EncodePasswordToBase64(customerViewModel.Password);

            var record = _dbContext.TblCustomers.Where(x => x.CustomerEmailId.ToLower() == customerViewModel.CustomerEmailId.ToLower() && x.Password == encryptedPassword).ToList();

            if(record.Any())
            {
                int customerId = _dbContext.TblCustomers.Where(x => x.CustomerEmailId.ToLower() == customerViewModel.CustomerEmailId.ToLower()).Select(y=>y.CustomerId).FirstOrDefault();


                TblCustomerLogin tblCustomerLogin = new TblCustomerLogin();

                Guid token = Guid.NewGuid();

                tblCustomerLogin.CustomerToken = token.ToString();
                tblCustomerLogin.CustomerId = customerId;
                tblCustomerLogin.CustomerEmailId= customerViewModel.CustomerEmailId;
                tblCustomerLogin.CreatedBy = customerId;
                tblCustomerLogin.CreatedDate=DateTime.Now;

                _dbContext.Add(tblCustomerLogin);
                int res=_dbContext.SaveChanges();


            }



            return record.Any()?true:false;
        }

        public TblCustomerLogin GetUserDetails(string userEmail)
        {
            TblCustomerLogin data=_dbContext.TblCustomerLogins.Where(x=>x.CustomerEmailId == userEmail).OrderByDescending(y=>y.CreatedDate).FirstOrDefault();


            return data ?? new TblCustomerLogin();
        }
    }
}
