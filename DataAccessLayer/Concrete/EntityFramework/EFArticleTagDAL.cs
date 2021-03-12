using CoreLayer.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFArticleTagDAL : EFEntityRepositoryBase<ArticleTag, RobotMedyaContext>, IArticleTagDAL
    {
        public List<Article> GetArticleList()
        {
            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                return context.Articles.ToList();
            }
        }

        public List<ArticleTag> GetArticleTagList()
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
            
                return result.ToList();
            }
        }

        public void AddSelectedTags(ArticleTag articleTag, bool[] checkboxvalues, int[] id)
        {
            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                for (int i = 0; i < checkboxvalues.Length; i++)
                {
                    if (checkboxvalues[i])
                    {
                        var addedEntity = context.Entry(new ArticleTag { ArticleID = articleTag.ArticleID, TagID = id[i] });
                        addedEntity.State = EntityState.Added;
                       

                    }
                }
                context.SaveChanges();
            }
        }

        public List<Tag> GetTagList()
        {
            using (RobotMedyaContext context = new RobotMedyaContext())
            {
                return context.Tags.ToList();
            }
        }
    }
}
