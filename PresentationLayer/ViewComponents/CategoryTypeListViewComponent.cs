using BussinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents
{
    public class CategoryTypeListViewComponent:ViewComponent
    {
        private ICategoryTypeService _categoryTypeService;

        public CategoryTypeListViewComponent(ICategoryTypeService categoryTypeService)
        {
            _categoryTypeService = categoryTypeService;
        }

        public ViewViewComponentResult Invoke(int typeid)
        {
            typeid = Convert.ToInt32(HttpContext.Request.Query["typeid"]);
            if (typeid == 0)
            {
                typeid = 1;
            }
            else
            {
                HttpContext.Session.SetInt32("currentType", typeid);
            }

           
            var model = new CategoryTypeListViewModel
            {
                CategoryTypes = _categoryTypeService.GetAllActive()
            };
            model.firstCategory = new List<int>();
            for (int i = 0; i < model.CategoryTypes.Count; i++)
            {
                int id = model.CategoryTypes[i].CategoryTypeID;
                int categoryid = _categoryTypeService.GetCategoryListByType(id)[0].CategoryID;
                model.firstCategory.Add(categoryid);
            }
            return View("Navbar",model);
        }
    }
}
