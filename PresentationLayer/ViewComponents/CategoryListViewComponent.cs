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
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ViewViewComponentResult Invoke()
        {

            int typeid =Convert.ToInt32(HttpContext.Session.GetInt32("currentType"));
            if (typeid == 0)
            {
                typeid = 1;
            }

            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetCategoryListByType(typeid),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"]),
                CurrentCategoryType = typeid,
            };
            model.firstCategory = model.Categories[0].CategoryID;
            return View("CategoryList", model);
        }

    }
}
