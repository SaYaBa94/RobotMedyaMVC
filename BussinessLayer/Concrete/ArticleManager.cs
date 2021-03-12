using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDAL _articleDAL;

        public ArticleManager(IArticleDAL articleDal)
        {
            _articleDAL = articleDal;
        }

        public List<Article> GetArticleList()
        {
            return _articleDAL.GetArticleList(a=>a.IsEnable==true);
        }

        public List<Article> GetArticleListByCategory(int categoryID)
        {
            return _articleDAL.GetArticleList(a => a.CategoryID == categoryID && a.IsEnable == true);
        }

        public void Add(Article article)
        {
            _articleDAL.Add(article);
        }

        public void Delete(Article article)
        {
            _articleDAL.Delete(article);
        }
        public void Update(Article article)
        {
            _articleDAL.Update(article);
        }

        public Article GetArticle(int id)
        {
            return _articleDAL.GetArticleList(a => a.ArticleID == id)[0];
        }

        public List<Author> GetAuthorList()
        {
            return _articleDAL.GetAuthorList();
        }

        public List<Category> GetCategoryList()
        {
            return _articleDAL.GetCategoryList();
        }

        public List<ArticleTag> GetTagsByArticle(int articleID)
        {
            return _articleDAL.GetTagsByArticle(articleID);
        }

        public List<ArticleTag> GetArticlesByTag(int tagID)
        {
            return _articleDAL.GetArticlesByTag(tagID);
        }

        public List<Article> GetArticleListToAdmin()
        {
            return _articleDAL.GetArticleList();
        }

        public List<CategoryType> GetCategoryTypeList()
        {
            return _articleDAL.GetCategoryTypeList();
        }
    }
}
