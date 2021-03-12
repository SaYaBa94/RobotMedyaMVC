using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Abstract
{
    public interface ITagService
    {
        List<Tag> GetAll();

        Tag GetTag(int id);

        void Add(Tag tag);

        void Delete(Tag tag);
        void Update(Tag tag);
    }
}
