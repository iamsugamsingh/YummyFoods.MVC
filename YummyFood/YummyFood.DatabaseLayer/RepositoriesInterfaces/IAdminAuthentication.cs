using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.Models.DBModelClasses;
using YummyFoods.Models.ViewModelClasses;

namespace YummyFoods.DatabaseLayer.RepositoriesInterfaces
{
    public interface IAdminAuthentication
    {
        bool IsCredentialsMatched(tblAdmin tblAdmin);
        bool IsLoginDetailsSaved(TblAdminLogin tblAdminLogin);
        string GetCurrentLoggedinEmpToken(string empEmail);
    }
}
