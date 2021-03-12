using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class AuthorListViewModel
    {
        public List<Author> Authors { get; set; }

        public Author Author { get; set; }
    }
}
