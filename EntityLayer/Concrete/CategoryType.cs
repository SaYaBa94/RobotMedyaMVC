using CoreLayer.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class CategoryType:IEntity
    {
        public int CategoryTypeID { get; set; }
        public string CategoryTypeName { get; set; }

        public bool IsEnable { get; set; }
    }
}
