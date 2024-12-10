using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFoods.DatabaseLayer.RepositoriesInterfaces;
using YummyFoods.Models.DBModelClasses;

namespace YummyFoods.DatabaseLayer.RepositoriesClasses
{
    public class Categories : ICategories
    {
        private readonly YummyFoodsDBContext _yummyFoodsDBContext;
        public Categories(YummyFoodsDBContext yummyFoodsDBContext)
        {
            _yummyFoodsDBContext = yummyFoodsDBContext;
        }



        public bool AddNewCategory(TblCategory tblCategory)
        {
            if (tblCategory.CategoryId > 0)
            {
                TblCategory data = _yummyFoodsDBContext.TblCategory.Where(x => x.CategoryId == tblCategory.CategoryId).FirstOrDefault();

                data.CategoryName= tblCategory.CategoryName;
                data.CategoryDescription=tblCategory.CategoryDescription;
                data.ModifiedDate = DateTime.Now;
                data.ModifiedBy = 1;

                //_yummyFoodsDBContext.Add(data);
                int res = _yummyFoodsDBContext.SaveChanges();

                return res > 0 ? true : false;
            }
            else
            {
                TblCategory categoryObj = new TblCategory();
                categoryObj.CategoryName = tblCategory.CategoryName;
                categoryObj.CategoryDescription = tblCategory.CategoryDescription;
                categoryObj.CreatedDate = DateTime.Now;
                categoryObj.CreatedBy = tblCategory.CreatedBy;
                categoryObj.IsActive = true;

                _yummyFoodsDBContext.Add(categoryObj);
                int res = _yummyFoodsDBContext.SaveChanges();

                return res > 0 ? true : false;
            }
        }

        public bool DeleteCategory(int id)
        {
            var itemToRemove = _yummyFoodsDBContext.TblCategory.Where(x => x.CategoryId == id).FirstOrDefault(); //returns a single item.

            if (itemToRemove != null)
            {
                _yummyFoodsDBContext.TblCategory.Remove(itemToRemove);
                int res=_yummyFoodsDBContext.SaveChanges();

                return res > 0?true:false;
            }

            return false;
        }

        public List<TblCategory> GetAllCategories()
        {
            List<TblCategory> data=_yummyFoodsDBContext.TblCategory.ToList();

            return data;
        }

        public TblCategory GetCategoryById(int id)
        {
            TblCategory data = _yummyFoodsDBContext.TblCategory.Where(x => x.CategoryId == id).FirstOrDefault();

            return data;
        }
    }
}
