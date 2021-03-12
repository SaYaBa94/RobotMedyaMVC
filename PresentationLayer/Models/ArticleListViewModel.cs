using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class ArticleListViewModel
    {
        public List<Article> Articles { get; set; }

        public Article Article { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }

        public int currentType { get; set; }
    }
}
