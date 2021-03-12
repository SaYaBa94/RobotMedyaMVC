using CoreLayer.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFCategoryTypeDAL:EFEntityRepositoryBase<CategoryType, RobotMedyaContext>, ICategoryTypeDAL
    {
        public List<Category> GetCategoryList(Expression<Func<Category, bool>> filter = null)
        {

            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                var result = from cat in context.Categories
                             join type in context.CategoryTypes on cat.CategoryTypeID equals type.CategoryTypeID
                             select new Category
                             {
                                 CategoryID = cat.CategoryID,
                                 CategoryName = cat.CategoryName,
                                 CategoryTypeID = cat.CategoryTypeID,
                                 CategoryType = type
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

    }
}
