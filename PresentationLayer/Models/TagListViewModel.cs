using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class TagListViewModel
    {
        public List<Tag> Tags { get; set; }

        public Tag Tag { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }

    }
}
