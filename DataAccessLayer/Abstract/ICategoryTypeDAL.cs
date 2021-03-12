using CoreLayer.DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryTypeDAL : IEntityRepository<CategoryType>
    {
        List<Category> GetCategoryList(Expression<Func<Category, bool>> filter = null);
    }
}
