using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Concrete
{
    public class CategoryTypeManager : ICategoryTypeService
    {
        private ICategoryTypeDAL _categoryTypeDAL;
        public CategoryTypeManager(ICategoryTypeDAL categoryTypeDAL)
        {
            _categoryTypeDAL = categoryTypeDAL;
        }

        public void Add(CategoryType categoryType)
        {
            _categoryTypeDAL.Add(categoryType);
        }

        public void Delete(CategoryType categoryType)
        {
            _categoryTypeDAL.Delete(categoryType);
        }

        public List<CategoryType> GetAll()
        {
            return _categoryTypeDAL.GetList();
        }

        public List<CategoryType> GetAllActive()
        {
            return _categoryTypeDAL.GetList(c => c.IsEnable == true);
        }

        public CategoryType GetCategoryType(int typeid)
        {
            return _categoryTypeDAL.Get(c => c.CategoryTypeID == typeid);
        }

        public void Update(CategoryType categoryType)
        {
            _categoryTypeDAL.Update(categoryType);
        }

        public List<Category> GetCategoryListByType(int typeid)
        {
            return _categoryTypeDAL.GetCategoryList(c => c.CategoryTypeID == typeid);
        }
    }
}
