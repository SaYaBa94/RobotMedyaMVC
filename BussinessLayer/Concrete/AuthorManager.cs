using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private IAuthorDAL _authorDAL;

        public AuthorManager(IAuthorDAL authorDAL)
        {
            _authorDAL = authorDAL;
        }

        public List<Author> GetAll()
        {
            return _authorDAL.GetList();
        }

        public Author GetAuthor(int id)
        {
            return _authorDAL.Get(a => a.AuthorID == id);
        }

        public void Add(Author author)
        {
            _authorDAL.Add(author);
        }

        public void Delete(Author author)
        {
            _authorDAL.Delete(author);
        }


        public void Update(Author author)
        {
            _authorDAL.Update(author);
        }

        public Author Get(string email, string password)
        {
            return _authorDAL.Get(a => a.AuthorEmail == email && a.AuthorPassword == password);
        }
    }
}
