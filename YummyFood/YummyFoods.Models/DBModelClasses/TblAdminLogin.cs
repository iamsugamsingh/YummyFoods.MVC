using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFoods.Models.DBModelClasses
{
    public class TblAdminLogin
    {
        [Key]
        public int AdminLoginId { get; set; }
        public int EmpId { get; set; }
        public string EmpEmail { get; set; }
        public string LoginToken { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
