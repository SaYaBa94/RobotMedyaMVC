
using CoreLayer.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Article : IEntity
    {
        public int ArticleID { get; set; }
        
        public int CategoryID { get; set; }
        
        public int AuthorID { get; set; }

        public string ArticleTitle { get; set; }

        public string ArticleBody { get; set; }

        public string ArticleThumbnail { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsEnable { get; set; }

        public  Author Author { get; set; }

        public  Category Category { get; set; }



    }
}
