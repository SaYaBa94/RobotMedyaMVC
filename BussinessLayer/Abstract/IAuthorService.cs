using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAll();

        Author Get(string email, string password);
        Author GetAuthor(int id);

        void Add(Author author);

        void Delete(Author author);
        void Update(Author author);
    }
}
