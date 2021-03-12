using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class CategoryTypeListViewModel
    {
        public List<CategoryType> CategoryTypes { get; set; }

        public List<Category> Categories { get; set; }

        public CategoryType CategoryType { get; set; }

        public int CurrentCategoryType { get; set; }

        public List<int> firstCategory { get; set; }
    }
}
