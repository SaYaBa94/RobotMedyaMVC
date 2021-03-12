using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class CategoryTypeController : Controller
    {
        private ICategoryTypeService _categoryTypeService;

        public CategoryTypeController(ICategoryTypeService categoryTypeService)
        {
            _categoryTypeService = categoryTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult AdminIndex()
        {
            var model = new CategoryTypeListViewModel {
                CategoryTypes = _categoryTypeService.GetAll()
            };

            return View(model);
        }
        [Authorize]
        public IActionResult AdminUpdate(int id)
        {
            var model = new CategoryTypeListViewModel
            {
                CategoryType = _categoryTypeService.GetCategoryType(id)
            };
            return View(model);
        }
        [Authorize]
        public IActionResult ActiveCategoryType(int id)
        {
            var categoryType = _categoryTypeService.GetCategoryType(id);
            categoryType.IsEnable = true;
            _categoryTypeService.Update(categoryType);
            return RedirectToAction("AdminIndex");
        }
        [Authorize]
        public IActionResult DeactiveCategoryType(int id)
        {
            var categoryType = _categoryTypeService.GetCategoryType(id);
            categoryType.IsEnable = false;
            _categoryTypeService.Update(categoryType);
            return RedirectToAction("AdminIndex");
        }
        [Authorize]
        public IActionResult AddCategoryType(CategoryType categoryType )
        {
            _categoryTypeService.Add(categoryType);
            return RedirectToAction("AdminIndex");
        }

        [Authorize]
        public IActionResult UpdateCategoryType(CategoryType categoryType)
        {
            _categoryTypeService.Update(categoryType);
            return RedirectToAction("AdminIndex");
        }

    }
}
