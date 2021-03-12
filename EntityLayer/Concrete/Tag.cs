using CoreLayer.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Tag : IEntity
    {
        public int TagID { get; set; }
        public string TagName { get; set; }

    }
}
