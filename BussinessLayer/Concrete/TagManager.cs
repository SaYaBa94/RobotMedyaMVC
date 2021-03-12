using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Concrete
{
    public class TagManager : ITagService
    {
        private ITagDAL _tagDAL;

        public TagManager(ITagDAL tagDAL)
        {
            _tagDAL = tagDAL;
        }

        public void Add(Tag tag)
        {
            _tagDAL.Add(tag);
            
        }

        public void Delete(Tag tag)
        {
            _tagDAL.Delete(tag);
        }

        public List<Tag> GetAll()
        {
            return _tagDAL.GetList();
        }



        public Tag GetTag(int id)
        {
            return _tagDAL.Get(t => t.TagID == id);
        }

        public void Update(Tag tag)
        {
            _tagDAL.Update(tag);
        }
    }
}
