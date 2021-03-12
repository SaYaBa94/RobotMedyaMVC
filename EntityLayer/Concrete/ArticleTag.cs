using CoreLayer.EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EntityLayer.Concrete
{
    public  class ArticleTag : IEntity
    {
        public int ArticleID { get; set; }
        public int TagID { get; set; }
        public Article Article { get; set; }
        public Tag Tag { get; set; }

    }
}
