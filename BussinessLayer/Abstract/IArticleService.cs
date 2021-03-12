using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Abstract
{
    public interface IArticleService
    {
        List<Author> GetAuthorList();
        List<Category> GetCategoryList();
        List<Article> GetArticleList();

        List<Article> GetArticleListToAdmin();

        List<Article> GetArticleListByCategory(int categoryID);

        List<CategoryType> GetCategoryTypeList();


        List<ArticleTag> GetTagsByArticle(int articleID);

        List<ArticleTag> GetArticlesByTag(int tagID);
        Article GetArticle(int id);

        void Add(Article article);

        void Delete(Article article);
        void Update(Article article);
    }
}
