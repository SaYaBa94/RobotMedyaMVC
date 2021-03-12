using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class TagController : Controller
    {
        private ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

       

        [Authorize]
        public IActionResult AdminIndex()
        {

            var model = new TagListViewModel
            {
                Tags = _tagService.GetAll()
            };
            return View(model);
        }
        [Authorize]
        public IActionResult AdminUpdate(int id)
        {
            var model = new TagListViewModel
            {
                Tag = _tagService.GetTag(id)
            };
            return View(model);
        }
        [Authorize]
        public IActionResult UpdateTag(Tag tag)
        {
            _tagService.Update(tag);
            return RedirectToAction("AdminIndex");
        }
        [Authorize]
        public IActionResult AddTag(Tag tag)
        {
            try
            {
                _tagService.Add(tag);
                return RedirectToAction("AdminIndex");
            }
            catch (Exception)
            {

                return RedirectToAction("Error");
            }
            

        }
        [Authorize]
        public IActionResult DeleteTag(int id)
        {
            var tag = _tagService.GetTag(id);
            _tagService.Delete(tag);
            return RedirectToAction("AdminIndex");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
