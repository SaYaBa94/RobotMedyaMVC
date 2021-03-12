using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Concrete
{
    public class ArticleTagManager : IArticleTagService
    {
        private IArticleTagDAL _articleTagDAL;

        public ArticleTagManager(IArticleTagDAL articleTagDAL)
        {
            _articleTagDAL = articleTagDAL;
        }

        public void Add(ArticleTag articleTag)
        {
            _articleTagDAL.Add(articleTag);
        }

        public void AddSelectedTags(ArticleTag articleTag,bool[] checkboxvalues, int[] id)
        {
            _articleTagDAL.AddSelectedTags(articleTag, checkboxvalues, id);
        }

        public void Delete(ArticleTag articleTag)
        {
            _articleTagDAL.Delete(articleTag);
        }

        public List<ArticleTag> GetAll()
        {
            return _articleTagDAL.GetList();
        }

        public List<Article> GetArticleList()
        {
            return _articleTagDAL.GetArticleList();
        }

        public ArticleTag GetArticleTag(string id)
        {

            string[] str = id.Split('-');
            return _articleTagDAL.Get(at => at.ArticleID == Convert.ToInt32(str[0]) && at.TagID == Convert.ToInt32(str[1]));
        }

        public List<ArticleTag> GetArticleTagList()
        {
            return _articleTagDAL.GetArticleTagList();
        }

        public List<ArticleTag> GetByArticle(int articleID)
        {
            return _articleTagDAL.GetList(at => at.ArticleID == articleID);
        }

        public List<Tag> GetTagList()
        {
            return _articleTagDAL.GetTagList();
        }

        public void Update(ArticleTag articleTag)
        {
            _articleTagDAL.Update(articleTag);
        }

       

    }
}
