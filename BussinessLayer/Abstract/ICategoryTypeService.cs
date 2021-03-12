using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Abstract
{
    public interface ICategoryTypeService
    {
        void Add(CategoryType categoryType);

        void Delete(CategoryType categoryType);
        void Update(CategoryType categoryType);

        List<CategoryType> GetAll();

        List<CategoryType> GetAllActive();

        CategoryType GetCategoryType(int typeid);

        List<Category> GetCategoryListByType(int typeid);


    }
}
