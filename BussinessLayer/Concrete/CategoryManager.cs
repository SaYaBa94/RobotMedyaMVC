using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void Add(Category category)
        {
            _categoryDAL.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDAL.Delete(category);
        }


        public Category GetCategory(int id)
        {
            return _categoryDAL.GetCategoryList(c => c.CategoryID == id)[0];
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDAL.GetCategoryList();
        }

        public List<Category> GetCategoryListByType(int typeid=1)
        {
            return _categoryDAL.GetCategoryList(c => c.CategoryTypeID == typeid);
        }

        public List<CategoryType> GetCategoryTypeList()
        {
            return _categoryDAL.GetCategoryTypeList();
        }

        public void Update(Category category)
        {
            _categoryDAL.Update(category);
        }
    }
}
