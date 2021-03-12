using CoreLayer.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Category : IEntity
    {
        
        public int CategoryID { get; set; }

        public int CategoryTypeID { get; set; }
        public string CategoryName { get; set; }

        public CategoryType CategoryType { get; set; }

    }
}
