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
    public class AdminAuthentication : IAdminAuthentication
    {
        private readonly YummyFoodsDBContext _dbContext;
        public AdminAuthentication(YummyFoodsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetCurrentLoggedinEmpToken(string empEmail)
        {
            string EmpToken = _dbContext.TblAdminLogins.Where(x => x.EmpEmail == empEmail).OrderByDescending(x => x.CreatedDate).Take(1).Select(x => x.LoginToken).FirstOrDefault();

            return EmpToken;
        }

        public bool IsCredentialsMatched(tblAdmin tblAdmin)
        {
            //var encryptedPassword = PasswordEncryptionDecryption.EncodePasswordToBase64(customerViewModel.Password);

            var record = _dbContext.tblAdmin.Where(x => x.EmpEmail.ToLower() == tblAdmin.EmpEmail.ToLower() && x.EmpPassword == tblAdmin.EmpPassword).ToList();

            return record.Any()?true:false;
        }

        public bool IsLoginDetailsSaved(TblAdminLogin tblAdminLogin)
        {
            _dbContext.TblAdminLogins.Add(tblAdminLogin);
            int res = _dbContext.SaveChanges();

            return res > 0 ? true:false ;

        }
    }
}
