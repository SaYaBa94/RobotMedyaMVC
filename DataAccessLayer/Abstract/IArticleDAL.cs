using CoreLayer.DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IArticleDAL : IEntityRepository<Article>
    {
        //listeleme ekleme silme güncelleme

        List<Article> GetArticleList(Expression<Func<Article, bool>> filter = null);

        //List<Article> GetArticleListByCategory(int categoryID);

        List<ArticleTag> GetTagsByArticle(int articleID);

        List<ArticleTag> GetArticlesByTag(int tagID);

        List<Author> GetAuthorList();

        List<Category> GetCategoryList();

        List<CategoryType> GetCategoryTypeList();
    }
}
