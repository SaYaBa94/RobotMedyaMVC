using CoreLayer.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Author:IEntity
    {
        public int AuthorID { get; set; }

        public string AuthorName { get; set; }

        public string AuthorSurname { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorPassword { get; set; }

        public string AuthorImg { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsEnable { get; set; }

    }
}
