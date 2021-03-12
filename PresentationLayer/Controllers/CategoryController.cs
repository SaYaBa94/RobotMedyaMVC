using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {

            return View();

        }
        [Authorize]
        public IActionResult AdminIndex()
        {
            SetViewBags();
            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetCategoryList()
            };
            return View(model);
        }
        [Authorize]
        public IActionResult AdminUpdate(int id)
        {
            SetViewBags();
            var model = new CategoryListViewModel
            {
                Category = _categoryService.GetCategory(id)
            };
            return View(model);
        }
        [Authorize]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("AdminIndex");
        }
        [Authorize]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.Add(category);
            return RedirectToAction("AdminIndex");
        }

        [Authorize]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetCategory(id);
            _categoryService.Delete(category);
            return RedirectToAction("AdminIndex");
        }

        public void SetViewBags()
        {

            List<SelectListItem> kategoriTipleri = (from kategoritipi in _categoryService.GetCategoryTypeList()
                                                    select new SelectListItem
                                                    {
                                                        Text = kategoritipi.CategoryTypeName,
                                                        Value = kategoritipi.CategoryTypeID.ToString()
                                                    }).ToList();
            ViewBag.kategoriTipleri = kategoriTipleri;


        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

