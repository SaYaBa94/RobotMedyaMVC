using CoreLayer.DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IAuthorDAL : IEntityRepository<Author>
    {
    }
}
