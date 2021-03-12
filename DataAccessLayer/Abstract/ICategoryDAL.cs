using CoreLayer.DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
        List<Category> GetCategoryList(Expression<Func<Category, bool>> filter = null);

        List<CategoryType> GetCategoryTypeList();
       

    }
}
