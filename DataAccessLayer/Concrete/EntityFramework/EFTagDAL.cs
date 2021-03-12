using System;
using System.Collections.Generic;
using System.Text;
using CoreLayer.DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using EntityLayer.Concrete;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFTagDAL : EFEntityRepositoryBase<Tag, RobotMedyaContext>, ITagDAL
    {
       
    }
}
