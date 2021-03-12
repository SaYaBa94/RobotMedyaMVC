using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class ArticleTagListViewModel
    {
        public List<ArticleTag> ArticleTags { get; set; }

        public ArticleTag ArticleTag { get; set; }

        public List<Tag> Tags { get; set; }
        public bool[] CheckedTag { get; set; }

        public Checkboxes[] chkboxes { get; set; }


    }
    public class Checkboxes{
        public int id { get; set; }

        public bool chkValue { get; set; }
    }

}
