using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFAuthorDAL : EFEntityRepositoryBase<Author, RobotMedyaContext>, IAuthorDAL
    {
    }
}
