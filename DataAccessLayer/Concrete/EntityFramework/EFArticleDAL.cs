using CoreLayer.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using EntityLayer.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFArticleDAL : EFEntityRepositoryBase<Article, RobotMedyaContext>, IArticleDAL
    {


            public List<Article> GetArticleList(Expression<Func<Article, bool>> filter = null)
            {

            using (RobotMedyaContext context = new RobotMedyaContext())
            {



                var result = from art in context.Articles
                             join cat in context.Categories on art.CategoryID equals cat.CategoryID
                             join aut in context.Authors on art.AuthorID equals aut.AuthorID
                             orderby art.ArticleID descending
                             select new Article
                             {
                                 ArticleID = art.ArticleID,
                                 ArticleTitle = art.ArticleTitle,
                                 ArticleBody = art.ArticleBody,
                                 ArticleThumbnail = art.ArticleThumbnail,
                                 CreateDate = art.CreateDate,
                                 IsEnable = art.IsEnable,
                                 AuthorID = art.AuthorID,
                                 CategoryID = art.CategoryID,
                                 Category = cat,
                                 Author = aut
                             };



                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        //public List<Article> GetArticleListByCategory(int categoryID)
        //{
        //    using (RobotMedyaContext context = new RobotMedyaContext())
        //    {
        //        List<Article> result = GetArticleList();
        //        return result.Where(a => a.CategoryID == categoryID).ToList();
        //    }
        //}


        public List<Category> GetCategoryList()
        {
            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                return context.Categories.ToList();
            }
        }

        public List<CategoryType> GetCategoryTypeList()
        {
            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                return context.CategoryTypes.ToList();
            }
        }

        public List<Author> GetAuthorList()
        {
            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                return context.Authors.ToList();
            }
        }

        public List<ArticleTag> GetTagsByArticle(int articleID)
        {
            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                var result = from article in context.Articles
                             from tag in context.Tags
                             join articleTag in context.ArticleTags
                                 on new { article.ArticleID, tag.TagID } equals new { articleTag.ArticleID, articleTag.TagID }
                             select new ArticleTag
                             {
                                 Tag = tag,
                                 Article = article,
                                 ArticleID = articleTag.ArticleID,
                                 TagID = articleTag.TagID
                             };
                return result.Where(a => a.ArticleID == articleID).ToList();
            }
        }

        public List<ArticleTag> GetArticlesByTag(int tagID)
        {
            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                var result = from article in context.Articles
                             from tag in context.Tags
                             join articleTag in context.ArticleTags
                                 on new { article.ArticleID, tag.TagID } equals new { articleTag.ArticleID, articleTag.TagID }
                             select new ArticleTag
                             {
                                 Tag = tag,
                                 Article = article,
                                 ArticleID = articleTag.ArticleID,
                                 TagID = articleTag.TagID
                             };
                return result.Where(t => t.TagID == tagID).ToList();
            }
        }
    }
}