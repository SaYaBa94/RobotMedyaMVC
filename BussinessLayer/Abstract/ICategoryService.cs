using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryListByType(int typeid);

        List<Category> GetCategoryList();

        List<CategoryType> GetCategoryTypeList();

        Category GetCategory(int id);

        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
    }
}
