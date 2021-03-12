using CoreLayer.DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IArticleTagDAL : IEntityRepository<ArticleTag>
    {
        List<ArticleTag> GetArticleTagList();

        List<Tag> GetTagList();
        List<Article> GetArticleList();

        


        void AddSelectedTags(ArticleTag articleTag, bool[] checkboxvalues, int[] id);
    }
}
