using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Abstract
{
    public interface IArticleTagService
    {
        List<ArticleTag> GetAll();

        List<ArticleTag> GetByArticle(int articleID);

        List<ArticleTag> GetArticleTagList();

        List<Article> GetArticleList();

        void AddSelectedTags(ArticleTag articleTag, bool[] checkboxvalues, int[] id);
        List<Tag> GetTagList();

        void Add(ArticleTag articleTag);

        void Update(ArticleTag articleTag);

        void Delete(ArticleTag articleTag);

        ArticleTag GetArticleTag(string id);
    }
}
