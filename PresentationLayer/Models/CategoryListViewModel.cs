using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }

        public Category Category { get; set; }

        public int CurrentCategory { get;  set; }
        public int CurrentCategoryType { get; set; }

        public int firstCategory { get;set; }
    }
}
